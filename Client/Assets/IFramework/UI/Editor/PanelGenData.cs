/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.135
 *UnityVersion:   2018.4.24f1
 *Date:           2021-06-28
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IFramework.UI
{

    [System.Serializable]
    public class PanelGenData
    {
        [System.Serializable]
        public class NameMap
        {
            public string panelName;
            public string content;
        }
        public string MapName = "";
        public string ns = "";
        public string workspace = "";
        public List<NameMap> map = new List<NameMap>();

        public void AddMap(string name, string content)
        {
            var temp = map.Find(item => item.panelName == name);
            if (temp != null)
            {
                map.Remove(temp);
            }
            map.Add(new NameMap() { panelName = name, content = content });
        }
        public void RemoveMap(string name)
        {
            map.RemoveAll(item => item.panelName == name);
        }
        static string GetStringMD5(string str)
        {
            MD5CryptoServiceProvider md5CSP = new MD5CryptoServiceProvider();
            byte[] retVal = md5CSP.ComputeHash(Encoding.Default.GetBytes(str));
            string retStr = "";

            for (int i = 0; i < retVal.Length; i++)
            {
                retStr += retVal[i].ToString("x2");
            }

            return retStr;
        }
        public static T CheckExist<T>(string work) where T: PanelGenData,new ()
        {
            string name = GetStringMD5(work);
            string path = EditorEnv.projectMemoryPath;
            path = path.CombinePath($"{typeof(T)}{name}.json");
            if (!File.Exists(path))
            {
                var data = new T() { workspace = work };
                data.Save();
                return data;
            }
            var str = File.ReadAllText(path);
            return UnityEngine.JsonUtility.FromJson<T>(str);
        }
        public void Save()
        {
            string name = GetStringMD5(workspace);
            string path = EditorEnv.projectMemoryPath;
            path = path.CombinePath($"{GetType()}{name}.json");
            File.WriteAllText(path, UnityEngine.JsonUtility.ToJson(this,true));
            UnityEditor.AssetDatabase.Refresh();
        }
    }
}
