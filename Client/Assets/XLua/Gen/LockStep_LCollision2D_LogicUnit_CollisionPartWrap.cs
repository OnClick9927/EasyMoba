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
    public class LockStepLCollision2DLogicUnitCollisionPartWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.LogicUnit.CollisionPart);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SyncData", _m_SyncData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoCollision", _m_DoCollision);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoAdd", _m_DoAdd);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "shape", _g_get_shape);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "last_pos", _g_get_last_pos);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "shape", _s_set_shape);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "last_pos", _s_set_last_pos);
            
			
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
					
					var gen_ret = new LockStep.LCollision2D.LogicUnit.CollisionPart();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.LogicUnit.CollisionPart constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SyncData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.LogicUnit _transform = (LockStep.LCollision2D.LogicUnit)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicUnit));
                    
                    gen_to_be_invoked.SyncData( _transform );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoCollision(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.LogicWorld _word = (LockStep.LCollision2D.LogicWorld)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicWorld));
                    LockStep.LCollision2D.LogicUnit _transform = (LockStep.LCollision2D.LogicUnit)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.LogicUnit));
                    
                    gen_to_be_invoked.DoCollision( _word, _transform );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoAdd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.LogicWorld _world = (LockStep.LCollision2D.LogicWorld)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicWorld));
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.Shape));
                    
                    gen_to_be_invoked.DoAdd( _world, _shape );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shape);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_last_pos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.last_pos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_last_pos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit.CollisionPart gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit.CollisionPart)translator.FastGetCSObj(L, 1);
                LockStep.Math.LVector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.last_pos = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
