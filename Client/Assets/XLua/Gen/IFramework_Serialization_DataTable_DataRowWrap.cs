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
    public class IFrameworkSerializationDataTableDataRowWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Serialization.DataTable.DataRow);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadLine", _m_ReadLine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadHeadLine", _m_ReadHeadLine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteLine", _m_WriteLine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteHeadLine", _m_WriteHeadLine);
			
			
			
			
			
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
					
					IFramework.Serialization.DataTable.DataRow gen_ret = new IFramework.Serialization.DataTable.DataRow();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Serialization.DataTable.DataRow constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadLine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Serialization.DataTable.DataRow gen_to_be_invoked = (IFramework.Serialization.DataTable.DataRow)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _val = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<string> _headNames = (System.Collections.Generic.List<string>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<string>));
                    
                        System.Collections.Generic.List<IFramework.Serialization.DataTable.DataColumn> gen_ret = gen_to_be_invoked.ReadLine( _val, _headNames );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadHeadLine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Serialization.DataTable.DataRow gen_to_be_invoked = (IFramework.Serialization.DataTable.DataRow)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _val = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<string> gen_ret = gen_to_be_invoked.ReadHeadLine( _val );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteLine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Serialization.DataTable.DataRow gen_to_be_invoked = (IFramework.Serialization.DataTable.DataRow)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<IFramework.Serialization.DataTable.DataColumn> _cols = (System.Collections.Generic.List<IFramework.Serialization.DataTable.DataColumn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<IFramework.Serialization.DataTable.DataColumn>));
                    System.Text.StringBuilder _builder = (System.Text.StringBuilder)translator.GetObject(L, 3, typeof(System.Text.StringBuilder));
                    
                    gen_to_be_invoked.WriteLine( _cols, _builder );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteHeadLine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Serialization.DataTable.DataRow gen_to_be_invoked = (IFramework.Serialization.DataTable.DataRow)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<string> _headNames = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
                    System.Text.StringBuilder _builder = (System.Text.StringBuilder)translator.GetObject(L, 3, typeof(System.Text.StringBuilder));
                    
                    gen_to_be_invoked.WriteHeadLine( _headNames, _builder );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
