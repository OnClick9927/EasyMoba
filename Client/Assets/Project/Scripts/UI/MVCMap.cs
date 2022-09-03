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
	partial class MVCMap
	{
		public const string UpdatePanel = "UpdatePanel";

	}
	public partial class MVCMap 
	{
		public static System.Collections.Generic.Dictionary<string, System.Type> map = 
		new System.Collections.Generic.Dictionary<string, System.Type>()
		{

			{ UpdatePanel ,typeof(EasyMoba.UpdatePanelView)},

		}
;	 }
}
