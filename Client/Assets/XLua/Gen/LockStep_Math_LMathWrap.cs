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
    public class LockStepMathLMathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.Math.LMath);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 46, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "_Atan2", _m__Atan2_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "_LutATan", _m__LutATan_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Atan2", _m_Atan2_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Acos", _m_Acos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Asin", _m_Asin_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sin", _m_Sin_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Cos", _m_Cos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SinCos", _m_SinCos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sqrt32", _m_Sqrt32_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sqrt64", _m_Sqrt64_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sqrt", _m_Sqrt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sqr", _m_Sqr_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RoundPowOfTwo", _m_RoundPowOfTwo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Clamp", _m_Clamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Clamp01", _m_Clamp01_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SameSign", _m_SameSign_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Abs", _m_Abs_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sign", _m_Sign_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Round", _m_Round_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Max", _m_Max_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Min", _m_Min_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FloorToInt", _m_FloorToInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Lerp", _m_Lerp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InverseLerp", _m_InverseLerp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsPowerOfTwo", _m_IsPowerOfTwo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CeilPowerOfTwo", _m_CeilPowerOfTwo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Dot", _m_Dot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Cross", _m_Cross_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Cross2D", _m_Cross2D_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Dot2D", _m_Dot2D_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Transform", _m_Transform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MoveTowards", _m_MoveTowards_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AngleInt", _m_AngleInt_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LPIQuad", LockStep.Math.LMath.LPIQuad);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LPIHalf", LockStep.Math.LMath.LPIHalf);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LPI", LockStep.Math.LMath.LPI);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LPI2", LockStep.Math.LMath.LPI2);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LRad2Deg", LockStep.Math.LMath.LRad2Deg);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LDeg2Rad", LockStep.Math.LMath.LDeg2Rad);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PIQuad", LockStep.Math.LMath.PIQuad);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PIHalf", LockStep.Math.LMath.PIHalf);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PI", LockStep.Math.LMath.PI);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PI2", LockStep.Math.LMath.PI2);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rad2Deg", LockStep.Math.LMath.Rad2Deg);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Deg2Rad", LockStep.Math.LMath.Deg2Rad);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Pi", _g_get_Pi);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "LockStep.Math.LMath does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m__Atan2_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    long _y = LuaAPI.lua_toint64(L, 1);
                    long _x = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = LockStep.Math.LMath._Atan2( _y, _x );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m__LutATan_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _ydx;translator.Get(L, 1, out _ydx);
                    
                        var gen_ret = LockStep.Math.LMath._LutATan( _ydx );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Atan2_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))) 
                {
                    long _y = LuaAPI.lua_toint64(L, 1);
                    long _x = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = LockStep.Math.LMath.Atan2( _y, _x );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LFloat>(L, 1)&& translator.Assignable<LockStep.Math.LFloat>(L, 2)) 
                {
                    LockStep.Math.LFloat _y;translator.Get(L, 1, out _y);
                    LockStep.Math.LFloat _x;translator.Get(L, 2, out _x);
                    
                        var gen_ret = LockStep.Math.LMath.Atan2( _y, _x );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Atan2!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Acos_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _val;translator.Get(L, 1, out _val);
                    
                        var gen_ret = LockStep.Math.LMath.Acos( _val );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Asin_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _val;translator.Get(L, 1, out _val);
                    
                        var gen_ret = LockStep.Math.LMath.Asin( _val );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sin_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _radians;translator.Get(L, 1, out _radians);
                    
                        var gen_ret = LockStep.Math.LMath.Sin( _radians );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cos_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _radians;translator.Get(L, 1, out _radians);
                    
                        var gen_ret = LockStep.Math.LMath.Cos( _radians );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SinCos_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _s;
                    LockStep.Math.LFloat _c;
                    LockStep.Math.LFloat _radians;translator.Get(L, 1, out _radians);
                    
                    LockStep.Math.LMath.SinCos( out _s, out _c, _radians );
                    translator.Push(L, _s);
                        
                    translator.Push(L, _c);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sqrt32_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    uint _a = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Sqrt32( _a );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sqrt64_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    ulong _a = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Sqrt64( _a );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sqrt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Sqrt( _a );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _a = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Sqrt( _a );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<LockStep.Math.LFloat>(L, 1)) 
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    
                        var gen_ret = LockStep.Math.LMath.Sqrt( _a );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Sqrt!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sqr_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    
                        var gen_ret = LockStep.Math.LMath.Sqr( _a );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RoundPowOfTwo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _x = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.RoundPowOfTwo( _x );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _x = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.RoundPowOfTwo( _x );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.RoundPowOfTwo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    int _min = LuaAPI.xlua_tointeger(L, 2);
                    int _max = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = LockStep.Math.LMath.Clamp( _value, _min, _max );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))) 
                {
                    long _a = LuaAPI.lua_toint64(L, 1);
                    long _min = LuaAPI.lua_toint64(L, 2);
                    long _max = LuaAPI.lua_toint64(L, 3);
                    
                        var gen_ret = LockStep.Math.LMath.Clamp( _a, _min, _max );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LFloat>(L, 1)&& translator.Assignable<LockStep.Math.LFloat>(L, 2)&& translator.Assignable<LockStep.Math.LFloat>(L, 3)) 
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LFloat _min;translator.Get(L, 2, out _min);
                    LockStep.Math.LFloat _max;translator.Get(L, 3, out _max);
                    
                        var gen_ret = LockStep.Math.LMath.Clamp( _a, _min, _max );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Clamp!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clamp01_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    
                        var gen_ret = LockStep.Math.LMath.Clamp01( _a );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SameSign_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LFloat _b;translator.Get(L, 2, out _b);
                    
                        var gen_ret = LockStep.Math.LMath.SameSign( _a, _b );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Abs_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _val = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Abs( _val );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<LockStep.Math.LFloat>(L, 1)) 
                {
                    LockStep.Math.LFloat _val;translator.Get(L, 1, out _val);
                    
                        var gen_ret = LockStep.Math.LMath.Abs( _val );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Abs!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sign_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _val;translator.Get(L, 1, out _val);
                    
                        var gen_ret = LockStep.Math.LMath.Sign( _val );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Round_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _val;translator.Get(L, 1, out _val);
                    
                        var gen_ret = LockStep.Math.LMath.Round( _val );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Max_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))) 
                {
                    long _a = LuaAPI.lua_toint64(L, 1);
                    long _b = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = LockStep.Math.LMath.Max( _a, _b );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = LockStep.Math.LMath.Max( _a, _b );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1))) 
                {
                    int[] _values = translator.GetParams<int>(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Max( _values );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || translator.Assignable<LockStep.Math.LFloat>(L, 1))) 
                {
                    LockStep.Math.LFloat[] _values = translator.GetParams<LockStep.Math.LFloat>(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Max( _values );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LFloat>(L, 1)&& translator.Assignable<LockStep.Math.LFloat>(L, 2)) 
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LFloat _b;translator.Get(L, 2, out _b);
                    
                        var gen_ret = LockStep.Math.LMath.Max( _a, _b );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Max!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Min_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))) 
                {
                    long _a = LuaAPI.lua_toint64(L, 1);
                    long _b = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = LockStep.Math.LMath.Min( _a, _b );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = LockStep.Math.LMath.Min( _a, _b );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1))) 
                {
                    int[] _values = translator.GetParams<int>(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Min( _values );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || translator.Assignable<LockStep.Math.LFloat>(L, 1))) 
                {
                    LockStep.Math.LFloat[] _values = translator.GetParams<LockStep.Math.LFloat>(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.Min( _values );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LFloat>(L, 1)&& translator.Assignable<LockStep.Math.LFloat>(L, 2)) 
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LFloat _b;translator.Get(L, 2, out _b);
                    
                        var gen_ret = LockStep.Math.LMath.Min( _a, _b );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Min!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FloorToInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    
                        var gen_ret = LockStep.Math.LMath.FloorToInt( _a );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Lerp_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LFloat>(L, 1)&& translator.Assignable<LockStep.Math.LFloat>(L, 2)&& translator.Assignable<LockStep.Math.LFloat>(L, 3)) 
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LFloat _b;translator.Get(L, 2, out _b);
                    LockStep.Math.LFloat _f;translator.Get(L, 3, out _f);
                    
                        var gen_ret = LockStep.Math.LMath.Lerp( _a, _b, _f );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LVector2>(L, 1)&& translator.Assignable<LockStep.Math.LVector2>(L, 2)&& translator.Assignable<LockStep.Math.LFloat>(L, 3)) 
                {
                    LockStep.Math.LVector2 _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LVector2 _b;translator.Get(L, 2, out _b);
                    LockStep.Math.LFloat _f;translator.Get(L, 3, out _f);
                    
                        var gen_ret = LockStep.Math.LMath.Lerp( _a, _b, _f );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LFloat>(L, 3)) 
                {
                    LockStep.Math.LVector3 _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LVector3 _b;translator.Get(L, 2, out _b);
                    LockStep.Math.LFloat _f;translator.Get(L, 3, out _f);
                    
                        var gen_ret = LockStep.Math.LMath.Lerp( _a, _b, _f );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Lerp!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InverseLerp_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LFloat _a;translator.Get(L, 1, out _a);
                    LockStep.Math.LFloat _b;translator.Get(L, 2, out _b);
                    LockStep.Math.LFloat _value;translator.Get(L, 3, out _value);
                    
                        var gen_ret = LockStep.Math.LMath.InverseLerp( _a, _b, _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPowerOfTwo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.IsPowerOfTwo( _x );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CeilPowerOfTwo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = LockStep.Math.LMath.CeilPowerOfTwo( _x );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
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
            
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector2>(L, 1)&& translator.Assignable<LockStep.Math.LVector2>(L, 2)) 
                {
                    LockStep.Math.LVector2 _u;translator.Get(L, 1, out _u);
                    LockStep.Math.LVector2 _v;translator.Get(L, 2, out _v);
                    
                        var gen_ret = LockStep.Math.LMath.Dot( _u, _v );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)) 
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LMath.Dot( _lhs, _rhs );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Dot!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cross_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LMath.Cross( _lhs, _rhs );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cross2D_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector2 _u;translator.Get(L, 1, out _u);
                    LockStep.Math.LVector2 _v;translator.Get(L, 2, out _v);
                    
                        var gen_ret = LockStep.Math.LMath.Cross2D( _u, _v );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dot2D_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector2 _u;translator.Get(L, 1, out _u);
                    LockStep.Math.LVector2 _v;translator.Get(L, 2, out _v);
                    
                        var gen_ret = LockStep.Math.LMath.Dot2D( _u, _v );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Transform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LVector3>(L, 3)) 
                {
                    LockStep.Math.LVector3 _point;translator.Get(L, 1, out _point);
                    LockStep.Math.LVector3 _forward;translator.Get(L, 2, out _forward);
                    LockStep.Math.LVector3 _trans;translator.Get(L, 3, out _trans);
                    
                        var gen_ret = LockStep.Math.LMath.Transform( ref _point, ref _forward, ref _trans );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _point);
                        translator.Update(L, 1, _point);
                        
                    translator.Push(L, _forward);
                        translator.Update(L, 2, _forward);
                        
                    translator.Push(L, _trans);
                        translator.Update(L, 3, _trans);
                        
                    
                    
                    
                    return 4;
                }
                if(gen_param_count == 3&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LVector3>(L, 3)) 
                {
                    LockStep.Math.LVector3 _point;translator.Get(L, 1, out _point);
                    LockStep.Math.LVector3 _forward;translator.Get(L, 2, out _forward);
                    LockStep.Math.LVector3 _trans;translator.Get(L, 3, out _trans);
                    
                        var gen_ret = LockStep.Math.LMath.Transform( _point, _forward, _trans );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LVector3>(L, 3)&& translator.Assignable<LockStep.Math.LVector3>(L, 4)) 
                {
                    LockStep.Math.LVector3 _point;translator.Get(L, 1, out _point);
                    LockStep.Math.LVector3 _forward;translator.Get(L, 2, out _forward);
                    LockStep.Math.LVector3 _trans;translator.Get(L, 3, out _trans);
                    LockStep.Math.LVector3 _scale;translator.Get(L, 4, out _scale);
                    
                        var gen_ret = LockStep.Math.LMath.Transform( _point, _forward, _trans, _scale );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LVector3>(L, 3)&& translator.Assignable<LockStep.Math.LVector3>(L, 4)&& translator.Assignable<LockStep.Math.LVector3>(L, 5)) 
                {
                    LockStep.Math.LVector3 _point;translator.Get(L, 1, out _point);
                    LockStep.Math.LVector3 _axis_x;translator.Get(L, 2, out _axis_x);
                    LockStep.Math.LVector3 _axis_y;translator.Get(L, 3, out _axis_y);
                    LockStep.Math.LVector3 _axis_z;translator.Get(L, 4, out _axis_z);
                    LockStep.Math.LVector3 _trans;translator.Get(L, 5, out _trans);
                    
                        var gen_ret = LockStep.Math.LMath.Transform( ref _point, ref _axis_x, ref _axis_y, ref _axis_z, ref _trans );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _point);
                        translator.Update(L, 1, _point);
                        
                    translator.Push(L, _axis_x);
                        translator.Update(L, 2, _axis_x);
                        
                    translator.Push(L, _axis_y);
                        translator.Update(L, 3, _axis_y);
                        
                    translator.Push(L, _axis_z);
                        translator.Update(L, 4, _axis_z);
                        
                    translator.Push(L, _trans);
                        translator.Update(L, 5, _trans);
                        
                    
                    
                    
                    return 6;
                }
                if(gen_param_count == 5&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LVector3>(L, 3)&& translator.Assignable<LockStep.Math.LVector3>(L, 4)&& translator.Assignable<LockStep.Math.LVector3>(L, 5)) 
                {
                    LockStep.Math.LVector3 _point;translator.Get(L, 1, out _point);
                    LockStep.Math.LVector3 _axis_x;translator.Get(L, 2, out _axis_x);
                    LockStep.Math.LVector3 _axis_y;translator.Get(L, 3, out _axis_y);
                    LockStep.Math.LVector3 _axis_z;translator.Get(L, 4, out _axis_z);
                    LockStep.Math.LVector3 _trans;translator.Get(L, 5, out _trans);
                    
                        var gen_ret = LockStep.Math.LMath.Transform( _point, ref _axis_x, ref _axis_y, ref _axis_z, ref _trans );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _axis_x);
                        translator.Update(L, 2, _axis_x);
                        
                    translator.Push(L, _axis_y);
                        translator.Update(L, 3, _axis_y);
                        
                    translator.Push(L, _axis_z);
                        translator.Update(L, 4, _axis_z);
                        
                    translator.Push(L, _trans);
                        translator.Update(L, 5, _trans);
                        
                    
                    
                    
                    return 5;
                }
                if(gen_param_count == 6&& translator.Assignable<LockStep.Math.LVector3>(L, 1)&& translator.Assignable<LockStep.Math.LVector3>(L, 2)&& translator.Assignable<LockStep.Math.LVector3>(L, 3)&& translator.Assignable<LockStep.Math.LVector3>(L, 4)&& translator.Assignable<LockStep.Math.LVector3>(L, 5)&& translator.Assignable<LockStep.Math.LVector3>(L, 6)) 
                {
                    LockStep.Math.LVector3 _point;translator.Get(L, 1, out _point);
                    LockStep.Math.LVector3 _axis_x;translator.Get(L, 2, out _axis_x);
                    LockStep.Math.LVector3 _axis_y;translator.Get(L, 3, out _axis_y);
                    LockStep.Math.LVector3 _axis_z;translator.Get(L, 4, out _axis_z);
                    LockStep.Math.LVector3 _trans;translator.Get(L, 5, out _trans);
                    LockStep.Math.LVector3 _scale;translator.Get(L, 6, out _scale);
                    
                        var gen_ret = LockStep.Math.LMath.Transform( ref _point, ref _axis_x, ref _axis_y, ref _axis_z, ref _trans, ref _scale );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _point);
                        translator.Update(L, 1, _point);
                        
                    translator.Push(L, _axis_x);
                        translator.Update(L, 2, _axis_x);
                        
                    translator.Push(L, _axis_y);
                        translator.Update(L, 3, _axis_y);
                        
                    translator.Push(L, _axis_z);
                        translator.Update(L, 4, _axis_z);
                        
                    translator.Push(L, _trans);
                        translator.Update(L, 5, _trans);
                        
                    translator.Push(L, _scale);
                        translator.Update(L, 6, _scale);
                        
                    
                    
                    
                    return 7;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LMath.Transform!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveTowards_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector3 _from;translator.Get(L, 1, out _from);
                    LockStep.Math.LVector3 _to;translator.Get(L, 2, out _to);
                    LockStep.Math.LFloat _dt;translator.Get(L, 3, out _dt);
                    
                        var gen_ret = LockStep.Math.LMath.MoveTowards( _from, _to, _dt );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AngleInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    LockStep.Math.LVector3 _lhs;translator.Get(L, 1, out _lhs);
                    LockStep.Math.LVector3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        var gen_ret = LockStep.Math.LMath.AngleInt( _lhs, _rhs );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pi(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, LockStep.Math.LMath.Pi);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
