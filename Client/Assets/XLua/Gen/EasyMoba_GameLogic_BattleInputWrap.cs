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
    public class EasyMobaGameLogicBattleInputWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.BattleInput);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 2, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendFrame", _m_SendFrame);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "curframe", _g_get_curframe);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "data", _g_get_data);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "data", _s_set_data);
            
			
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
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<EasyMoba.GameLogic.FrameCollection>(L, 2) && translator.Assignable<EasyMoba.GameLogic.BattleModePlayer>(L, 3))
				{
					EasyMoba.GameLogic.FrameCollection _collection = (EasyMoba.GameLogic.FrameCollection)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.FrameCollection));
					EasyMoba.GameLogic.BattleModePlayer _mode_server = (EasyMoba.GameLogic.BattleModePlayer)translator.GetObject(L, 3, typeof(EasyMoba.GameLogic.BattleModePlayer));
					
					var gen_ret = new EasyMoba.GameLogic.BattleInput(_collection, _mode_server);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.BattleInput constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.BattleInput gen_to_be_invoked = (EasyMoba.GameLogic.BattleInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SendFrame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_curframe(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.BattleInput gen_to_be_invoked = (EasyMoba.GameLogic.BattleInput)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.curframe);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.BattleInput gen_to_be_invoked = (EasyMoba.GameLogic.BattleInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.BattleInput gen_to_be_invoked = (EasyMoba.GameLogic.BattleInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.data = (FrameData)translator.GetObject(L, 2, typeof(FrameData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
