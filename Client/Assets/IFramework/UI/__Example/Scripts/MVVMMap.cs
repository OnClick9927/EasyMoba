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
	partial class MVVMMap
	{
		public const string Panel01 = "Panel01";

	}
	public partial class MVVMMap 
	{
		public static System.Collections.Generic.Dictionary<string, System.Tuple<System.Type, System.Type, System.Type>> map = 
		new System.Collections.Generic.Dictionary<string, System.Tuple<System.Type, System.Type, System.Type>>()
		{

			{ Panel01 ,System.Tuple.Create(typeof(IFramework.UI.Example.Panel01Model),typeof(IFramework.UI.Example.Panel01View),typeof(IFramework.UI.Example.Panel01ViewModel))},

		}
;	 }
}
