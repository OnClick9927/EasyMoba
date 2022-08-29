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
	partial class MVCMap
	{
		public const string Panel02 = "Panel02";

	}
	public partial class MVCMap 
	{
		public static System.Collections.Generic.Dictionary<string, System.Type> map = 
		new System.Collections.Generic.Dictionary<string, System.Type>()
		{

			{ Panel02 ,typeof(IFramework.UI.Example.Panel02View)},

		}
;	 }
}
