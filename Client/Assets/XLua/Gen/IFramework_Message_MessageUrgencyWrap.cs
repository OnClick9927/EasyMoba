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
    public class IFrameworkMessageMessageUrgencyWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Message.MessageUrgency);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 8, 0, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Immediately", IFramework.Message.MessageUrgency.Immediately);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "VeryUrgent", IFramework.Message.MessageUrgency.VeryUrgent);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Urgent", IFramework.Message.MessageUrgency.Urgent);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Important", IFramework.Message.MessageUrgency.Important);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Common", IFramework.Message.MessageUrgency.Common);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unimportant", IFramework.Message.MessageUrgency.Unimportant);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Dispensable", IFramework.Message.MessageUrgency.Dispensable);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "IFramework.Message.MessageUrgency does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        
        
        
        
        
		
		
		
		
    }
}
