using System.Collections.Generic;
using UnityEngine;

namespace LCollision2D
{
    [CreateAssetMenu]
    public class LayerConfig : UnityEngine.ScriptableObject
    {
        [System.Serializable]
        public class LayerData
        {
            public string name;
            public CollisionLayer layer;
            public CollisionLayer collinons;
        }
        public List<LayerData> Layers;
        public bool CouldLayerCollision(CollisionLayer shap_a, CollisionLayer shap_b)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            return find.collinons.HasFlag(shap_b);
        }
        public string GetName(CollisionLayer shap_a)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            if (find == null)
            {
                find = new LayerData() { layer = shap_a };
                Layers.Add(find);
            }
            return find.name;
        }
        public void SetName(CollisionLayer shap_a, string name)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            find.name = name;
        }
    }

}


