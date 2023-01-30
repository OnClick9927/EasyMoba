namespace EasyMoba.GameLogic
{
    public interface IBattleView
    {
        void Start();
        void Quit();
        void OnUnitCreate(MobaUnit unit);
    }
}

