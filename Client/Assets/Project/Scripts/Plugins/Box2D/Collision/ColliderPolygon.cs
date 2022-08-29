using System;
using System.Diagnostics;
using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Common;

namespace Box2DSharp.Collision
{
    /// <summary>
    ///     Collision Algorithm
    /// </summary>
    public static partial class CollisionUtils
    {
        // Find the max separation between poly1 and poly2 using edge normals from poly1.
        public static FP FindMaxSeparation(
            out int edgeIndex,
            PolygonShape poly1,
            in Transform xf1,
            PolygonShape poly2,
            in Transform xf2)
        {
            var count1 = poly1.Count;
            var count2 = poly2.Count;

            Span<FVector2> n1s = poly1.Normals;
            Span<FVector2> v1s = poly1.Vertices;
            Span<FVector2> v2s = poly2.Vertices;

            // var xf = MathUtils.MulT(xf2, xf1); // inline
            var subX = xf1.Position.X - xf2.Position.X;
            var subY = xf1.Position.Y - xf2.Position.Y;
            var x = xf2.Rotation.Cos * subX + xf2.Rotation.Sin * subY;
            var y = -xf2.Rotation.Sin * subX + xf2.Rotation.Cos * subY;
            var sin = xf2.Rotation.Cos * xf1.Rotation.Sin - xf2.Rotation.Sin * xf1.Rotation.Cos;
            var cos = xf2.Rotation.Cos * xf1.Rotation.Cos + xf2.Rotation.Sin * xf1.Rotation.Sin;

            var bestIndex = 0;
            var maxSeparation = Settings.MinFloat;
            FP nX, nY, v1X, v1Y;
            FP si;
            for (var i = 0; i < count1; ++i)
            {
                // Get poly1 normal in frame2.
                // var n = MathUtils.Mul(xf.Rotation, n1s[i]); // inline
                ref readonly var n1si = ref n1s[i];
                nX = cos * n1si.X - sin * n1si.Y;
                nY = sin * n1si.X + cos * n1si.Y;

                // var v1 = MathUtils.Mul(xf, v1s[i]); // inline
                ref readonly var v1si = ref v1s[i];
                v1X = cos * v1si.X - sin * v1si.Y + x;
                v1Y = sin * v1si.X + cos * v1si.Y + y;

                // Find deepest point for normal i.
                si = Settings.MaxFloat;
                for (var j = 0; j < count2; ++j)
                {
                    //var sij = FVector2.Dot(n, v2s[j] - v1); // inline
                    ref readonly var v2sj = ref v2s[j];
                    var sij = nX * (v2sj.X - v1X) + nY * (v2sj.Y - v1Y);
                    if (sij < si)
                    {
                        si = sij;
                    }
                }

                if (si > maxSeparation)
                {
                    maxSeparation = si;
                    bestIndex = i;
                }
            }

            edgeIndex = bestIndex;
            return maxSeparation;
        }

        public static void FindIncidentEdge(
            in Span<ClipVertex> c,
            PolygonShape poly1,
            in Transform xf1,
            int edge1,
            PolygonShape poly2,
            in Transform xf2)
        {
            var normals1 = poly1.Normals;
            var count2 = poly2.Count;
            var vertices2 = poly2.Vertices;
            var normals2 = poly2.Normals;

            Debug.Assert(0 <= edge1 && edge1 < poly1.Count);

            // Get the normal of the reference edge in poly2's frame.
            // var normal1 = MathUtils.MulT(xf2.Rotation, MathUtils.Mul(xf1.Rotation, normals1[edge1])); // inline
            ref readonly var n1 = ref normals1[edge1];
            var y = new FVector2(xf1.Rotation.Cos * n1.X - xf1.Rotation.Sin * n1.Y, xf1.Rotation.Sin * n1.X + xf1.Rotation.Cos * n1.Y);
            var normal1 = new FVector2(xf2.Rotation.Cos * y.X + xf2.Rotation.Sin * y.Y, -xf2.Rotation.Sin * y.X + xf2.Rotation.Cos * y.Y);

            // Find the incident edge on poly2.
            var index = 0;
            var minDot = Settings.MaxFloat;
            for (var i = 0; i < count2; ++i)
            {
                var dot = FVector2.Dot(normal1, normals2[i]);
                if (dot < minDot)
                {
                    minDot = dot;
                    index = i;
                }
            }

            // Build the clip vertices for the incident edge.
            var i1 = index;
            var i2 = i1 + 1 < count2 ? i1 + 1 : 0;
            ref var c0 = ref c[0];
            c0.Vector = MathUtils.Mul(xf2, vertices2[i1]);
            c0.Id.ContactFeature.IndexA = (byte)edge1;
            c0.Id.ContactFeature.IndexB = (byte)i1;
            c0.Id.ContactFeature.TypeA = (byte)ContactFeature.FeatureType.Face;
            c0.Id.ContactFeature.TypeB = (byte)ContactFeature.FeatureType.Vertex;

            ref var c1 = ref c[1];
            c1.Vector = MathUtils.Mul(xf2, vertices2[i2]);
            c1.Id.ContactFeature.IndexA = (byte)edge1;
            c1.Id.ContactFeature.IndexB = (byte)i2;
            c1.Id.ContactFeature.TypeA = (byte)ContactFeature.FeatureType.Face;
            c1.Id.ContactFeature.TypeB = (byte)ContactFeature.FeatureType.Vertex;
        }
        private static readonly FP k_tol = 0.1f * Settings.LinearSlop;
        // Find edge normal of max separation on A - return if separating axis is found
        // Find edge normal of max separation on B - return if separation axis is found
        // Choose reference edge as min(minA, minB)
        // Find incident edge
        // Clip

