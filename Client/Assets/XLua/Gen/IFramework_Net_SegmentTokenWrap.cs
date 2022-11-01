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
    public class IFrameworkNetSegmentTokenWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.SegmentToken);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 2, 2);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "sToken", _g_get_sToken);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "sToken", _s_set_sToken);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Data", _s_set_Data);
            
			
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
					
					IFramework.Net.SegmentToken gen_ret = new IFramework.Net.SegmentToken();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<IFramework.Net.SocketToken>(L, 2))
				{
					IFramework.Net.SocketToken _sToken = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
					
					IFramework.Net.SegmentToken gen_ret = new IFramework.Net.SegmentToken(_sToken);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<IFramework.Net.SocketToken>(L, 2) && translator.Assignable<IFramework.Net.SegmentOffset>(L, 3))
				{
					IFramework.Net.SocketToken _sToken = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
					IFramework.Net.SegmentOffset _data = (IFramework.Net.SegmentOffset)translator.GetObject(L, 3, typeof(IFramework.Net.SegmentOffset));
					
					IFramework.Net.SegmentToken gen_ret = new IFramework.Net.SegmentToken(_sToken, _data);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<IFramework.Net.SocketToken>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					IFramework.Net.SocketToken _sToken = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
					byte[] _buffer = LuaAPI.lua_tobytes(L, 3);
					
					IFramework.Net.SegmentToken gen_ret = new IFramework.Net.SegmentToken(_sToken, _buffer);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<IFramework.Net.SocketToken>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))
				{
					IFramework.Net.SocketToken _sToken = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
					byte[] _buffer = LuaAPI.lua_tobytes(L, 3);
					int _offset = LuaAPI.xlua_tointeger(L, 4);
					int _size = LuaAPI.xlua_tointeger(L, 5);
					
					IFramework.Net.SegmentToken gen_ret = new IFramework.Net.SegmentToken(_sToken, _buffer, _offset, _size);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.SegmentToken constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sToken(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SegmentToken gen_to_be_invoked = (IFramework.Net.SegmentToken)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.sToken);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SegmentToken gen_to_be_invoked = (IFramework.Net.SegmentToken)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sToken(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SegmentToken gen_to_be_invoked = (IFramework.Net.SegmentToken)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sToken = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.SegmentToken gen_to_be_invoked = (IFramework.Net.SegmentToken)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Data = (IFramework.Net.SegmentOffset)translator.GetObject(L, 2, typeof(IFramework.Net.SegmentOffset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
