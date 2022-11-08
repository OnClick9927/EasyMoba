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
    public class IFrameworkBindableObjectHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.BindableObjectHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetValue", _m_GetValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PublishProperty", _m_PublishProperty);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnBind", _m_UnBind);
			
			
			
			
			
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
					
					var gen_ret = new IFramework.BindableObjectHandler();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.BindableObjectHandler constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.BindableObjectHandler gen_to_be_invoked = (IFramework.BindableObjectHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string _name = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.GetValue( _type, _name );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PublishProperty(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.BindableObjectHandler gen_to_be_invoked = (IFramework.BindableObjectHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    object _value = translator.GetObject(L, 3, typeof(object));
                    string _propertyName = LuaAPI.lua_tostring(L, 4);
                    
                        var gen_ret = gen_to_be_invoked.PublishProperty( _type, _value, _propertyName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnBind(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.BindableObjectHandler gen_to_be_invoked = (IFramework.BindableObjectHandler)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.UnBind(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<IFramework.BindableObject>(L, 2)) 
                {
                    IFramework.BindableObject __object = (IFramework.BindableObject)translator.GetObject(L, 2, typeof(IFramework.BindableObject));
                    
                    gen_to_be_invoked.UnBind( __object );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _propertyName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.UnBind( _propertyName );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<IFramework.BindableObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    IFramework.BindableObject __object = (IFramework.BindableObject)translator.GetObject(L, 2, typeof(IFramework.BindableObject));
                    string _propertyName = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.UnBind( __object, _propertyName );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<IFramework.BindableObject>(L, 2)&& translator.Assignable<System.Type>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    IFramework.BindableObject __object = (IFramework.BindableObject)translator.GetObject(L, 2, typeof(IFramework.BindableObject));
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    string _propertyName = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.UnBind( __object, _type, _propertyName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.BindableObjectHandler.UnBind!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
