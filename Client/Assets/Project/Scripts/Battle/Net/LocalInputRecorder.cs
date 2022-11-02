using IFramework.Singleton;
namespace EasyMoba
{
    public class LocalInputRecorder : Singleton<LocalInputRecorder>
    {
        public FrameData data;
        public string roomid;
        public long roleid;
        public int curframe;
        public void RebuidData()
        {
            data = new FrameData();
        }
        protected override void OnDispose()
        {

        }

        protected override void OnSingletonInit()
        {
            RebuidData();
        }
    }
}

