/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.146
 *UnityVersion:   2018.4.17f1
 *Date:           2020-04-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;

namespace IFramework.Tweens
{
    public class TweenDrive : UpdateModule
    {
        private List<TweenValue> tweens;
        private Queue<TweenValue> queue;
        private Queue<Tween> wait;
        protected override void Awake()
        {
            tweens = new List<TweenValue>();
            queue = new Queue<TweenValue>();
            wait = new Queue<Tween>();
        }

        protected override void OnDispose()
        {
            tweens.Clear();
            queue.Clear();
            wait.Clear();
        }

        protected override void OnUpdate()
        {
            while (wait.Count != 0)
            {
                wait.Dequeue().Run();
            }
            while (queue.Count != 0)
            {
                var tv = queue.Dequeue();
                tweens.Remove(tv);
                tv.Recyle();
            }
            for (int i = tweens.Count - 1; i >= 0; i--)
            {
                var tv = tweens[i];
                tv.Update();
                if (tv.compelete)
                {
                    queue.Enqueue(tv);
                }
            }

        }

        public void Subscribe(TweenValue tv)
        {
            if (tweens.Contains(tv)) return;
            tweens.Add(tv);
        }
        public void WaitRun(Tween tween)
        {
            wait.Enqueue(tween);
        }
        protected override ModulePriority OnGetDefautPriority()
        {
            return ModulePriority.Custom + 20;
        }
    }
}
