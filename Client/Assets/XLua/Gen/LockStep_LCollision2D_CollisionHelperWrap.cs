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
    public class LockStepLCollision2DCollisionHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.CollisionHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 11, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "AllocateNode", _m_AllocateNode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RecyleNode", _m_RecyleNode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CouldCollisionShape", _m_CouldCollisionShape_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CouldRaycastNode", _m_CouldRaycastNode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Repeat", _m_Repeat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Point2LineIntersection", _m_Point2LineIntersection_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsPointInSegment", _m_IsPointInSegment_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CouldCollision", _m_CouldCollision_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RayCast", _m_RayCast_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PositionCorrection", _m_PositionCorrection_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new LockStep.LCollision2D.CollisionHelper();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.CollisionHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AllocateNode_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.AllocateNode(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecyleNode_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.LCollision2D.Node _node = (LockStep.LCollision2D.Node)translator.GetObject(L, 1, typeof(LockStep.LCollision2D.Node));
                    
                    LockStep.LCollision2D.CollisionHelper.RecyleNode( _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CouldCollisionShape_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LRect _area;translator.Get(L, 1, out _area);
                    LockStep.Math.LFloat _maxRadius;translator.Get(L, 2, out _maxRadius);
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.Shape));
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.CouldCollisionShape( _area, _maxRadius, _shape );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CouldRaycastNode_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.LCollision2D.Ray _ray;translator.Get(L, 1, out _ray);
                    LockStep.Math.LRect _area;translator.Get(L, 2, out _area);
                    LockStep.Math.LFloat _maxRadius;translator.Get(L, 3, out _maxRadius);
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.CouldRaycastNode( _ray, _area, _maxRadius );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Repeat_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    int _length = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.Repeat( _value, _length );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Point2LineIntersection_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector2 _line_start;translator.Get(L, 1, out _line_start);
                    LockStep.Math.LVector2 _line_end;translator.Get(L, 2, out _line_end);
                    LockStep.Math.LVector2 _point;translator.Get(L, 3, out _point);
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.Point2LineIntersection( _line_start, _line_end, _point );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPointInSegment_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector2 _seg_start;translator.Get(L, 1, out _seg_start);
                    LockStep.Math.LVector2 _seg_end;translator.Get(L, 2, out _seg_end);
                    LockStep.Math.LVector2 _point;translator.Get(L, 3, out _point);
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.IsPointInSegment( _seg_start, _seg_end, _point );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CouldCollision_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.LCollision2D.Shape _a = (LockStep.LCollision2D.Shape)translator.GetObject(L, 1, typeof(LockStep.LCollision2D.Shape));
                    LockStep.LCollision2D.Shape _b = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    LockStep.LCollision2D.QuadTree _tree = (LockStep.LCollision2D.QuadTree)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.QuadTree));
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.CouldCollision( _a, _b, _tree );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RayCast_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.LCollision2D.Ray _ray;translator.Get(L, 1, out _ray);
                    LockStep.LCollision2D.Shape _b = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    LockStep.LCollision2D.RayHit _hit;
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.RayCast( _ray, _b, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PositionCorrection_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LVector2>(L, 1)&& translator.Assignable<LockStep.LCollision2D.Shape>(L, 2)&& translator.Assignable<LockStep.LCollision2D.Shape>(L, 3)) 
                {
                    LockStep.Math.LVector2 _lastPos;translator.Get(L, 1, out _lastPos);
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    LockStep.LCollision2D.Shape _collison = (LockStep.LCollision2D.Shape)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.Shape));
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.PositionCorrection( _lastPos, _shape, _collison );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LVector2>(L, 1)&& translator.Assignable<LockStep.LCollision2D.Shape>(L, 2)&& translator.Assignable<System.Collections.Generic.List<LockStep.LCollision2D.Shape>>(L, 3)) 
                {
                    LockStep.Math.LVector2 _lastPos;translator.Get(L, 1, out _lastPos);
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    System.Collections.Generic.List<LockStep.LCollision2D.Shape> _collisons = (System.Collections.Generic.List<LockStep.LCollision2D.Shape>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<LockStep.LCollision2D.Shape>));
                    
                        var gen_ret = LockStep.LCollision2D.CollisionHelper.PositionCorrection( _lastPos, _shape, _collisons );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.CollisionHelper.PositionCorrection!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
