namespace EasyMoba.GameLogic
{
    public abstract class Buff
    {
        protected BuffData data;
        public Battle battle;
        public MobaUnit target;

        private bool _need_remove;
        public bool need_remove
        {
            get { return _need_remove; }
            set
            {
                if (_need_remove != value)
                {
                    _need_remove = value;
                    if (_need_remove) OnRemove();
                }
            }
        }


        public void FixedUpdate(int curFrame)
        {
            if (need_remove) return;
            OnFixedUpdate(curFrame);
        }

        public static Buff Create(BuffData data)
        {
            Buff buf = null;
            buf.data = data;
            switch (data.type)
            {
                default:
                    break;
            }
            return buf;
        }

        protected abstract void OnFixedUpdate(int curFrame);
        protected abstract void OnRemove();
        public abstract void OnAdd();
    }
}

