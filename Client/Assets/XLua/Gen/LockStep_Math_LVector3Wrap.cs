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
using LockStep.Math;using LockStep.Math.Util;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class LockStepMathLVector3Wrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.Math.LVector3);
			Utils.BeginObjectRegister(type, L, translator, 6, 9, 10, 6);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__eq", __EqMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__sub", __SubMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__unm", __UnmMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__add", __AddMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__mul", __MulMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__div", __DivMeta);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RawSqrMagnitude", _m_RawSqrMagnitude);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Normalize", _m_Normalize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToVector3", _m_ToVector3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToLVector3Int", _m_ToLVector3Int);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Floor", _m_Floor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHash", _m_GetHash);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "x", _g_get_x);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "y", _g_get_y);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "z", _g_get_z);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "magnitude", _g_get_magnitude);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sqrMagnitude", _g_get_sqrMagnitude);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "abs", _g_get_abs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "normalized", _g_get_normalized);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_x", _g_get__x);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_y", _g_get__y);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_z", _g_get__z);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "x", _s_set_x);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "y", _s_set_y);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "z", _s_set_z);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_x", _s_set__x);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_y", _s_set__y);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_z", _s_set__z);
            
			
			Utils.EndObjectRegister(type, L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 13, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Dot", _m_Dot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Cross", _m_Cross_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Lerp", _m_Lerp_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "zero", LockStep.Math.LVector3.zero);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "one", LockStep.Math.LVector3.one);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "half", LockStep.Math.LVector3.half);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "forward", LockStep.Math.LVector3.forward);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "up", LockStep.Math.LVector3.up);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "right", LockStep.Math.LVector3.right);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "back", LockStep.Math.LVector3.back);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "down", LockStep.Math.LVector3.down);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "left", LockStep.Math.LVector3.left);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3)) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isint64(L, 4)) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) || LuaAPI.lua_isint64(L, 5)))
				{
					bool _isUseRawVal = LuaAPI.lua_toboolean(L, 2);
					long __x = LuaAPI.lua_toint64(L, 3);
					long __y = LuaAPI.lua_toint64(L, 4);
					long __z = LuaAPI.lua_toint64(L, 5);
					
					var gen_ret = new LockStep.Math.LVector3(_isUseRawVal, __x, __y, __z);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3)) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isint64(L, 4)))
				{
					long __x = LuaAPI.lua_toint64(L, 2);
					long __y = LuaAPI.lua_toint64(L, 3);
					long __z = LuaAPI.lua_toint64(L, 4);
					
					var gen_ret = new LockStep.Math.LVector3(__x, __y, __z);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<LockStep.Math.LFloat>(L, 2) && translator.Assignable<LockStep.Math.LFloat>(L, 3) && translator.Assignable<LockStep.Math.LFloat>(L, 4))
				{
					LockStep.Math.LFloat _x;translator.Get(L, 2, out _x);
					LockStep.Math.LFloat _y;translator.Get(L, 3, out _y);
					LockStep.Math.LFloat _z;translator.Get(L, 4, out _z);
					
					var gen_ret = new LockStep.Math.LVector3(_x, _y, _z);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))
				{
					bool _shouldOnlyUseInEditor = LuaAPI.lua_toboolean(L, 2);
					float _x = (float)LuaAPI.lua_tonumber(L, 3);
					float _y = (float)LuaAPI.lua_tonumber(L, 4);
					float _z = (float)LuaAPI.lua_tonumber(L, 5);
					
					var gen_ret = new LockStep.Math.LVector3(_shouldOnlyUseInEditor, _x, _y, _z);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(LockStep.Math.LVector3));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LVector3 constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			try {
			    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
					int index = LuaAPI.xlua_tointeger(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					translator.Push(L, gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<LockStep.Math.LFloat>(L, 3))
				{
					
					LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
					int key = LuaAPI.xlua_tointeger(L, 2);
					LockStep.Math.LFloat gen_value;translator.Get(L, 3, out gen_value);
					gen_to_be_invoked[key] = gen_value;
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && translator.Assignable<LockStep.Math.LVector3>(L, 2))
				{
					LockStep.Math.LVector3 leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LVector3 rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need LockStep.Math.LVector3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __SubMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && translator.Assignable<LockStep.Math.LVector3>(L, 2))
				{
					LockStep.Math.LVector3 leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LVector3 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of - operator, need LockStep.Math.LVector3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __UnmMeta(RealStatePtr L)
        {
            
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
                LockStep.Math.LVector3 rightside;translator.Get(L, 1, out rightside);
                translator.Push(L, - rightside);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __AddMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && translator.Assignable<LockStep.Math.LVector3>(L, 2))
				{
					LockStep.Math.LVector3 leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LVector3 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of + operator, need LockStep.Math.LVector3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __MulMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && translator.Assignable<LockStep.Math.LVector3>(L, 2))
				{
					LockStep.Math.LVector3 leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LVector3 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LVector3 leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LVector3>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LVector3 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of * operator, need LockStep.Math.LVector3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __DivMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LVector3>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LVector3 leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of / operator, need LockStep.Math.LVector3!");
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RawSqrMagnitude(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.RawSqrMagnitude(  );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Normalize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.Normalize(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LFloat>(L, 2)) 
                {
                    LockStep.Math.LFloat _newMagn;translator.Get(L, 2, out _newMagn);
                    
                        var gen_ret = gen_to_be_invoked.Normalize( _newMagn );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LVector3.Normalize!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _o = translator.GetObject(L, 2, typeof(object));
                    
                        var gen_ret = gen_to_be_invoked.Equals( _o );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector3>(L, 2)) 
                {
                    LockStep.Math.LVector3 _other;translator.Get(L, 2, out _other);
                    
                        var gen_ret = gen_to_be_invoked.Equals( _other );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LVector3.Equals!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)) 
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LVector3.Dot( ref _lhs, ref _rhs );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _lhs);
                        translator.Update(L, 1, _lhs);
                        
                    translator.Push(L, _rhs);
                        translator.Update(L, 2, _rhs);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)) 
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LVector3.Dot( _lhs, _rhs );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LVector3.Dot!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cross_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)) 
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LVector3.Cross( ref _lhs, ref _rhs );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _lhs);
                        translator.Update(L, 1, _lhs);
                        
                    translator.Push(L, _rhs);
                        translator.Update(L, 2, _rhs);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)) 
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LVector3.Cross( _lhs, _rhs );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LVector3.Cross!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Lerp_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector3 _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LVector3 _b;translator.Get(L, 2, out _b);
                    LockStep.Math.LFloat _f;translator.Get(L, 3, out _f);
                    
                        var gen_ret = LockStep.Math.LVector3.Lerp( _a, _b, _f );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToVector3(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ToVector3(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToLVector3Int(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ToLVector3Int(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Floor(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.Floor(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHash(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _idx = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetHash( ref _idx );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _idx);
                        
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.x);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_y(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.y);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_z(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.z);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_magnitude(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.magnitude);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sqrMagnitude(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.sqrMagnitude);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_abs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.abs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normalized(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.normalized);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked._x);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__y(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked._y);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__z(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked._z);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.x = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_y(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.y = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_z(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.z = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked._x = LuaAPI.lua_toint64(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__y(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked._y = LuaAPI.lua_toint64(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__z(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LVector3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked._z = LuaAPI.lua_toint64(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
