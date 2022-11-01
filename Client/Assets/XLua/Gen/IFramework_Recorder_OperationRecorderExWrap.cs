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
    public class IFrameworkRecorderOperationRecorderExWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Recorder.OperationRecorderEx);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "AllocateCommand", _m_AllocateCommand_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AllocateAction", _m_AllocateAction_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AllocateCommandGroup", _m_AllocateCommandGroup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AllocateActionGroup", _m_AllocateActionGroup_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "IFramework.Recorder.OperationRecorderEx does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AllocateCommand_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Recorder.IOperationRecorderModule _t = (IFramework.Recorder.IOperationRecorderModule)translator.GetObject(L, 1, typeof(IFramework.Recorder.IOperationRecorderModule));
                    
                        IFramework.Recorder.CommandState gen_ret = IFramework.Recorder.OperationRecorderEx.AllocateCommand( _t );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AllocateAction_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Recorder.IOperationRecorderModule _t = (IFramework.Recorder.IOperationRecorderModule)translator.GetObject(L, 1, typeof(IFramework.Recorder.IOperationRecorderModule));
                    
                        IFramework.Recorder.ActionState gen_ret = IFramework.Recorder.OperationRecorderEx.AllocateAction( _t );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AllocateCommandGroup_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Recorder.IOperationRecorderModule _t = (IFramework.Recorder.IOperationRecorderModule)translator.GetObject(L, 1, typeof(IFramework.Recorder.IOperationRecorderModule));
                    
                        IFramework.Recorder.CommandGroupState gen_ret = IFramework.Recorder.OperationRecorderEx.AllocateCommandGroup( _t );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AllocateActionGroup_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Recorder.IOperationRecorderModule _t = (IFramework.Recorder.IOperationRecorderModule)translator.GetObject(L, 1, typeof(IFramework.Recorder.IOperationRecorderModule));
                    
                        IFramework.Recorder.ActionGroupState gen_ret = IFramework.Recorder.OperationRecorderEx.AllocateActionGroup( _t );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
