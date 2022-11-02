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
using IFramework;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class IFrameworkUIGuideMaskWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.UI.GuideMask);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 9, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRect", _m_SetRect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRadian", _m_SetRadian);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFocusRect", _m_GetFocusRect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Focus", _m_Focus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsRaycastLocationValid", _m_IsRaycastLocationValid);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MakeComponentExist", _m_MakeComponentExist);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RmoveComponent", _m_RmoveComponent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LocalIdentity", _m_LocalIdentity);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "center", _g_get_center);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "size", _g_get_size);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rect", _g_get_rect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "raycastInRect", _g_get_raycastInRect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "raycastPass", _g_get_raycastPass);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "margin", _g_get_margin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "radian", _g_get_radian);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "background", _g_get_background);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "color", _g_get_color);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "raycastInRect", _s_set_raycastInRect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "raycastPass", _s_set_raycastPass);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "margin", _s_set_margin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "background", _s_set_background);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "color", _s_set_color);
            
			
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
					
					var gen_ret = new IFramework.UI.GuideMask();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.GuideMask constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rect _rect;translator.Get(L, 2, out _rect);
                    
                    gen_to_be_invoked.SetRect( _rect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRadian(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _radian = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetRadian( _radian );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFocusRect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.RectTransform>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)) 
                {
                    UnityEngine.RectTransform _trans = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
                    UnityEngine.Vector2 _offset;translator.Get(L, 3, out _offset);
                    
                        var gen_ret = gen_to_be_invoked.GetFocusRect( _trans, _offset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Transform>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& translator.Assignable<UnityEngine.Camera>(L, 4)) 
                {
                    UnityEngine.Transform _trans = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Vector2 _size;translator.Get(L, 3, out _size);
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 4, typeof(UnityEngine.Camera));
                    
                        var gen_ret = gen_to_be_invoked.GetFocusRect( _trans, _size, _camera );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.GuideMask.GetFocusRect!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Focus(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.RectTransform>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)) 
                {
                    UnityEngine.RectTransform _trans = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
                    UnityEngine.Vector2 _offset;translator.Get(L, 3, out _offset);
                    
                    gen_to_be_invoked.Focus( _trans, _offset );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Transform>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& translator.Assignable<UnityEngine.Camera>(L, 4)) 
                {
                    UnityEngine.Transform _trans = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Vector2 _size;translator.Get(L, 3, out _size);
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 4, typeof(UnityEngine.Camera));
                    
                    gen_to_be_invoked.Focus( _trans, _size, _camera );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.GuideMask.Focus!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsRaycastLocationValid(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _sp;translator.Get(L, 2, out _sp);
                    UnityEngine.Camera _eventCamera = (UnityEngine.Camera)translator.GetObject(L, 3, typeof(UnityEngine.Camera));
                    
                        var gen_ret = gen_to_be_invoked.IsRaycastLocationValid( _sp, _eventCamera );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeComponentExist(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.MakeComponentExist(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RmoveComponent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RmoveComponent(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LocalIdentity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.LocalIdentity(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.center);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.size);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_raycastInRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.raycastInRect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_raycastPass(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.raycastPass);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_margin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.margin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_radian(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.radian);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_background(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.background);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_raycastInRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.raycastInRect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_raycastPass(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.raycastPass = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_margin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.margin = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_background(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.background = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.GuideMask gen_to_be_invoked = (IFramework.UI.GuideMask)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
