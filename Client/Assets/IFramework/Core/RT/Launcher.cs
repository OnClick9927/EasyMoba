﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.115
 *UnityVersion:   2018.4.24f1
 *Date:           2020-11-29
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using IFramework.Singleton;
using System;
using UnityEngine;

namespace IFramework
{
    [MonoSingletonPath("IFramework/Launcher")]
    public class Launcher : MonoSingleton<Launcher>
    {
        [Header("Can't be Null")]
        private Game _game;
        public Game game
        {
            get { return _game; }
            set
            {
                _game = value;
                if (_game != null)
                {
                    _game.Init();
                    _game.Startup();
                }
            }
        }
        public static EnvironmentType envType;

        public static IEnvironment env { get { return Framework.GetEnv(envType); } }
        public static IModules modules { get { return env.modules; } }

        private static event Action onFixUpdate;
        private static event Action onLateUpdate;
        private static event Action<bool> onApplicationFocus;
        private static event Action<bool> onApplicationPause;




        private void Awake()
        {
            Framework.CreateEnv(envType).InitWithAttribute();
        }
        private void OnDisable()
        {
            Framework.DisposeEnv(envType);
        }

        private void Update()
        {
            env.Update();
        }
        private void FixedUpdate()
        {
            if (onFixUpdate != null)
            {
                onFixUpdate();
            }
        }

        private void LateUpdate()
        {
            if (onLateUpdate != null)
            {
                onLateUpdate();
            }
        }
        private void OnApplicationFocus(bool focus)
        {
            if (onApplicationFocus != null)
            {
                onApplicationFocus(focus);
            }
        }
        private void OnApplicationPause(bool pause)
        {
            if (onApplicationPause != null)
            {
                onApplicationPause(pause);
            }
        }


        public static void BindFixedUpdate(Action action)
        {
            onFixUpdate += action;
        }
        public static void UnBindFixedUpdate(Action action)
        {
            onFixUpdate -= action;
        }
        public static void BindLateUpdate(Action action)
        {
            onLateUpdate += action;
        }
        public static void UnBindLateUpdate(Action action)
        {
            onLateUpdate -= action;
        }
        public static void BindOnApplicationFocus(Action<bool> action)
        {
            onApplicationFocus += action;
        }
        public static void UnBindOnApplicationFocus(Action<bool> action)
        {
            onApplicationFocus -= action;
        }
        public static void BindOnApplicationPause(Action<bool> action)
        {
            onApplicationPause += action;
        }
        public static void UnBindOnApplicationPause(Action<bool> action)
        {
            onApplicationPause -= action;
        }
    }
}
