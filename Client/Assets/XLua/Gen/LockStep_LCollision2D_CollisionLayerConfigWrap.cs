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
    public class LockStepLCollision2DCollisionLayerConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.CollisionLayerConfig);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetName", _m_GetName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CouldLayerCollision", _m_CouldLayerCollision);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Find", _m_Find);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Layers", _g_get_Layers);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Layers", _s_set_Layers);
            
			
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
					
					LockStep.LCollision2D.CollisionLayerConfig gen_ret = new LockStep.LCollision2D.CollisionLayerConfig();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.CollisionLayerConfig constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.CollisionLayerConfig gen_to_be_invoked = (LockStep.LCollision2D.CollisionLayerConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.CollisionLayer _layer;translator.Get(L, 2, out _layer);
                    
                        string gen_ret = gen_to_be_invoked.GetName( _layer );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CouldLayerCollision(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.CollisionLayerConfig gen_to_be_invoked = (LockStep.LCollision2D.CollisionLayerConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.CollisionLayer _shap_a;translator.Get(L, 2, out _shap_a);
                    LockStep.LCollision2D.CollisionLayer _shap_b;translator.Get(L, 3, out _shap_b);
                    
                        bool gen_ret = gen_to_be_invoked.CouldLayerCollision( _shap_a, _shap_b );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Find(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.CollisionLayerConfig gen_to_be_invoked = (LockStep.LCollision2D.CollisionLayerConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.CollisionLayer _layer;translator.Get(L, 2, out _layer);
                    
                        LockStep.LCollision2D.CollisionLayerConfig.LayerData gen_ret = gen_to_be_invoked.Find( _layer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Layers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.CollisionLayerConfig gen_to_be_invoked = (LockStep.LCollision2D.CollisionLayerConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Layers);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Layers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.CollisionLayerConfig gen_to_be_invoked = (LockStep.LCollision2D.CollisionLayerConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Layers = (System.Collections.Generic.List<LockStep.LCollision2D.CollisionLayerConfig.LayerData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LockStep.LCollision2D.CollisionLayerConfig.LayerData>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
