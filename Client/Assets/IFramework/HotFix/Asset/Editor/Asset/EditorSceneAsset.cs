/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IFramework.Hotfix.Asset
{
    public class EditorSceneAsset : SceneAsset
    {
        public EditorSceneAsset(SceneAssetLoadArgs loadArgs) : base(null, null, loadArgs)
        {
        }
        public override float progress { get { return 1; } }

        protected override void OnLoad()
        {
            SetResult(null);
        }
        protected override void OnUnLoad()
        {
        }
        public override void LoadScene(LoadSceneMode mode)
        {
            EditorSceneManager.LoadSceneInPlayMode(path, new LoadSceneParameters()
            {
                loadSceneMode = mode
            });
        }
        public override AsyncOperation LoadSceneAsync(LoadSceneParameters parameters)
        {
            return EditorSceneManager.LoadSceneAsyncInPlayMode(path, parameters);
        }
        public override Scene LoadScene(LoadSceneParameters parameters)
        {
            return EditorSceneManager.LoadSceneInPlayMode(path, parameters);
        }
        public override AsyncOperation LoadSceneAsync(LoadSceneMode mode)
        {
            return EditorSceneManager.LoadSceneAsyncInPlayMode(path, new LoadSceneParameters()
            {
                loadSceneMode = mode
            });
        }
    }
}
