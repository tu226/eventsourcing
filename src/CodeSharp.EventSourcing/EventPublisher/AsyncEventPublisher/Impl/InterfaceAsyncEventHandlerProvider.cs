﻿//Copyright (c) CodeSharp.  All rights reserved.

using System;
using System.Reflection;

namespace CodeSharp.EventSourcing
{
    /// <summary>
    /// 标记某个类是一个异步事件订阅者
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IAsyncEventSubscriber<TEvent> where TEvent : class
    {
        void Handle(TEvent evnt);
    }
    /// <summary>
    /// 异步事件处理函数元数据提供者，事件处理函数基于接口规定
    /// </summary>
    public class InterfaceAsyncEventHandlerProvider : InterfaceBasedEventHandlerProvider<EventHandlerMetaData>, IAsyncEventHandlerProvider
    {
        protected override Type EventSubscriberInterfaceType
        {
            get { return typeof(IAsyncEventSubscriber<>); }
        }
        protected override EventHandlerMetaData CreateMetaData(Type subscriberType, MethodInfo eventHandler)
        {
            return new EventHandlerMetaData { SubscriberType = subscriberType, EventHandler = eventHandler };
        }
    }
}
