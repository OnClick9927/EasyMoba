using LockStep.Math;
using UnityEngine;

namespace EasyMoba.GameLogic
{
    public class BattleInput
    {
        private float gap = 0.04f;
        private float last_lime;
        private FrameData data;


        private FrameCollection collection;
        private BattleModePlayer mode_server;
        public BattleInput(FrameCollection collection, BattleModePlayer mode_server)
        {
            this.collection = collection;
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
            mode_server.SendFrameToServer(collection.curFrame, data);
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


        public void SetJoyStick(float x,float y)
        {
            data.stick = new LVector2(new LFloat(x), new LFloat(y));
        }
    }
}

