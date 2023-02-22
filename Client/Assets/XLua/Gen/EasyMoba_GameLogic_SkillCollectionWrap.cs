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
    public class EasyMobaGameLogicSkillCollectionWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.SkillCollection);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LearnSkill", _m_LearnSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PlaySkill", _m_PlaySkill);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "unit", _g_get_unit);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "unit", _s_set_unit);
            
			
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
					
					var gen_ret = new EasyMoba.GameLogic.SkillCollection();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.SkillCollection constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LearnSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.SkillCollection gen_to_be_invoked = (EasyMoba.GameLogic.SkillCollection)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    EasyMoba.GameLogic.SkillData _skill = (EasyMoba.GameLogic.SkillData)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.SkillData));
                    
                    gen_to_be_invoked.LearnSkill( _skill );
                    
                    
                    
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
            
            
                EasyMoba.GameLogic.SkillCollection gen_to_be_invoked = (EasyMoba.GameLogic.SkillCollection)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _skill_id = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.PlaySkill( _skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.SkillCollection gen_to_be_invoked = (EasyMoba.GameLogic.SkillCollection)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.unit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_unit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.SkillCollection gen_to_be_invoked = (EasyMoba.GameLogic.SkillCollection)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.unit = (EasyMoba.GameLogic.MobaUnit)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.MobaUnit));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
