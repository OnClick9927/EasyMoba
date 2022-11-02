#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class IFrameworkTimerTimerEntityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Timer.TimerEntity);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 5, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SubscribeStart", _m_SubscribeStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnSubscribeStart", _m_UnSubscribeStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SubsribeUpdate", _m_SubsribeUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnSubsribeUpdate", _m_UnSubsribeUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SubscribeComplete", _m_SubscribeComplete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnSubscribeComplete", _m_UnSubscribeComplete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Cancel", _m_Cancel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Pause", _m_Pause);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Start", _m_Start);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetInnerTimer", _m_SetInnerTimer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Subscribe", _m_Subscribe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTimeScale", _m_SetTimeScale);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "repeatDelay", _g_get_repeatDelay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "delay", _g_get_delay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "repeat", _g_get_repeat);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "timeScale", _g_get_timeScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "state", _g_get_state);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new IFramework.Timer.TimerEntity();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Timer.TimerEntity constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeStart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _startAction = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.SubscribeStart( _startAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnSubscribeStart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _startAction = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.UnSubscribeStart( _startAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubsribeUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _updateAction = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.SubsribeUpdate( _updateAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnSubsribeUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _updateAction = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.UnSubsribeUpdate( _updateAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeComplete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _completeAction = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.SubscribeComplete( _completeAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnSubscribeComplete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action _completeAction = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.UnSubscribeComplete( _completeAction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cancel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _callComplete = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Cancel( _callComplete );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Pause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _deltaTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.Update( _deltaTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInnerTimer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<IFramework.Timer.ITimerEntity>(L, 2)&& translator.Assignable<IFramework.Timer.InnerType>(L, 3)) 
                {
                    IFramework.Timer.ITimerEntity _timerEntity = (IFramework.Timer.ITimerEntity)translator.GetObject(L, 2, typeof(IFramework.Timer.ITimerEntity));
                    IFramework.Timer.InnerType _type;translator.Get(L, 3, out _type);
                    
                    gen_to_be_invoked.SetInnerTimer( _timerEntity, _type );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<IFramework.Timer.ITimerEntity>(L, 2)) 
                {
                    IFramework.Timer.ITimerEntity _timerEntity = (IFramework.Timer.ITimerEntity)translator.GetObject(L, 2, typeof(IFramework.Timer.ITimerEntity));
                    
                    gen_to_be_invoked.SetInnerTimer( _timerEntity );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Timer.TimerEntity.SetInnerTimer!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Subscribe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Subscribe(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTimeScale(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _scale = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetTimeScale( _scale );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_repeatDelay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.repeatDelay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_delay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.delay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_repeat(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.repeat);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_timeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.timeScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_state(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Timer.TimerEntity gen_to_be_invoked = (IFramework.Timer.TimerEntity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.state);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
