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
    public class LockStepLCollision2DLogicUnitWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.LogicUnit);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 17, 10);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChild", _m_GetChild);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetParent", _m_SetParent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateCollision", _m_CreateCollision);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FixedUpdate", _m_FixedUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestory", _m_OnDestory);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "localPosition", _g_get_localPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localScale", _g_get_localScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localAngle", _g_get_localAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scale", _g_get_scale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "angle", _g_get_angle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "forward", _g_get_forward);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "back", _g_get_back);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "left", _g_get_left);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "right", _g_get_right);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "parent", _g_get_parent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ChildCount", _g_get_ChildCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "collision", _g_get_collision);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "world", _g_get_world);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "need_detory", _g_get_need_detory);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "name", _g_get_name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_parent", _g_get__parent);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "localPosition", _s_set_localPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "localScale", _s_set_localScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "localAngle", _s_set_localAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "position", _s_set_position);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scale", _s_set_scale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "angle", _s_set_angle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "world", _s_set_world);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "need_detory", _s_set_need_detory);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "name", _s_set_name);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_parent", _s_set__parent);
            
			
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
					
					var gen_ret = new LockStep.LCollision2D.LogicUnit();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.LogicUnit constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChild(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetChild( _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<LockStep.LCollision2D.LogicUnit>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    LockStep.LCollision2D.LogicUnit _parent = (LockStep.LCollision2D.LogicUnit)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicUnit));
                    bool _stay_word_pos = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetParent( _parent, _stay_word_pos );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.LCollision2D.LogicUnit>(L, 2)) 
                {
                    LockStep.LCollision2D.LogicUnit _parent = (LockStep.LCollision2D.LogicUnit)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicUnit));
                    
                    gen_to_be_invoked.SetParent( _parent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.LogicUnit.SetParent!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateCollision(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    
                    gen_to_be_invoked.CreateCollision( _shape );
                    
                    
                    
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
            
            
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _trick = LuaAPI.xlua_tointeger(L, 2);
                    LockStep.Math.LFloat _delta;translator.Get(L, 3, out _delta);
                    
                    gen_to_be_invoked.FixedUpdate( _trick, _delta );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestory(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestory(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.scale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_angle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.angle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_forward(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.forward);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_back(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.back);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_left(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.left);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_right(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.right);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_parent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.parent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ChildCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ChildCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_collision(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.collision);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_world(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.world);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_need_detory(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.need_detory);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__parent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._parent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LVector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.localPosition = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.localScale = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.localAngle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LVector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.position = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scale = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_angle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.angle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_world(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.world = (LockStep.LCollision2D.LogicWorld)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicWorld));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_need_detory(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.need_detory = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__parent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.LogicUnit gen_to_be_invoked = (LockStep.LCollision2D.LogicUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._parent = (LockStep.LCollision2D.LogicUnit)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.LogicUnit));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
