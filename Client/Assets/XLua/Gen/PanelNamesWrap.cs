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
    public class PanelNamesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PanelNames);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 5, 5);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MatchPanel", _g_get_MatchPanel);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "LoadScenePanel", _g_get_LoadScenePanel);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MainPanel", _g_get_MainPanel);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "LoginPanel", _g_get_LoginPanel);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UpdatePanel", _g_get_UpdatePanel);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "MatchPanel", _s_set_MatchPanel);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "LoadScenePanel", _s_set_LoadScenePanel);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "MainPanel", _s_set_MainPanel);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "LoginPanel", _s_set_LoginPanel);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "UpdatePanel", _s_set_UpdatePanel);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new PanelNames();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PanelNames constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MatchPanel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, PanelNames.MatchPanel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadScenePanel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, PanelNames.LoadScenePanel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainPanel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, PanelNames.MainPanel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoginPanel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, PanelNames.LoginPanel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpdatePanel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, PanelNames.UpdatePanel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MatchPanel(RealStatePtr L)
        {
		    try {
                
			    PanelNames.MatchPanel = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoadScenePanel(RealStatePtr L)
        {
		    try {
                
			    PanelNames.LoadScenePanel = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MainPanel(RealStatePtr L)
        {
		    try {
                
			    PanelNames.MainPanel = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoginPanel(RealStatePtr L)
        {
		    try {
                
			    PanelNames.LoginPanel = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UpdatePanel(RealStatePtr L)
        {
		    try {
                
			    PanelNames.UpdatePanel = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
