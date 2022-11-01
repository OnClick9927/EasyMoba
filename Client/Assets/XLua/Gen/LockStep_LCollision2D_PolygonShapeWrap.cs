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
    public class LockStepLCollision2DPolygonShapeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.PolygonShape);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 4, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Build", _m_Build);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "localPoints", _g_get_localPoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "points", _g_get_points);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nomals", _g_get_nomals);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "localPoints", _s_set_localPoints);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "points", _s_set_points);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bounds", _s_set_bounds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nomals", _s_set_nomals);
            
			
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
					
					LockStep.LCollision2D.PolygonShape gen_ret = new LockStep.LCollision2D.PolygonShape();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.PolygonShape constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Build(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Build(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localPoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_points(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.points);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nomals(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nomals);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.localPoints = (LockStep.Math.LVector2[])translator.GetObject(L, 2, typeof(LockStep.Math.LVector2[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_points(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.points = (LockStep.Math.LVector2[])translator.GetObject(L, 2, typeof(LockStep.Math.LVector2[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bounds = (LockStep.LCollision2D.Bound[])translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Bound[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nomals(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.PolygonShape gen_to_be_invoked = (LockStep.LCollision2D.PolygonShape)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nomals = (LockStep.Math.LVector2[])translator.GetObject(L, 2, typeof(LockStep.Math.LVector2[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
