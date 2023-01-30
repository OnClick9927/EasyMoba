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
    public class IFrameworkNetNetToolWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.NetTool);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 14, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatePacketsProvider", _m_CreatePacketsProvider_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateProtocolProvider", _m_CreateProtocolProvider_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateTokenPoolProvider", _m_CreateTokenPoolProvider_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateTcpClient", _m_CreateTcpClient_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateTcpSever", _m_CreateTcpSever_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateUdpClient", _m_CreateUdpClient_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateUdpSever", _m_CreateUdpSever_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateWSClient", _m_CreateWSClient_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateWSSever", _m_CreateWSSever_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateHttpSever", _m_CreateHttpSever_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLoacalIpv4", _m_GetLoacalIpv4_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLoacalIpv6", _m_GetLoacalIpv6_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetOutSideIP", _m_GetOutSideIP_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "IFramework.Net.NetTool does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePacketsProvider_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _capacity = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreatePacketsProvider( _capacity );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreatePacketsProvider(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreatePacketsProvider!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateProtocolProvider_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateProtocolProvider(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateTokenPoolProvider_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _taskExecutePeriod = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTokenPoolProvider( _taskExecutePeriod );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTokenPoolProvider(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateTokenPoolProvider!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateTcpClient_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _sendConcurrentSize = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTcpClient( _chunkBufferSize, _sendConcurrentSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTcpClient( _chunkBufferSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTcpClient(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateTcpClient!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateTcpSever_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _maxNumberOfConnections = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTcpSever( _chunkBufferSize, _maxNumberOfConnections );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTcpSever( _chunkBufferSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateTcpSever(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateTcpSever!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateUdpClient_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _sendConcurrentSize = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpClient( _chunkBufferSize, _sendConcurrentSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpClient( _chunkBufferSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpClient(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateUdpClient!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateUdpSever_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _maxNumberOfConnections = LuaAPI.xlua_tointeger(L, 2);
                    bool _broadcast = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpSever( _chunkBufferSize, _maxNumberOfConnections, _broadcast );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _maxNumberOfConnections = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpSever( _chunkBufferSize, _maxNumberOfConnections );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpSever( _chunkBufferSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateUdpSever(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateUdpSever!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateWSClient_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _sendConcurrentSize = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateWSClient( _chunkBufferSize, _sendConcurrentSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateWSClient( _chunkBufferSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateWSClient(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateWSClient!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateWSSever_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    int _maxNumberOfConnections = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateWSSever( _chunkBufferSize, _maxNumberOfConnections );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _chunkBufferSize = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateWSSever( _chunkBufferSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateWSSever(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateWSSever!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateHttpSever_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _maxPoolCount = LuaAPI.xlua_tointeger(L, 1);
                    int _blockSize = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateHttpSever( _maxPoolCount, _blockSize );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _maxPoolCount = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.NetTool.CreateHttpSever( _maxPoolCount );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = IFramework.Net.NetTool.CreateHttpSever(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.NetTool.CreateHttpSever!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLoacalIpv4_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Net.NetTool.GetLoacalIpv4(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLoacalIpv6_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Net.NetTool.GetLoacalIpv6(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOutSideIP_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Net.NetTool.GetOutSideIP(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
