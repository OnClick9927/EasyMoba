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
    public partial class Panel01View
    {
        protected override void BindProperty()
        {
            base.BindProperty();
            this.handler.BindProperty(() => { this.Count_Text.text = this.Tcontext.count.ToString(); });
            //ToDo
        }

        protected override void OnLoad()
        {
            BindButton(this.BTn_ADD, () =>
            {
                Publish(new Panel01Args().SetType(Panel01ArgsEventType.Add));
            });
            BindButton(this.BTn_SUB, () =>
            {
                Publish(new Panel01Args().SetType(Panel01ArgsEventType.Sub));
            });
            BindButton(this.BTn_Next, () =>
            {
                Publish(new Panel01Args().SetType(Panel01ArgsEventType.Next));
            });
        }


        protected override void OnShow()
        {
            panel.gameObject.SetActive(true);
        }

        protected override void OnHide()
        {
            panel.gameObject.SetActive(false);

        }

        protected override void OnClose()
        {
        }

    }
}