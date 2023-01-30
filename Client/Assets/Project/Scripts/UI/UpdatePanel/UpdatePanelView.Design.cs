/*********************************************************************************
 *Author:         Wulala
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2023-01-30
*********************************************************************************/
namespace EasyMoba
{
	public partial class UpdatePanelView : IFramework.UI.MVC.UIView 
	{
		private UnityEngine.UI.Slider Progress;

		private void InitComponents()
		{
			Progress = panel.transform.Find("BG/down/Progress").GetComponent<UnityEngine.UI.Slider>();

		}
	}
}