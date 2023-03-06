using LockStep.LCollision2D;
using System;
using System.Collections.Generic;
using System.IO;
using WooAsset;

namespace EasyMoba.GameLogic.Mono
{
    public class BattleView : IBattleView
    {
        private Dictionary<string, ViewUnit> units = new Dictionary<string, ViewUnit>();
        public void OnUnitCreate(MobaUnit unit)
        {

            async void AsyncCreate(string path, Type type)
            {
                var asset = await Assets.InstantiateAsync(path, null);
                var go = asset.gameObject;
                ViewUnit view = go.GetComponent<ViewUnit>();
                if (view == null)
                {
                    go.AddComponent(type);
                    view = go.GetComponent<ViewUnit>();
                }
                view.logic_unit = unit;
                var uid = unit.uid;
                units[uid] = view;
            }
            string path = "";
            Type type = null;
            switch (unit.type)
            {
                case MobaUnitType.Wall:
                    break;
                case MobaUnitType.Player:
                    path = "Assets/Project/Prefabs/Battle/Character/char_001.prefab";
                    type = typeof(PlayerUnitView );
                    break;
                default:
                    break;
            }

            AsyncCreate(path, type);

        }

        public void Quit()
        {
            units.Clear();
            units = null;
        }

        public void Start()
        {

        }
    }
}

