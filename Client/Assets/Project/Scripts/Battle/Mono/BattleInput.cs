using LockStep.Math;
using UnityEngine;

namespace EasyMoba.GameLogic.Mono
{
    public class BattleInput
    {
        private float gap = 0.04f;
        private float last_lime;
        private FrameData data;


        private BattleModePlayer mode_server;
        public BattleInput(BattleModePlayer mode_server)
        {
            this.mode_server = mode_server;
            ResetData();
        }
        private void ResetData()
        {
            last_lime = Time.time;
            data = new FrameData();
        }
        private void SendFrame()
        {
            mode_server.SendFrameToServer(MonoBattle.Instance.CurFrame, data);
            ResetData();
        }
        public void Update()
        {
            if (Time.time - last_lime > gap)
            {
                SendFrame();
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            SetJoyStick(h, v);
        }


        public void SetJoyStick(float x, float y)
        {
            data.stick = new LVector2(new LFloat(x), new LFloat(y));
        }
    }
}

