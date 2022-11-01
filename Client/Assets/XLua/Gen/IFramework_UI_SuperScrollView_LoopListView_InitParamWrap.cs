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
    public class IFrameworkUISuperScrollViewLoopListViewInitParamWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.UI.SuperScrollView.LoopListView.InitParam);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 8, 8);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "distanceForRecycle0", _g_get_distanceForRecycle0);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "distanceForNew0", _g_get_distanceForNew0);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "distanceForRecycle1", _g_get_distanceForRecycle1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "distanceForNew1", _g_get_distanceForNew1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "smoothDumpRate", _g_get_smoothDumpRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "snapFinishThreshold", _g_get_snapFinishThreshold);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "snapVecThreshold", _g_get_snapVecThreshold);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "itemDefaultWithPaddingSize", _g_get_itemDefaultWithPaddingSize);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "distanceForRecycle0", _s_set_distanceForRecycle0);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "distanceForNew0", _s_set_distanceForNew0);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "distanceForRecycle1", _s_set_distanceForRecycle1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "distanceForNew1", _s_set_distanceForNew1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "smoothDumpRate", _s_set_smoothDumpRate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "snapFinishThreshold", _s_set_snapFinishThreshold);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "snapVecThreshold", _s_set_snapVecThreshold);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "itemDefaultWithPaddingSize", _s_set_itemDefaultWithPaddingSize);
            
			
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
					
					IFramework.UI.SuperScrollView.LoopListView.InitParam gen_ret = new IFramework.UI.SuperScrollView.LoopListView.InitParam();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.SuperScrollView.LoopListView.InitParam constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distanceForRecycle0(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distanceForRecycle0);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distanceForNew0(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distanceForNew0);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distanceForRecycle1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distanceForRecycle1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distanceForNew1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distanceForNew1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_smoothDumpRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.smoothDumpRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_snapFinishThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.snapFinishThreshold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_snapVecThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.snapVecThreshold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_itemDefaultWithPaddingSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.itemDefaultWithPaddingSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distanceForRecycle0(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distanceForRecycle0 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distanceForNew0(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distanceForNew0 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distanceForRecycle1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distanceForRecycle1 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distanceForNew1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distanceForNew1 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_smoothDumpRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.smoothDumpRate = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_snapFinishThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.snapFinishThreshold = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_snapVecThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.snapVecThreshold = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_itemDefaultWithPaddingSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView.InitParam gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.itemDefaultWithPaddingSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
