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
using LockStep.Math.Util;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class LockStepMathLFloatWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.Math.LFloat);
			Utils.BeginObjectRegister(type, L, translator, 8, 11, 1, 1);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__lt", __LTMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__le", __LEMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__eq", __EqMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__add", __AddMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__sub", __SubMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__mul", __MulMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__div", __DivMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__unm", __UnmMeta);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CompareTo", _m_CompareTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToInt", _m_ToInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToLong", _m_ToLong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToFloat", _m_ToFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToDouble", _m_ToDouble);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Floor", _m_Floor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Ceil", _m_Ceil);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHash", _m_GetHash);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "_val", _g_get__val);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "_val", _s_set__val);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 15, 0, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Precision", LockStep.Math.LFloat.Precision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RateOfOldPrecision", LockStep.Math.LFloat.RateOfOldPrecision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HalfPrecision", LockStep.Math.LFloat.HalfPrecision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PrecisionFactor", LockStep.Math.LFloat.PrecisionFactor);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "zero", LockStep.Math.LFloat.zero);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "one", LockStep.Math.LFloat.one);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "negOne", LockStep.Math.LFloat.negOne);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "half", LockStep.Math.LFloat.half);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FLT_MAX", LockStep.Math.LFloat.FLT_MAX);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FLT_MIN", LockStep.Math.LFloat.FLT_MIN);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EPSILON", LockStep.Math.LFloat.EPSILON);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "INTERVAL_EPSI_LON", LockStep.Math.LFloat.INTERVAL_EPSI_LON);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MaxValue", LockStep.Math.LFloat.MaxValue);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MinValue", LockStep.Math.LFloat.MinValue);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3)))
				{
					bool _isUseRawVal = LuaAPI.lua_toboolean(L, 2);
					long _rawVal = LuaAPI.lua_toint64(L, 3);
					
					LockStep.Math.LFloat gen_ret = new LockStep.Math.LFloat(_isUseRawVal, _rawVal);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					int _val = LuaAPI.xlua_tointeger(L, 2);
					
					LockStep.Math.LFloat gen_ret = new LockStep.Math.LFloat(_val);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					long _val = LuaAPI.lua_toint64(L, 2);
					
					LockStep.Math.LFloat gen_ret = new LockStep.Math.LFloat(_val);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(LockStep.Math.LFloat));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LFloat constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LTMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of < operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LEMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside <= rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					LuaAPI.lua_pushboolean(L, leftside <= rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside <= rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					LuaAPI.lua_pushboolean(L, leftside <= rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside <= rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of <= operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __AddMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of + operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __SubMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of - operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __MulMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of * operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __DivMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			
				if (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					int leftside = LuaAPI.xlua_tointeger(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<LockStep.Math.LFloat>(L, 1) && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					LockStep.Math.LFloat leftside;translator.Get(L, 1, out leftside);
					long rightside = LuaAPI.lua_toint64(L, 2);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			
				if ((LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1)) && translator.Assignable<LockStep.Math.LFloat>(L, 2))
				{
					long leftside = LuaAPI.lua_toint64(L, 1);
					LockStep.Math.LFloat rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of / operator, need LockStep.Math.LFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __UnmMeta(RealStatePtr L)
        {
            
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
                LockStep.Math.LFloat rightside;translator.Get(L, 1, out rightside);
                translator.Push(L, - rightside);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool gen_ret = gen_to_be_invoked.Equals( _obj );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<LockStep.Math.LFloat>(L, 2)) 
                {
                    LockStep.Math.LFloat _other;translator.Get(L, 2, out _other);
                    
                        bool gen_ret = gen_to_be_invoked.Equals( _other );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.Math.LFloat.Equals!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    LockStep.Math.LFloat _other;translator.Get(L, 2, out _other);
                    
                        int gen_ret = gen_to_be_invoked.CompareTo( _other );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToInt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.ToInt(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToLong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        long gen_ret = gen_to_be_invoked.ToLong(  );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToFloat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.ToFloat(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToDouble(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        double gen_ret = gen_to_be_invoked.ToDouble(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
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
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.Floor(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ceil(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.Ceil(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
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
            
            
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _idx = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetHash( ref _idx );
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
        static int _g_get__val(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked._val);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__val(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.Math.LFloat gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked._val = LuaAPI.lua_toint64(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
