/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-08-04
 *Description:    Description
 *History:        2022-08-04--
*********************************************************************************/
namespace IFramework.UI.Example
{
	public partial class Panel02View
	{

		protected override void OnLoad()
		{
		}

		protected override void OnShow()
		{
			this.Text.text = System.DateTime.Now.ToString();

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