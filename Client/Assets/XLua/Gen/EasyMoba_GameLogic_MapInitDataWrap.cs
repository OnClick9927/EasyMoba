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
    public class EasyMobaGameLogicMapInitDataWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.MapInitData);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 3, 3);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "ps", _g_get_ps);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cs", _g_get_cs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bornPos", _g_get_bornPos);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "ps", _s_set_ps);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cs", _s_set_cs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bornPos", _s_set_bornPos);
            
			
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
					
					var gen_ret = new EasyMoba.GameLogic.MapInitData();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.MapInitData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ps(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.MapInitData gen_to_be_invoked = (EasyMoba.GameLogic.MapInitData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ps);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.MapInitData gen_to_be_invoked = (EasyMoba.GameLogic.MapInitData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bornPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.MapInitData gen_to_be_invoked = (EasyMoba.GameLogic.MapInitData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bornPos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ps(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.MapInitData gen_to_be_invoked = (EasyMoba.GameLogic.MapInitData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ps = (EasyMoba.GameLogic.MapInitData.PolygonData[])translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.MapInitData.PolygonData[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.MapInitData gen_to_be_invoked = (EasyMoba.GameLogic.MapInitData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cs = (EasyMoba.GameLogic.MapInitData.CircleData[])translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.MapInitData.CircleData[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bornPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.MapInitData gen_to_be_invoked = (EasyMoba.GameLogic.MapInitData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bornPos = (LockStep.Math.LVector2[])translator.GetObject(L, 2, typeof(LockStep.Math.LVector2[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
