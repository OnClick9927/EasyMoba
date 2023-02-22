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
    public class EasyMobaGameLogicSkillEffectExecutorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.SkillEffectExecutor);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FixUpdate", _m_FixUpdate);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "need_remove", _g_get_need_remove);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "EasyMoba.GameLogic.SkillEffectExecutor does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FixUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.SkillEffectExecutor gen_to_be_invoked = (EasyMoba.GameLogic.SkillEffectExecutor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _curFrame = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.FixUpdate( _curFrame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_need_remove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.SkillEffectExecutor gen_to_be_invoked = (EasyMoba.GameLogic.SkillEffectExecutor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.need_remove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
