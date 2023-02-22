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
    public class EasyMobaGameLogicPlayerUnitWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.PlayerUnit);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 10, 9);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnMobaCreate", _m_OnMobaCreate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestory", _m_OnDestory);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "type", _g_get_type);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxEnergy", _g_get_MaxEnergy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxRotateAngle", _g_get_MaxRotateAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AddSpeedPerTrick", _g_get_AddSpeedPerTrick);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RotateAngle", _g_get_RotateAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Energy", _g_get_Energy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Speed", _g_get_Speed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Damage", _g_get_Damage);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Size", _g_get_Size);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "role_id", _g_get_role_id);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaxEnergy", _s_set_MaxEnergy);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaxRotateAngle", _s_set_MaxRotateAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AddSpeedPerTrick", _s_set_AddSpeedPerTrick);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RotateAngle", _s_set_RotateAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Energy", _s_set_Energy);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Speed", _s_set_Speed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Damage", _s_set_Damage);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Size", _s_set_Size);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "role_id", _s_set_role_id);
            
			
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
					
					var gen_ret = new EasyMoba.GameLogic.PlayerUnit();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.PlayerUnit constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnMobaCreate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnMobaCreate(  );
                    
                    
                    
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
            
            
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestory(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.type);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxEnergy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.MaxEnergy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxRotateAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.MaxRotateAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AddSpeedPerTrick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.AddSpeedPerTrick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RotateAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RotateAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Energy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Energy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Speed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Damage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Damage);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Size);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_role_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.role_id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxEnergy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.MaxEnergy = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxRotateAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.MaxRotateAngle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AddSpeedPerTrick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.AddSpeedPerTrick = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RotateAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.RotateAngle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Energy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Energy = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Speed = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Damage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Damage = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Size = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_role_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.PlayerUnit gen_to_be_invoked = (EasyMoba.GameLogic.PlayerUnit)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.role_id = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
