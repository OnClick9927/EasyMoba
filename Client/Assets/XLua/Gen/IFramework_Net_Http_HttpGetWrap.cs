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
    public class IFrameworkNetHttpHttpGetWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.Http.HttpGet);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDo", _m_GetDo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Response", _m_Response);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Request", _m_Request);
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<IFramework.Net.Http.HttpHeader>(L, 2))
				{
					IFramework.Net.Http.HttpHeader _header = (IFramework.Net.Http.HttpHeader)translator.GetObject(L, 2, typeof(IFramework.Net.Http.HttpHeader));
					
					IFramework.Net.Http.HttpGet gen_ret = new IFramework.Net.Http.HttpGet(_header);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.Http.HttpGet constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.Http.HttpGet gen_to_be_invoked = (IFramework.Net.Http.HttpGet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Net.SegmentToken _sToken = (IFramework.Net.SegmentToken)translator.GetObject(L, 2, typeof(IFramework.Net.SegmentToken));
                    
                        IFramework.Net.Http.HttpPayload gen_ret = gen_to_be_invoked.GetDo( _sToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Response(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.Http.HttpGet gen_to_be_invoked = (IFramework.Net.Http.HttpGet)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<IFramework.Net.Http.HttpStatusCode>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    string _content = LuaAPI.lua_tostring(L, 2);
                    IFramework.Net.Http.HttpStatusCode _statusCode;translator.Get(L, 3, out _statusCode);
                    string _contentType = LuaAPI.lua_tostring(L, 4);
                    
                        string gen_ret = gen_to_be_invoked.Response( _content, _statusCode, _contentType );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<IFramework.Net.Http.HttpStatusCode>(L, 3)) 
                {
                    string _content = LuaAPI.lua_tostring(L, 2);
                    IFramework.Net.Http.HttpStatusCode _statusCode;translator.Get(L, 3, out _statusCode);
                    
                        string gen_ret = gen_to_be_invoked.Response( _content, _statusCode );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _content = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.Response( _content );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.Http.HttpGet.Response!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Request(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.Http.HttpGet gen_to_be_invoked = (IFramework.Net.Http.HttpGet)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.Request(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
