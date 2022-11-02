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
    public class EasyMobaBattleModePlayerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.BattleModePlayer);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CallServerReady", _m_CallServerReady);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendFrameToServer", _m_SendFrameToServer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "type", _g_get_type);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roles", _g_get_roles);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "type", _s_set_type);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roles", _s_set_roles);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Create", _m_Create_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "EasyMoba.BattleModePlayer does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Create_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    EasyMoba.BattlePlayMode _mode;translator.Get(L, 1, out _mode);
                    MatchRoomType _type;translator.Get(L, 2, out _type);
                    System.Collections.Generic.List<long> _roles = (System.Collections.Generic.List<long>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<long>));
                    
                        var gen_ret = EasyMoba.BattleModePlayer.Create( _mode, _type, _roles );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CallServerReady(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _role_id = LuaAPI.lua_toint64(L, 2);
                    string _room_id = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.CallServerReady( _role_id, _room_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendFrameToServer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SendFrameToServer(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
                translator.PushMatchRoomType(L, gen_to_be_invoked.type);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.roles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
                MatchRoomType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.type = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.BattleModePlayer gen_to_be_invoked = (EasyMoba.BattleModePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roles = (System.Collections.Generic.List<long>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<long>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
