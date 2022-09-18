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
    public class IFrameworkSerializationDataTableDataTableToolWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Serialization.DataTable.DataTableTool);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateReader", _m_CreateReader_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateWriter", _m_CreateWriter_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "IFramework.Serialization.DataTable.DataTableTool does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateReader_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<System.IO.TextReader>(L, 1)&& translator.Assignable<IFramework.Serialization.DataTable.IDataRow>(L, 2)&& translator.Assignable<IFramework.Serialization.DataTable.IDataExplainer>(L, 3)) 
                {
                    System.IO.TextReader _streamReader = (System.IO.TextReader)translator.GetObject(L, 1, typeof(System.IO.TextReader));
                    IFramework.Serialization.DataTable.IDataRow _rowReader = (IFramework.Serialization.DataTable.IDataRow)translator.GetObject(L, 2, typeof(IFramework.Serialization.DataTable.IDataRow));
                    IFramework.Serialization.DataTable.IDataExplainer _explainer = (IFramework.Serialization.DataTable.IDataExplainer)translator.GetObject(L, 3, typeof(IFramework.Serialization.DataTable.IDataExplainer));
                    
                        IFramework.Serialization.DataTable.IDataReader gen_ret = IFramework.Serialization.DataTable.DataTableTool.CreateReader( _streamReader, _rowReader, _explainer );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<IFramework.Serialization.DataTable.IDataRow>(L, 2)&& translator.Assignable<IFramework.Serialization.DataTable.IDataExplainer>(L, 3)) 
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    IFramework.Serialization.DataTable.IDataRow _rowReader = (IFramework.Serialization.DataTable.IDataRow)translator.GetObject(L, 2, typeof(IFramework.Serialization.DataTable.IDataRow));
                    IFramework.Serialization.DataTable.IDataExplainer _explainer = (IFramework.Serialization.DataTable.IDataExplainer)translator.GetObject(L, 3, typeof(IFramework.Serialization.DataTable.IDataExplainer));
                    
                        IFramework.Serialization.DataTable.IDataReader gen_ret = IFramework.Serialization.DataTable.DataTableTool.CreateReader( _text, _rowReader, _explainer );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Serialization.DataTable.DataTableTool.CreateReader!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateWriter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.IO.TextWriter _streamWriter = (System.IO.TextWriter)translator.GetObject(L, 1, typeof(System.IO.TextWriter));
                    IFramework.Serialization.DataTable.IDataRow _rowWriter = (IFramework.Serialization.DataTable.IDataRow)translator.GetObject(L, 2, typeof(IFramework.Serialization.DataTable.IDataRow));
                    IFramework.Serialization.DataTable.IDataExplainer _explainer = (IFramework.Serialization.DataTable.IDataExplainer)translator.GetObject(L, 3, typeof(IFramework.Serialization.DataTable.IDataExplainer));
                    
                        IFramework.Serialization.DataTable.IDataWriter gen_ret = IFramework.Serialization.DataTable.DataTableTool.CreateWriter( _streamWriter, _rowWriter, _explainer );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
