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
	public partial class Panel01ViewModel : IFramework.UI.MVVM.UIViewModel<IFramework.UI.Example.Panel01Model>
	{
 		private System.Int32 _count;
		public System.Int32 count
		{
			get { return GetProperty(ref _count); }
			private set			{
				Tmodel.count = value;
				SetProperty(ref _count, value);
			}
		}


		protected override void SyncModelValue()
		{
 			this.count = Tmodel.count;

		}

	}
}