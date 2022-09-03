using System;

namespace IFramework
{
    partial class LoomModule
    {
        private struct DelayedTask
        {
            public Action action;

            public DelayedTask(Action action)
            {
                this.action = action;
            }
        }
    }
}
