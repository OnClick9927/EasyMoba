namespace EasyMoba.GameLogic
{
    public interface IBattleAttribute
    {

    }
    public class BattleAttribute<T>: IBattleAttribute
    {
        public T value;
    }
}

