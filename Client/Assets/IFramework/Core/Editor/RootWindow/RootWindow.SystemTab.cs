/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.51
 *UnityVersion:   2018.4.24f1
 *Date:           2020-09-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEngine;

#pragma warning disable
namespace IFramework
{
    partial class RootWindow
    {
        class SystemTab : UserOptionTab
        {
            public override string Name => "System";
            public override void OnGUI(Rect position)
            {
                GUILayout.BeginVertical("Box");

                GUILayout.Label("操作系统：" + SystemInfo.operatingSystem);
                GUILayout.Label("系统内存：" + SystemInfo.systemMemorySize + "MB");
                GUILayout.Label("处理器：" + SystemInfo.processorType);
                GUILayout.Label("处理器数量：" + SystemInfo.processorCount);
                GUILayout.Label("显卡：" + SystemInfo.graphicsDeviceName);
                GUILayout.Label("显卡类型：" + SystemInfo.graphicsDeviceType);
                GUILayout.Label("显存：" + SystemInfo.graphicsMemorySize + "MB");
                GUILayout.Label("显卡标识：" + SystemInfo.graphicsDeviceID);
                GUILayout.Label("显卡供应商：" + SystemInfo.graphicsDeviceVendor);
                GUILayout.Label("显卡供应商标识码：" + SystemInfo.graphicsDeviceVendorID);
                GUILayout.Label("设备模式：" + SystemInfo.deviceModel);
                GUILayout.Label("设备名称：" + SystemInfo.deviceName);
                GUILayout.Label("设备类型：" + SystemInfo.deviceType);
                GUILayout.Label("设备标识：" + SystemInfo.deviceUniqueIdentifier);

                GUILayout.Label("DPI：" + Screen.dpi);
                GUILayout.Label("分辨率：" + Screen.currentResolution.ToString());
                GUILayout.EndVertical();


                GUILayout.FlexibleSpace();

                GUILayout.BeginHorizontal();
                {
                    OpenFolderGUI("Open Doc", Application.persistentDataPath);
                    OpenFolderGUI("Open Streaming", Application.streamingAssetsPath);
                    OpenFolderGUI("Open DataPath", Application.dataPath);
                    OpenFolderGUI("Open Temporary", Application.temporaryCachePath);

                    GUILayout.EndHorizontal();
                }

#if UNITY_2018_1_OR_NEWER

                OpenFolderGUI("Open Console", Application.consoleLogPath);

#endif
                GUILayout.Space(10);
            }
            private void OpenFolderGUI(string name, string path)
            {
                if (GUILayout.Button(name))
                {
                    EditorTools.OpenFolder(path);
                }
            }
        }


    }

}
