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
    public class IFrameworkNetHttpHttpHeaderWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.Http.HttpHeader);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 21, 20);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToHeaderString", _m_ToHeaderString);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Protocol", _g_get_Protocol);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Option", _g_get_Option);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RelativeUri", _g_get_RelativeUri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Host", _g_get_Host);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Connection", _g_get_Connection);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UserAgent", _g_get_UserAgent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Accept", _g_get_Accept);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CacheControl", _g_get_CacheControl);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ContentType", _g_get_ContentType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AcceptEncoding", _g_get_AcceptEncoding);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AcceptLanguage", _g_get_AcceptLanguage);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Referer", _g_get_Referer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Cookie", _g_get_Cookie);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SecFetchUser", _g_get_SecFetchUser);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SecFetchMode", _g_get_SecFetchMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SecFetchSite", _g_get_SecFetchSite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SecFetchDest", _g_get_SecFetchDest);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Extensions", _g_get_Extensions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DNT", _g_get_DNT);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StreamPosition", _g_get_StreamPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ContentLength", _g_get_ContentLength);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Protocol", _s_set_Protocol);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Option", _s_set_Option);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RelativeUri", _s_set_RelativeUri);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Host", _s_set_Host);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Connection", _s_set_Connection);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UserAgent", _s_set_UserAgent);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Accept", _s_set_Accept);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CacheControl", _s_set_CacheControl);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ContentType", _s_set_ContentType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AcceptEncoding", _s_set_AcceptEncoding);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AcceptLanguage", _s_set_AcceptLanguage);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Referer", _s_set_Referer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Cookie", _s_set_Cookie);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SecFetchUser", _s_set_SecFetchUser);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SecFetchMode", _s_set_SecFetchMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SecFetchSite", _s_set_SecFetchSite);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SecFetchDest", _s_set_SecFetchDest);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Extensions", _s_set_Extensions);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DNT", _s_set_DNT);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ContentLength", _s_set_ContentLength);
            
			
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
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _httpContent = LuaAPI.lua_tostring(L, 2);
					
					var gen_ret = new IFramework.Net.Http.HttpHeader(_httpContent);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<IFramework.Net.SegmentOffset>(L, 2))
				{
					IFramework.Net.SegmentOffset _segment = (IFramework.Net.SegmentOffset)translator.GetObject(L, 2, typeof(IFramework.Net.SegmentOffset));
					
					var gen_ret = new IFramework.Net.Http.HttpHeader(_segment);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.Http.HttpHeader constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToHeaderString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Net.Http.HttpStatusCode _httpStatusCode;translator.Get(L, 2, out _httpStatusCode);
                    
                        var gen_ret = gen_to_be_invoked.ToHeaderString( _httpStatusCode );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Protocol(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Protocol);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Option(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Option);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RelativeUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.RelativeUri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Host(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Host);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Connection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Connection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserAgent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.UserAgent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Accept(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Accept);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CacheControl(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.CacheControl);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ContentType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ContentType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AcceptEncoding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.AcceptEncoding);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AcceptLanguage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.AcceptLanguage);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Referer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Referer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Cookie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Cookie);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SecFetchUser(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SecFetchUser);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SecFetchMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SecFetchMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SecFetchSite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SecFetchSite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SecFetchDest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SecFetchDest);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Extensions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Extensions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DNT(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DNT);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StreamPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.StreamPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ContentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.ContentLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Protocol(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Protocol = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Option(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                IFramework.Net.Http.HttpOption gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Option = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RelativeUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RelativeUri = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Host(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Host = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Connection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Connection = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UserAgent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UserAgent = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Accept(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Accept = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CacheControl(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CacheControl = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ContentType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ContentType = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AcceptEncoding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AcceptEncoding = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AcceptLanguage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AcceptLanguage = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Referer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Referer = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Cookie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Cookie = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SecFetchUser(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SecFetchUser = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SecFetchMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SecFetchMode = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SecFetchSite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SecFetchSite = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SecFetchDest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SecFetchDest = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Extensions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Extensions = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DNT(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DNT = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ContentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpHeader gen_to_be_invoked = (IFramework.Net.Http.HttpHeader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ContentLength = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
