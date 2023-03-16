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
    public class LockStepLCollision2DNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LockStep.LCollision2D.Node);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 6, 6);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateMaxRadius", _m_UpdateMaxRadius);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HaveChildren", _m_HaveChildren);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddNode", _m_AddNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNode", _m_RemoveNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddShape", _m_AddShape);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NeedSplit", _m_NeedSplit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CouldAdd", _m_CouldAdd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChildren", _m_GetChildren);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "guid", _g_get_guid);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "parrent", _g_get_parrent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "area", _g_get_area);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shapes", _g_get_shapes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nodes", _g_get_nodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxRadius", _g_get_maxRadius);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "guid", _s_set_guid);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "parrent", _s_set_parrent);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "area", _s_set_area);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shapes", _s_set_shapes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nodes", _s_set_nodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxRadius", _s_set_maxRadius);
            
			
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
					
					var gen_ret = new LockStep.LCollision2D.Node();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LockStep.LCollision2D.Node constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateMaxRadius(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.UpdateMaxRadius(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HaveChildren(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.HaveChildren(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddNode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Node _node = (LockStep.LCollision2D.Node)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Node));
                    
                    gen_to_be_invoked.AddNode( _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Node _node = (LockStep.LCollision2D.Node)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Node));
                    
                    gen_to_be_invoked.RemoveNode( _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddShape(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.LCollision2D.Shape _shape = (LockStep.LCollision2D.Shape)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Shape));
                    
                    gen_to_be_invoked.AddShape( _shape );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NeedSplit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.NeedSplit(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CouldAdd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LockStep.Math.LVector2 _position;translator.Get(L, 2, out _position);
                    
                        var gen_ret = gen_to_be_invoked.CouldAdd( _position );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChildren(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetChildren(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_guid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.guid);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_parrent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.parrent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.area);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shapes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shapes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.maxRadius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_guid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                System.Guid gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.guid = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_parrent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.parrent = (LockStep.LCollision2D.Node)translator.GetObject(L, 2, typeof(LockStep.LCollision2D.Node));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                LockStep.Math.LRect gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.area = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shapes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shapes = (System.Collections.Generic.List<LockStep.LCollision2D.Shape>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LockStep.LCollision2D.Shape>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nodes = (System.Collections.Generic.List<LockStep.LCollision2D.Node>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LockStep.LCollision2D.Node>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LockStep.LCollision2D.Node gen_to_be_invoked = (LockStep.LCollision2D.Node)translator.FastGetCSObj(L, 1);
                LockStep.Math.LFloat gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.maxRadius = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
