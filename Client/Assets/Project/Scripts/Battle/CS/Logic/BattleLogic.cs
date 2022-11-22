using System.Collections.Generic;

namespace EasyMoba.GameLogic
{

    public class BattleLogic
    {
        private Battle battle;

        private BattleFactory factory { get { return battle.factory; } }


        public BattleLogic(Battle battle)
        {
            this.battle = battle;
        }

        public void LoadBaseUnit(MapInitData map_data, List<BattlePlayer> players)
        {
            var data = map_data;
            foreach (var item in data.cs) factory.CreateWall(item);
            foreach (var item in data.ps) factory.CreateWall(item);
            var bs = data.bornPos;
            for (int i = 0; i < players.Count; i++) factory.CreatePlayer(players[i], bs[i]);
        }
        public void StartPlayLogic()
        {

        }
    }
}

