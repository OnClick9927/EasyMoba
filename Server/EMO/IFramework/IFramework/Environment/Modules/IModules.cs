using IFramework.Coroutine;

using IFramework.Inject;
using IFramework.Message;
using IFramework.Recorder;
using IFramework.Timer;
using System;

namespace IFramework
{
    /// <summary>
    /// 模块组
    /// </summary>
    public interface IModules : IContainer, IBelongToEnvironment
    {
        /// <summary>
        /// 协程
        /// </summary>
        ICoroutineModule coroutine { get; }

        /// <summary>
        /// 消息
        /// </summary>
        IMessageModule message { get; }
        /// <summary>
        /// 消息（string 版本）
        /// </summary>
        IStringMessageModule stringMessage { get; }

        /// <summary>
        /// 操作记录
        /// </summary>
        IOperationRecorderModule recoder { get; }
        /// <summary>
        /// 注入模块
        /// </summary>
        IInjectModule inject { get; }
        /// <summary>
        /// 计时器
        /// </summary>
        ITimerModule timer { get; }
       


        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        Module CreateModule(Type type, string name = Module.defaultName, int priority = 0);
        /// <summary>
        /// 创建模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        T CreateModule<T>(string name = Module.defaultName, int priority = 0) where T : Module;
        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        Module GetModule(Type type, string name = Module.defaultName, int priority = 0);
        /// <summary>
        /// 获取模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        T GetModule<T>(string name = Module.defaultName, int priority = 0) where T : Module;
        /// <summary>
        /// 查找模块
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Module FindModule(Type type, string name = Module.defaultName);
        /// <summary>
        /// 查找模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T FindModule<T>(string name = Module.defaultName) where T : Module;
    }
}