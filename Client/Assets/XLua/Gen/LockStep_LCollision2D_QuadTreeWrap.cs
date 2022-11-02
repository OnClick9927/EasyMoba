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
    public class LockStepLCollision2DQuadTreeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.QuadTree);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 3, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveShape", _m_RemoveShape);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddShape", _m_AddShape);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildTree", _m_BuildTree);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCollision", _m_GetCollision);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RayCast", _m_RayCast);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "layer", _g_get_layer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nodes", _g_get_nodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shapes", _g_get_shapes);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "nodes", _s_set_nodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shapes", _s_set_shapes);
            
			
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
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<LockStep.Math.LVector2>(L, 2) && translator.Assignable<LockStep.LCollision2D.CollisionLayerConfig>(L, 3))
				{
					LockStep.Math.LVector2 _startSize;translator.Get(L, 2, out _startSize);
					LockStep.LCollision2D.CollisionLayerConfig _layer = (LockStep.LCollision2D.CollisionLayerConfig)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.CollisionLayerConfig));
					
					var gen_ret = new LockStep.LCollision2D.QuadTree(_startSize, _layer);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.QuadTree constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveShape(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    
                    gen_to_be_invoked.RemoveShape( _shape );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddShape(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    
                    gen_to_be_invoked.AddShape( _shape );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildTree(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BuildTree(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCollision(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    System.Collections.Generic.List<LockStep.LCollision2D.Shape> _result = (System.Collections.Generic.List<LockStep.LCollision2D.Shape>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<LockStep.LCollision2D.Shape>));
                    
                        var gen_ret = gen_to_be_invoked.GetCollision( _shape, _result );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RayCast(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Ray _ray;translator.Get(L, 2, out _ray);
                    System.Collections.Generic.List<LockStep.LCollision2D.RayHit> _hit = (System.Collections.Generic.List<LockStep.LCollision2D.RayHit>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<LockStep.LCollision2D.RayHit>));
                    
                        var gen_ret = gen_to_be_invoked.RayCast( _ray, _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.layer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shapes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shapes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nodes = (System.Collections.Generic.List<LockStep.LCollision2D.Node>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LockStep.LCollision2D.Node>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shapes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.QuadTree gen_to_be_invoked = (LockStep.LCollision2D.QuadTree)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shapes = (System.Collections.Generic.List<LockStep.LCollision2D.Shape>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LockStep.LCollision2D.Shape>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
