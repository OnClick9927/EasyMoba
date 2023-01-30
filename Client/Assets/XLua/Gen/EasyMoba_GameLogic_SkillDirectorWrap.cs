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
    public class EasyMobaGameLogicSkillDirectorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.SkillDirector);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FixUpdate", _m_FixUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PlaySkill", _m_PlaySkill);
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<EasyMoba.GameLogic.SkillConfig>(L, 2))
				{
					EasyMoba.GameLogic.SkillConfig _config = (EasyMoba.GameLogic.SkillConfig)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.SkillConfig));
					
					var gen_ret = new EasyMoba.GameLogic.SkillDirector(_config);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.SkillDirector constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FixUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.SkillDirector gen_to_be_invoked = (EasyMoba.GameLogic.SkillDirector)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_PlaySkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.SkillDirector gen_to_be_invoked = (EasyMoba.GameLogic.SkillDirector)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    EasyMoba.GameLogic.SkillData _skill = (EasyMoba.GameLogic.SkillData)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.SkillData));
                    EasyMoba.GameLogic.MobaUnit _unit = (EasyMoba.GameLogic.MobaUnit)translator.GetObject(L, 3, typeof(EasyMoba.GameLogic.MobaUnit));
                    
                    gen_to_be_invoked.PlaySkill( _skill, _unit );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
