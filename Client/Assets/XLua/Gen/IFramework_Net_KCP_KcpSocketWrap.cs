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
    public class IFrameworkNetKCPKcpSocketWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.KCP.KcpSocket);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 3, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Connect", _m_Connect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Send", _m_Send);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "onMessage", _e_onMessage);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "socket", _g_get_socket);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "remotePoint", _g_get_remotePoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localPoint", _g_get_localPoint);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "remotePoint", _s_set_remotePoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "localPoint", _s_set_localPoint);
            
			
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
					
					var gen_ret = new IFramework.Net.KCP.KcpSocket();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.KcpSocket constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Connect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _host = LuaAPI.lua_tostring(L, 2);
                    int _port = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.Connect( _host, _port );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.Send( _buffer, _length );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_socket(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.socket);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_remotePoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.remotePoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_remotePoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.remotePoint = (System.Net.IPEndPoint)translator.GetObject(L, 2, typeof(System.Net.IPEndPoint));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.localPoint = (System.Net.IPEndPoint)translator.GetObject(L, 2, typeof(System.Net.IPEndPoint));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onMessage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			IFramework.Net.KCP.KcpSocket gen_to_be_invoked = (IFramework.Net.KCP.KcpSocket)translator.FastGetCSObj(L, 1);
                System.Action<byte[], int, int> gen_delegate = translator.GetDelegate<System.Action<byte[], int, int>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<byte[], int, int>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.onMessage += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.onMessage -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.KcpSocket.onMessage!");
            return 0;
        }
        
		
		
    }
}
