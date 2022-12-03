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
	public class MVCMap 
	{
		public static System.Collections.Generic.Dictionary<string, System.Type> map = 
		new System.Collections.Generic.Dictionary<string, System.Type>()
		{

			{ "UpdatePanel" ,typeof(EasyMoba.UpdatePanelView)},

		}
;	 }
}
