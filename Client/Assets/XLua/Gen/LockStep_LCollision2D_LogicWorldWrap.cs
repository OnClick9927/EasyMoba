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
    public class LockStepLCollision2DLogicWorldWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.LogicWorld);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindUnit", _m_FindUnit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DestoryUnit", _m_DestoryUnit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FixedUpdate", _m_FixedUpdate);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "objects", _g_get_objects);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tree", _g_get_tree);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "delta", _g_get_delta);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "objects", _s_set_objects);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tree", _s_set_tree);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "delta", _s_set_delta);
            
			
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
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<LockStep.LCollision2D.CollisionLayerConfig>(L, 2) && translator.Assignable<LockStep.Math.LFloat>(L, 3))
				{
					LockStep.LCollision2D.CollisionLayerConfig _layer = (LockStep.LCollision2D.CollisionLayerConfig)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.CollisionLayerConfig));
					LockStep.Math.LFloat _delta;translator.Get(L, 3, out _delta);
					
					var gen_ret = new LockStep.LCollision2D.LogicWorld(_layer, _delta);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.LogicWorld constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindUnit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.FindUnit( _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestoryUnit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.LogicUnit _trans = (LockStep.LCollision2D.LogicUnit)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicUnit));
                    
                    gen_to_be_invoked.DestoryUnit( _trans );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FixedUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _trick = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.FixedUpdate( _trick );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_objects(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.objects);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tree);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_delta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.delta);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_objects(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.objects = (System.Collections.Generic.List<LockStep.LCollision2D.LogicUnit>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LockStep.LCollision2D.LogicUnit>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tree = (LockStep.LCollision2D.QuadTree)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.QuadTree));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_delta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicWorld gen_to_be_invoked = (LockStep.LCollision2D.LogicWorld)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.delta = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
