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
    public class IFrameworkNetKCPBufferQueueWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.KCP.BufferQueue);
			Utils.BeginObjectRegister(type, L, translator, 0, 53, 6, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EnsureWritableBytes", _m_EnsureWritableBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TrimReadedBytes", _m_TrimReadedBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteBytes", _m_WriteBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Write", _m_Write);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteShort", _m_WriteShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUshort", _m_WriteUshort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteInt", _m_WriteInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUint", _m_WriteUint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteLong", _m_WriteLong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUlong", _m_WriteUlong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteFloat", _m_WriteFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteByte", _m_WriteByte);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteDouble", _m_WriteDouble);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteChar", _m_WriteChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteBoolean", _m_WriteBoolean);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadByte", _m_ReadByte);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUshort", _m_ReadUshort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadShort", _m_ReadShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUint", _m_ReadUint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadInt", _m_ReadInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUlong", _m_ReadUlong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadLong", _m_ReadLong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadFloat", _m_ReadFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadDouble", _m_ReadDouble);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadChar", _m_ReadChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadBoolean", _m_ReadBoolean);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadBytes", _m_ReadBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetByte", _m_GetByte);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDouble", _m_GetDouble);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFloat", _m_GetFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLong", _m_GetLong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUlong", _m_GetUlong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetInt", _m_GetInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUint", _m_GetUint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetShort", _m_GetShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUshort", _m_GetUshort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChar", _m_GetChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBoolean", _m_GetBoolean);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DiscardReadBytes", _m_DiscardReadBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MarkReaderIndex", _m_MarkReaderIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MarkWriterIndex", _m_MarkWriterIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetReaderIndex", _m_ResetReaderIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetWriterIndex", _m_ResetWriterIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToArray", _m_ToArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUTF8String", _m_WriteUTF8String);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUTF", _m_WriteUTF);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUTF8String", _m_ReadUTF8String);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUTF", _m_ReadUTF);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Copy", _m_Copy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clone", _m_Clone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForEach", _m_ForEach);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "reader", _g_get_reader);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "writer", _g_get_writer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canRead", _g_get_canRead);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canWrite", _g_get_canWrite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "capacity", _g_get_capacity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "buffer", _g_get_buffer);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "reader", _s_set_reader);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "writer", _s_set_writer);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Allocate", _m_Allocate_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "IFramework.Net.KCP.BufferQueue does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Allocate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    int _capacity = LuaAPI.xlua_tointeger(L, 1);
                    bool _fromPool = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = IFramework.Net.KCP.BufferQueue.Allocate( _capacity, _fromPool );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _capacity = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = IFramework.Net.KCP.BufferQueue.Allocate( _capacity );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 1);
                    bool _fromPool = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = IFramework.Net.KCP.BufferQueue.Allocate( _bytes, _fromPool );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 1);
                    
                        var gen_ret = IFramework.Net.KCP.BufferQueue.Allocate( _bytes );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.Allocate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnsureWritableBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _minBytes = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.EnsureWritableBytes( _minBytes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TrimReadedBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.TrimReadedBytes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    
                    gen_to_be_invoked.WriteBytes( _bytes );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.WriteBytes( _bytes, _length );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    int _startIndex = LuaAPI.xlua_tointeger(L, 3);
                    int _length = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.WriteBytes( _bytes, _startIndex, _length );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.WriteBytes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Write(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Net.KCP.BufferQueue _buffer = (IFramework.Net.KCP.BufferQueue)translator.GetObject(L, 2, typeof(IFramework.Net.KCP.BufferQueue));
                    
                    gen_to_be_invoked.Write( _buffer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteShort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteShort( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUshort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteUshort( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteInt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteInt( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    uint _value = LuaAPI.xlua_touint(L, 2);
                    
                    gen_to_be_invoked.WriteUint( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteLong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _value = LuaAPI.lua_toint64(L, 2);
                    
                    gen_to_be_invoked.WriteLong( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUlong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ulong _value = LuaAPI.lua_touint64(L, 2);
                    
                    gen_to_be_invoked.WriteUlong( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteFloat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.WriteFloat( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteByte(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteByte( _value );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteByte( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.WriteByte!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteDouble(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _value = LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.WriteDouble( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteChar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteChar( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteBoolean(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.WriteBoolean( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadByte(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadByte(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUshort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadUshort(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadShort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadShort(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadUint(  );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadInt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadInt(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUlong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadUlong(  );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadLong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadLong(  );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadFloat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadFloat(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadDouble(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadDouble(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadChar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadChar(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadBoolean(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadBoolean(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _len = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReadBytes( _len );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    int _len = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.ReadBytes( _index, _len );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    byte[] _disbytes = LuaAPI.lua_tobytes(L, 2);
                    int _disstart = LuaAPI.xlua_tointeger(L, 3);
                    int _len = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.ReadBytes( _disbytes, _disstart, _len );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.ReadBytes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetByte(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetByte(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetByte( _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetByte!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDouble(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetDouble(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDouble( _index );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetDouble!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFloat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetFloat(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFloat( _index );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetLong(  );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetLong( _index );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetLong!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUlong(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetUlong(  );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetUlong( _index );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetUlong!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetInt(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetInt( _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetInt!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetUint(  );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetUint( _index );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetUint!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetShort(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetShort( _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetShort!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUshort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetUshort(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetUshort( _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetUshort!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetChar(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetChar( _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetChar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBoolean(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.GetBoolean(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBoolean( _index );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.GetBoolean!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DiscardReadBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DiscardReadBytes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MarkReaderIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.MarkReaderIndex(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MarkWriterIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.MarkWriterIndex(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetReaderIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ResetReaderIndex(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetWriterIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ResetWriterIndex(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToArray(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ToArray(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUTF8String(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _content = LuaAPI.lua_tostring(L, 2);
                    IFramework.Net.KCP.BufferQueue.DataType _lenType;translator.Get(L, 3, out _lenType);
                    
                    gen_to_be_invoked.WriteUTF8String( _content, _lenType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUTF(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _content = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.WriteUTF( _content );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUTF8String(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _len = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReadUTF8String( _len );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<IFramework.Net.KCP.BufferQueue.DataType>(L, 2)) 
                {
                    IFramework.Net.KCP.BufferQueue.DataType _lenType;translator.Get(L, 2, out _lenType);
                    
                        var gen_ret = gen_to_be_invoked.ReadUTF8String( _lenType );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.KCP.BufferQueue.ReadUTF8String!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUTF(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ReadUTF(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Copy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.Copy(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.Clone(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForEach(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<byte> _action = translator.GetDelegate<System.Action<byte>>(L, 2);
                    
                    gen_to_be_invoked.ForEach( _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.reader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_writer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.writer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canRead(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.canRead);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canWrite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.canWrite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_capacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.capacity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_buffer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.buffer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_reader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.reader = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_writer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.KCP.BufferQueue gen_to_be_invoked = (IFramework.Net.KCP.BufferQueue)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.writer = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
