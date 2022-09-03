/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
namespace EasyMoba
{
	public partial class UpdatePanelView : IFramework.UI.MVC.UIView<UpdatePanel> 
	{
		private UnityEngine.UI.Slider Progress { get { return Tpanel.Progress; } }

	}
}