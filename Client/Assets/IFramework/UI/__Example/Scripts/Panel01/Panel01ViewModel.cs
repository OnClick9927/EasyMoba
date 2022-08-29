/*********************************************************************************
 *Author:         爱吃水蜜桃
 *Version:        1.0
 *UnityVersion:   2018.4.24f1
 *Date:           2021-06-27
 *Description:    Description
 *History:        2021-06-27--
*********************************************************************************/
namespace IFramework.UI.Example
{
	public partial class Panel01ViewModel
	{
		protected override void Initialize()
		{

		}

		protected override void OnDispose()
		{

		}

        protected override void Listen(IEventArgs message)
        {
            if (message is Panel01Args)
            {
                Panel01Args arg = message as Panel01Args;
                switch (arg.type)
                {
                    case Panel01ArgsEventType.Add:
                        this.count++;
                        break;
                    case Panel01ArgsEventType.Sub:
                        this.count--;
                        break;
                    case Panel01ArgsEventType.Next:
                        //Launcher.Instance.game.As<UI_Game>().module.Show(UIMap_MVVM.Panel02);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}