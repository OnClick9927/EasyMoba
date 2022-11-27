namespace EasyMoba.GameLogic
{
    public abstract class SkillEffectExecutor
    {
        private bool _need_remove;
        public bool need_remove
        {
            get
            {
                return _need_remove;
            }
            protected set
            {
                if (_need_remove != value)
                {
                    _need_remove = value;
                    if (_need_remove)
                    {
                        OnRemove();
                    }
                }
            }
        }

        protected abstract void OnStart();
        protected abstract void OnRemove();
        protected abstract void OnFixUpdate(int curFrame);
        public void FixUpdate(int curFrame)
        {
            if (need_remove) return;
            OnFixUpdate(curFrame);
        }
    }
    public abstract class SkillEffectExecutor<T> : SkillEffectExecutor where T : SkillEffectData
    {
        protected T data { get; private set; }
        protected MobaUnit owener { get; private set; }
        public SkillEffectExecutor(T data, MobaUnit owener)
        {
            this.data = data;
            this.owener = owener;
            this.OnStart();
        }

    }
}

