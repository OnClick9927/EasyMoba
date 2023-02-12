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
    public class ICanCallClientBattleMsgWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ICanCallClientBattleMsg);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendResponse", _m_SendResponse);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendBattleFrame", _m_SendBattleFrame);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "ICanCallClientBattleMsg does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendResponse(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ICanCallClientBattleMsg gen_to_be_invoked = (ICanCallClientBattleMsg)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _role_id = LuaAPI.lua_toint64(L, 2);
                    SPBattleAllReady _response = (SPBattleAllReady)translator.GetObject(L, 3, typeof(SPBattleAllReady));
                    
                    gen_to_be_invoked.SendResponse( _role_id, _response );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendBattleFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ICanCallClientBattleMsg gen_to_be_invoked = (ICanCallClientBattleMsg)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _roleID = LuaAPI.lua_toint64(L, 2);
                    SPBattleFrame _frame = (SPBattleFrame)translator.GetObject(L, 3, typeof(SPBattleFrame));
                    
                    gen_to_be_invoked.SendBattleFrame( _roleID, _frame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
