using UnityEngine;

namespace LockStep.LCollision2D
{
    [CreateAssetMenu]
    public class UnityShapeLayerConfig : UnityEngine.ScriptableObject
    {
        public CollisionLayerConfig cfg = new CollisionLayerConfig();
        public string GetName(CollisionLayer layer)
        {
            return cfg.GetName(layer);
        }
        public bool CouldLayerCollision(CollisionLayer shap_a, CollisionLayer shap_b)
        {
            return cfg.CouldLayerCollision(shap_a, shap_b);
        }
        public void SetCouldLayerCollision(CollisionLayer shap_a, CollisionLayer shap_b, bool ok)
        {
            var find_a = cfg.Find(shap_a);
            var find_b = cfg.Find(shap_b);

            if (ok)
            {
                if (!find_a.collinons.HasFlag(shap_b))
                {
                    find_a.collinons |= shap_b;
                }
                if (!find_b.collinons.HasFlag(shap_a))
                {
                    find_b.collinons |= shap_a;
                }
            }
            else
            {
                if (find_a.collinons.HasFlag(shap_b))
                {
                    find_a.collinons ^= shap_b;
                }
                if (find_b.collinons.HasFlag(shap_a))
                {
                    find_b.collinons ^= shap_a;
                }
            }

        }


        public void SetName(CollisionLayer layer, string name)
        {
            var find = cfg.Find(layer);
            find.name = name;
        }
    }

}


