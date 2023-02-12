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
    public class IFrameworkCoroutineCoroutineModuleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Coroutine.CoroutineModule);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateCoroutine", _m_CreateCoroutine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartCoroutine", _m_StartCoroutine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PauseCoroutine", _m_PauseCoroutine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResumeCoroutine", _m_ResumeCoroutine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopCoroutine", _m_StopCoroutine);
			
			
			
			
			
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
					
					var gen_ret = new IFramework.Coroutine.CoroutineModule();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Coroutine.CoroutineModule constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateCoroutine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Coroutine.CoroutineModule gen_to_be_invoked = (IFramework.Coroutine.CoroutineModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.IEnumerator _routine = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
                    
                        var gen_ret = gen_to_be_invoked.CreateCoroutine( _routine );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartCoroutine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Coroutine.CoroutineModule gen_to_be_invoked = (IFramework.Coroutine.CoroutineModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.IEnumerator _routine = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
                    
                        var gen_ret = gen_to_be_invoked.StartCoroutine( _routine );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseCoroutine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Coroutine.CoroutineModule gen_to_be_invoked = (IFramework.Coroutine.CoroutineModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Coroutine.ICoroutine _coroutine = (IFramework.Coroutine.ICoroutine)translator.GetObject(L, 2, typeof(IFramework.Coroutine.ICoroutine));
                    
                    gen_to_be_invoked.PauseCoroutine( _coroutine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResumeCoroutine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Coroutine.CoroutineModule gen_to_be_invoked = (IFramework.Coroutine.CoroutineModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Coroutine.ICoroutine _coroutine = (IFramework.Coroutine.ICoroutine)translator.GetObject(L, 2, typeof(IFramework.Coroutine.ICoroutine));
                    
                    gen_to_be_invoked.ResumeCoroutine( _coroutine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopCoroutine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Coroutine.CoroutineModule gen_to_be_invoked = (IFramework.Coroutine.CoroutineModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Coroutine.ICoroutine _coroutine = (IFramework.Coroutine.ICoroutine)translator.GetObject(L, 2, typeof(IFramework.Coroutine.ICoroutine));
                    
                    gen_to_be_invoked.StopCoroutine( _coroutine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
