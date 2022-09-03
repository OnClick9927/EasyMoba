/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using System;

namespace EasyMoba
{
	public partial class UpdatePanelView
	{
		private MobaAssetsUpdate update { get { return MobaGame.Instance.modules.update; } }

		protected override void OnLoad()
		{
			update.beginDownLoad += Update_beginDownLoad;
			update.downLoadProgress += Update_downLoadProgress;
			update.endDownLoad += Update_endDownLoad;
			update.beginPrepare += Update_beginPrepare;
			update.prepareProgress += Update_prepareProgress;
			update.endPrepare += Update_endPrepare;
		}

        private void Update_endPrepare()
        {
			MobaGame.Instance.StartGame();
		}

        private void Update_prepareProgress(float obj)
        {
			this.Progress.value = obj;
		}

        private void Update_beginPrepare()
        {
        }

        private void Update_endDownLoad()
        {
        }

        private void Update_downLoadProgress(float obj)
        {
			this.Progress.value = obj;

		}

		private void Update_beginDownLoad()
        {
        }

        protected override void OnShow()
		{

		}

		protected override void OnHide()
		{
		}

		protected override void OnClose()
		{
			update.beginDownLoad -= Update_beginDownLoad;
			update.downLoadProgress -= Update_downLoadProgress;
			update.endDownLoad -= Update_endDownLoad;
			update.beginPrepare -= Update_beginPrepare;
			update.prepareProgress -= Update_prepareProgress;
			update.endPrepare -= Update_endPrepare;
		}

	}
}