﻿using System.Runtime.CompilerServices;

namespace IFramework
{
    /// <summary>
    /// 当执行关键代码（此代码中的错误可能给应用程序中的其他状态造成负面影响）时，
    /// 用于给 await 确定异步返回的时机。
    /// </summary>
    public interface ICriticalAwaiter : IAwaiter, ICriticalNotifyCompletion
    {
    }
    /// <summary>
    /// 当执行关键代码（此代码中的错误可能给应用程序中的其他状态造成负面影响）时，
    /// 用于给 await 确定异步返回的时机，并获取到返回值。
    /// </summary>
    /// <typeparam name="TResult">异步返回的返回值类型。</typeparam>
    public interface ICriticalAwaiter<out TResult> : IAwaiter<TResult>, ICriticalNotifyCompletion
    {
    }
}
