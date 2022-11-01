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
    public class IFrameworkUIPanelPathCollectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.UI.PanelPathCollect);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteData", _m_WriteData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetData", _m_GetData);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "datas", _g_get_datas);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "datas", _s_set_datas);
            
			
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
					
					IFramework.UI.PanelPathCollect gen_ret = new IFramework.UI.PanelPathCollect();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.PanelPathCollect constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.PanelPathCollect gen_to_be_invoked = (IFramework.UI.PanelPathCollect)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<IFramework.UI.PanelPathCollect.Data> _datas = (System.Collections.Generic.List<IFramework.UI.PanelPathCollect.Data>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<IFramework.UI.PanelPathCollect.Data>));
                    
                    gen_to_be_invoked.WriteData( _datas );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.PanelPathCollect gen_to_be_invoked = (IFramework.UI.PanelPathCollect)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        IFramework.UI.PanelPathCollect.Data gen_ret = gen_to_be_invoked.GetData( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_datas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.PanelPathCollect gen_to_be_invoked = (IFramework.UI.PanelPathCollect)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.datas);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_datas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.PanelPathCollect gen_to_be_invoked = (IFramework.UI.PanelPathCollect)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.datas = (System.Collections.Generic.List<IFramework.UI.PanelPathCollect.Data>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<IFramework.UI.PanelPathCollect.Data>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
