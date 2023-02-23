﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static IFramework.Hotfix.Asset.AssetsSetting;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {
        public class CheckBundleVersionOperation : AssetOperation
        {
            private float _progress;
            public override float progress
            {
                get
                {
                    if (isDone) return 1;
                    return _progress * 0.5f + downloader.progress * 0.5f;
                }
            }
            private string url;
            public List<AssetsVersion.VersionData> downLoadOnes { get; private set; }
            public List<string> unUseBundles { get; private set; }

            public CheckBundleVersionOperation()
            {
                this.url = AssetsInternal.GetVersionUrl();
                downLoadOnes = new List<AssetsVersion.VersionData>();
                Done();
            }

            private Downloader downloader;
            private async void Done()
            {
                downloader = new Downloader(url);
                await downloader.Start();
                if (downloader.isError)
                {
                    SetErr(downloader.error);
                }
                else
                {
                    unUseBundles = new List<string>(AssetsInternal.GetLocalBundles());
                    var txt = downloader.text;
                    AssetsVersion remote = JsonUtility.FromJson<AssetsVersion>(txt);
                    for (int i = 0; i < remote.versions.Count; i++)
                    {
                        _progress = i / (float)remote.versions.Count;
                        var item = remote.versions[i];
                        var bundleName = item.bundleName;
                        var localPath = AssetsInternal.GetBundleLocalPath(bundleName).ToRegularPath();
                        if (!File.Exists(localPath)) downLoadOnes.Add(item);
                        else
                        {
                            if (unUseBundles.Contains(localPath))
                                unUseBundles.Remove(localPath);
                            FileCheckType type = AssetsInternal.GetFileCheckType();
                            if (type == FileCheckType.MD5)
                            {
                                var md5 = item.md5;
                                var localMD5 = AssetsInternal.GetFileMD5(localPath);
                                if (localMD5 != md5)
                                    downLoadOnes.Add(item);
                            }
                            else
                            {
                                var length = item.length;
                                FileInfo file = new FileInfo(localPath);
                                var localLenght = file.Length;
                                if (length != localLenght)
                                    downLoadOnes.Add(item);
                            }

                        }
                    }
                }
                InvokeComplete();
            }
        }
    }
}
