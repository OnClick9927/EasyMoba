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
    public class EasyMobaGameLogicBattleFactoryWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.BattleFactory);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreatePlayer", _m_CreatePlayer);
			
			
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
					
					var gen_ret = new EasyMoba.GameLogic.BattleFactory(_battle);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.BattleFactory constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePlayer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.BattleFactory gen_to_be_invoked = (EasyMoba.GameLogic.BattleFactory)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BattlePlayer _player = (BattlePlayer)translator.GetObject(L, 2, typeof(BattlePlayer));
                    LockStep.Math.LVector2 _pos;translator.Get(L, 3, out _pos);
                    
                    gen_to_be_invoked.CreatePlayer( _player, _pos );
                    
                    
                    
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
			
                EasyMoba.GameLogic.BattleFactory gen_to_be_invoked = (EasyMoba.GameLogic.BattleFactory)translator.FastGetCSObj(L, 1);
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
			
                EasyMoba.GameLogic.BattleFactory gen_to_be_invoked = (EasyMoba.GameLogic.BattleFactory)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.battle = (EasyMoba.GameLogic.Battle)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.Battle));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
