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
	public partial class Panel01View : IFramework.UI.MVVM.UIView<Panel01ViewModel, Panel01> 
	{
		private UnityEngine.UI.Text Count_Text { get { return Tpanel.Count_Text; } }
		private UnityEngine.UI.Button BTn_ADD { get { return Tpanel.BTn_ADD; } }
		private UnityEngine.UI.Button BTn_SUB { get { return Tpanel.BTn_SUB; } }
		private UnityEngine.UI.Button BTn_Next { get { return Tpanel.BTn_Next; } }

	}
}