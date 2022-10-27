using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace LCollision2D
{
    [CreateAssetMenu]
    public class LayerConfig : UnityEngine.ScriptableObject
    {
        [System.Serializable]
        public class LayerData
        {
            public string name;
            public ShapeLayer layer;
            public ShapeLayer collinons;
        }
        public List<LayerData> Layers;
        public bool CouldLayerCollision(ShapeLayer shap_a, ShapeLayer shap_b)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            return find.collinons.HasFlag(shap_b);
        }
        public string GetName(ShapeLayer shap_a)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            if (find == null)
            {
                find = new LayerData() { layer = shap_a };
                Layers.Add(find);
            }
            return find.name;
        }
        public void SetName(ShapeLayer shap_a, string name)
        {
            var find = Layers.Find(x => x.layer == shap_a);
            find.name = name;
        }
    }

}


