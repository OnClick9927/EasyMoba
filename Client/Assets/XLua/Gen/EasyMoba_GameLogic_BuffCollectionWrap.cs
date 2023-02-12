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
    public class EasyMobaGameLogicBuffCollectionWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.BuffCollection);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddBuff", _m_AddBuff);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FixedUpdate", _m_FixedUpdate);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "battle", _g_get_battle);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "battle", _s_set_battle);
            
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<EasyMoba.GameLogic.Battle>(L, 2))
				{
					EasyMoba.GameLogic.Battle _battle = (EasyMoba.GameLogic.Battle)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.Battle));
					
					var gen_ret = new EasyMoba.GameLogic.BuffCollection(_battle);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.BuffCollection constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBuff(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.BuffCollection gen_to_be_invoked = (EasyMoba.GameLogic.BuffCollection)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    EasyMoba.GameLogic.BuffData _data = (EasyMoba.GameLogic.BuffData)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.BuffData));
                    EasyMoba.GameLogic.MobaUnit _target = (EasyMoba.GameLogic.MobaUnit)translator.GetObject(L, 3, typeof(EasyMoba.GameLogic.MobaUnit));
                    
                    gen_to_be_invoked.AddBuff( _data, _target );
                    
                    
                    
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
            
            
                EasyMoba.GameLogic.BuffCollection gen_to_be_invoked = (EasyMoba.GameLogic.BuffCollection)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _curFrame = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.FixedUpdate( _curFrame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_battle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.BuffCollection gen_to_be_invoked = (EasyMoba.GameLogic.BuffCollection)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.battle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_battle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.BuffCollection gen_to_be_invoked = (EasyMoba.GameLogic.BuffCollection)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.battle = (EasyMoba.GameLogic.Battle)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.Battle));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
