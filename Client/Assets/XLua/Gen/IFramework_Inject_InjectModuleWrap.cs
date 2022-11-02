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
    public class IFrameworkInjectInjectModuleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Inject.InjectModule);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Inject", _m_Inject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InjectInstances", _m_InjectInstances);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Subscribe", _m_Subscribe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SubscribeInstance", _m_SubscribeInstance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetValue", _m_GetValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetValues", _m_GetValues);
			
			
			
			
			
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
					
					var gen_ret = new IFramework.Inject.InjectModule();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Inject.InjectModule constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Inject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _obj = translator.GetObject(L, 2, typeof(object));
                    
                    gen_to_be_invoked.Inject( _obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InjectInstances(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InjectInstances(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Subscribe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<System.Type>(L, 2)&& translator.Assignable<System.Type>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type _source = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    System.Type _target = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    string _name = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.Subscribe( _source, _target, _name );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& translator.Assignable<System.Type>(L, 3)) 
                {
                    System.Type _source = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    System.Type _target = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    
                    gen_to_be_invoked.Subscribe( _source, _target );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Inject.InjectModule.Subscribe!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeInstance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<System.Type>(L, 2)&& translator.Assignable<object>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    System.Type _baseType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    object _instance = translator.GetObject(L, 3, typeof(object));
                    string _name = LuaAPI.lua_tostring(L, 4);
                    bool _inject = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.SubscribeInstance( _baseType, _instance, _name, _inject );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<System.Type>(L, 2)&& translator.Assignable<object>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type _baseType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    object _instance = translator.GetObject(L, 3, typeof(object));
                    string _name = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.SubscribeInstance( _baseType, _instance, _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Inject.InjectModule.SubscribeInstance!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count >= 3&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 4) || translator.Assignable<object>(L, 4))) 
                {
                    System.Type _baseType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string _name = LuaAPI.lua_tostring(L, 3);
                    object[] _constructorArgs = translator.GetParams<object>(L, 4);
                    
                        var gen_ret = gen_to_be_invoked.GetValue( _baseType, _name, _constructorArgs );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 2&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type _baseType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string _name = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.GetValue( _baseType, _name );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 1&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type _baseType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        var gen_ret = gen_to_be_invoked.GetValue( _baseType );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Inject.InjectModule.GetValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetValues(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Inject.InjectModule gen_to_be_invoked = (IFramework.Inject.InjectModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        var gen_ret = gen_to_be_invoked.GetValues( _type );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