        // The normal points from 1 to 2
        /// Compute the collision manifold between two polygons.
        public static void CollidePolygons(
            ref Manifold manifold,
            PolygonShape polyA,
            in Transform xfA,
            PolygonShape polyB,
            in Transform xfB)
        {
            manifold.PointCount = 0;
            var totalRadius = polyA.Radius + polyB.Radius;

            var separationA = FindMaxSeparation(
                out var edgeA,
                polyA,
                xfA,
                polyB,
                xfB);
            if (separationA > totalRadius)
            {
                return;
            }

            var separationB = FindMaxSeparation(
                out var edgeB,
                polyB,
                xfB,
                polyA,
                xfA);
            if (separationB > totalRadius)
            {
                return;
            }

            PolygonShape poly1; // reference polygon 
            PolygonShape poly2; // incident polygon 
            Transform xf1, xf2;
            int edge1; // reference edge
            byte flip;

            if (separationB > separationA + k_tol)
            {
                poly1 = polyB;
                poly2 = polyA;
                xf1 = xfB;
                xf2 = xfA;
                edge1 = edgeB;
                manifold.Type = ManifoldType.FaceB;
                flip = 1;
            }
            else
            {
                poly1 = polyA;
                poly2 = polyB;
                xf1 = xfA;
                xf2 = xfB;
                edge1 = edgeA;
                manifold.Type = ManifoldType.FaceA;
                flip = 0;
            }

            Span<ClipVertex> incidentEdge = stackalloc ClipVertex[2];
            FindIncidentEdge(in incidentEdge, poly1, xf1, edge1, poly2, xf2);

            var count1 = poly1.Count;
            var vertices1 = poly1.Vertices;

            var iv1 = edge1;
            var iv2 = edge1 + 1 < count1 ? edge1 + 1 : 0;

            var v11 = vertices1[iv1];
            var v12 = vertices1[iv2];

            var localTangent = v12 - v11;
            localTangent.Normalize();

            var localNormal = MathUtils.Cross(localTangent, 1.0f);
            var planePoint = 0.5f * (v11 + v12);

            var tangent = MathUtils.Mul(xf1.Rotation, localTangent);
            var normal = MathUtils.Cross(tangent, 1.0f);

            v11 = MathUtils.Mul(xf1, v11);
            v12 = MathUtils.Mul(xf1, v12);

            // Face offset.
            var frontOffset = FVector2.Dot(normal, v11);

            // Side offsets, extended by polytope skin thickness.
            var sideOffset1 = -FVector2.Dot(tangent, v11) + totalRadius;
            var sideOffset2 = FVector2.Dot(tangent, v12) + totalRadius;

            // Clip incident edge against extruded edge1 side edges.
            Span<ClipVertex> clipPoints1 = stackalloc ClipVertex[2];
            Span<ClipVertex> clipPoints2 = stackalloc ClipVertex[2];

            // Clip to box side 1
            var np = ClipSegmentToLine(
                clipPoints1,
                incidentEdge,
                -tangent,
                sideOffset1,
                iv1);

            if (np < 2)
            {
                return;
            }

            // Clip to negative box side 1
            np = ClipSegmentToLine(
                clipPoints2,
                clipPoints1,
                tangent,
                sideOffset2,
                iv2);

            if (np < 2)
            {
                return;
            }

            // Now clipPoints2 contains the clipped points.
            manifold.LocalNormal = localNormal;
            manifold.LocalPoint = planePoint;

            var pointCount = 0;
            for (var i = 0; i < Settings.MaxManifoldPoints; ++i)
            {
                var separation = FVector2.Dot(normal, clipPoints2[i].Vector) - frontOffset;

                if (separation <= totalRadius)
                {
                    ref var cp = ref manifold.Points[pointCount];
                    cp.LocalPoint = MathUtils.MulT(xf2, clipPoints2[i].Vector);
                    cp.Id = clipPoints2[i].Id;
                    if (flip != default)
                    {
                        // Swap features
                        var cf = cp.Id.ContactFeature;
                        cp.Id.ContactFeature.IndexA = cf.IndexB;
                        cp.Id.ContactFeature.IndexB = cf.IndexA;
                        cp.Id.ContactFeature.TypeA = cf.TypeB;
                        cp.Id.ContactFeature.TypeB = cf.TypeA;
                    }

                    ++pointCount;
                }
            }

            manifold.PointCount = pointCount;
        }
    }
}