/*********************************************************************************
 *Author:         叶子三分青
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-12-04
 *Description:    Description
 *History:        2022-12-04--
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