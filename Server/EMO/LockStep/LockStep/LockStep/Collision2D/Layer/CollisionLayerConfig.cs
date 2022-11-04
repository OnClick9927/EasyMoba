using System.Collections.Generic;

namespace LockStep.LCollision2D
{
    [System.Serializable]
    public partial class CollisionLayerConfig
    {
        public List<LayerData> Layers = new List<LayerData>();
        public string GetName(CollisionLayer layer)
        {
            var find = Layers.Find(x => x.layer == layer);
            if (find == null)
            {
                find = new LayerData() { layer = layer };
                Layers.Add(find);
            }
            return find.name;
        }
        public bool CouldLayerCollision(CollisionLayer shap_a, CollisionLayer shap_b)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            return find.collinons.HasFlag(shap_b);
        }
        public LayerData Find(CollisionLayer layer)
        {
            return Layers.Find(x => x.layer == layer);
        }
    }

}


