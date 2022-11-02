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
    public class EasyMobaNormalModePlayerUdpClientWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.NormalModePlayer.UdpClient);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateClient", _m_CreateClient);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendBattleFrame", _m_SendBattleFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseUdp", _m_CloseUdp);
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING) && translator.Assignable<EasyMoba.NormalModePlayer>(L, 5))
				{
					int _port = LuaAPI.xlua_tointeger(L, 2);
					int _bufsize = LuaAPI.xlua_tointeger(L, 3);
					string _ip = LuaAPI.lua_tostring(L, 4);
					EasyMoba.NormalModePlayer _player = (EasyMoba.NormalModePlayer)translator.GetObject(L, 5, typeof(EasyMoba.NormalModePlayer));
					
					EasyMoba.NormalModePlayer.UdpClient gen_ret = new EasyMoba.NormalModePlayer.UdpClient(_port, _bufsize, _ip, _player);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.NormalModePlayer.UdpClient constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateClient(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.NormalModePlayer.UdpClient gen_to_be_invoked = (EasyMoba.NormalModePlayer.UdpClient)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CreateClient(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendBattleFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.NormalModePlayer.UdpClient gen_to_be_invoked = (EasyMoba.NormalModePlayer.UdpClient)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _roomid = LuaAPI.lua_tostring(L, 2);
                    long _roleid = LuaAPI.lua_toint64(L, 3);
                    int _frame = LuaAPI.xlua_tointeger(L, 4);
                    FrameData _op = (FrameData)translator.GetObject(L, 5, typeof(FrameData));
                    
                    gen_to_be_invoked.SendBattleFrame( _roomid, _roleid, _frame, _op );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseUdp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.NormalModePlayer.UdpClient gen_to_be_invoked = (EasyMoba.NormalModePlayer.UdpClient)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CloseUdp(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
