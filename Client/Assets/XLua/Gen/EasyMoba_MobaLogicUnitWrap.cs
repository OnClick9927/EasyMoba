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
    public class EasyMobaMobaLogicUnitWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.MobaLogicUnit);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 5, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestory", _m_OnDestory);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "call_1", _g_get_call_1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "call_2", _g_get_call_2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "call_3", _g_get_call_3);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "call_4", _g_get_call_4);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "call_5", _g_get_call_5);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "call_1", _s_set_call_1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "call_2", _s_set_call_2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "call_3", _s_set_call_3);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "call_4", _s_set_call_4);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "call_5", _s_set_call_5);
            
			
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
					
					var gen_ret = new EasyMoba.MobaLogicUnit();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.MobaLogicUnit constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestory(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestory(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_call_1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.call_1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_call_2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.call_2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_call_3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.call_3);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_call_4(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.call_4);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_call_5(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.call_5);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_call_1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.call_1 = translator.GetDelegate<System.Action<EasyMoba.MobaLogicUnit, int, LockStep.Math.LFloat>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_call_2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.call_2 = translator.GetDelegate<System.Action<EasyMoba.MobaLogicUnit, LockStep.LCollision2D.Shape>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_call_3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.call_3 = translator.GetDelegate<System.Action<EasyMoba.MobaLogicUnit, LockStep.LCollision2D.Shape>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_call_4(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.call_4 = translator.GetDelegate<System.Action<EasyMoba.MobaLogicUnit, LockStep.LCollision2D.Shape>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_call_5(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.MobaLogicUnit gen_to_be_invoked = (EasyMoba.MobaLogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.call_5 = translator.GetDelegate<System.Action<EasyMoba.MobaLogicUnit>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
