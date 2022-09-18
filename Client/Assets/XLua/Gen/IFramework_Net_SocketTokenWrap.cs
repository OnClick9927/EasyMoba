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
    public class IFrameworkNetSocketTokenWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.SocketToken);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendAsync", _m_SendAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DisconnectAsync", _m_DisconnectAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CompareTo", _m_CompareTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Send", _m_Send);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "TokenId", _g_get_TokenId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TokenSocket", _g_get_TokenSocket);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TokenIpEndPoint", _g_get_TokenIpEndPoint);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "TokenId", _s_set_TokenId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TokenSocket", _s_set_TokenSocket);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TokenIpEndPoint", _s_set_TokenIpEndPoint);
            
			
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
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					int _id = LuaAPI.xlua_tointeger(L, 2);
					
					IFramework.Net.SocketToken gen_ret = new IFramework.Net.SocketToken(_id);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					IFramework.Net.SocketToken gen_ret = new IFramework.Net.SocketToken();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.SocketToken constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Close(  );
                    
                    
                    
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
            
            
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Net.Sockets.SocketAsyncEventArgs _args = (System.Net.Sockets.SocketAsyncEventArgs)translator.GetObject(L, 2, typeof(System.Net.Sockets.SocketAsyncEventArgs));
                    
                        bool gen_ret = gen_to_be_invoked.SendAsync( _args );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DisconnectAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Net.Sockets.SocketAsyncEventArgs _args = (System.Net.Sockets.SocketAsyncEventArgs)translator.GetObject(L, 2, typeof(System.Net.Sockets.SocketAsyncEventArgs));
                    
                        bool gen_ret = gen_to_be_invoked.DisconnectAsync( _args );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Net.SocketToken _sToken = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
                    
                        int gen_ret = gen_to_be_invoked.CompareTo( _sToken );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Net.SegmentOffset _dataSegment = (IFramework.Net.SegmentOffset)translator.GetObject(L, 2, typeof(IFramework.Net.SegmentOffset));
                    
                        int gen_ret = gen_to_be_invoked.Send( _dataSegment );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TokenId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TokenId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TokenSocket(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TokenSocket);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TokenIpEndPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TokenIpEndPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TokenId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TokenId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TokenSocket(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TokenSocket = (System.Net.Sockets.Socket)translator.GetObject(L, 2, typeof(System.Net.Sockets.Socket));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TokenIpEndPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SocketToken gen_to_be_invoked = (IFramework.Net.SocketToken)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TokenIpEndPoint = (System.Net.IPEndPoint)translator.GetObject(L, 2, typeof(System.Net.IPEndPoint));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
