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
    public class IFrameworkUISuperScrollViewLoopListViewWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.UI.SuperScrollView.LoopListView);
			Utils.BeginObjectRegister(type, L, translator, 0, 31, 18, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetShownItemByIndex", _m_GetShownItemByIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetShownItemByIndexWithoutCheck", _m_GetShownItemByIndexWithoutCheck);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIndexInShownItemList", _m_GetIndexInShownItemList);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoActionForEachShownItem", _m_DoActionForEachShownItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NewListViewItem", _m_NewListViewItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnItemSizeChanged", _m_OnItemSizeChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshItemByItemIndex", _m_RefreshItemByItemIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FinishSnapImmediately", _m_FinishSnapImmediately);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MovePanelToItemIndex", _m_MovePanelToItemIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshAllShownItem", _m_RefreshAllShownItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshAllShownItemWithFirstIndex", _m_RefreshAllShownItemWithFirstIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshAllShownItemWithFirstIndexAndPos", _m_RefreshAllShownItemWithFirstIndexAndPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemCornerPosInViewPort", _m_GetItemCornerPosInViewPort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateAllShownItemSnapData", _m_UpdateAllShownItemSnapData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearSnapData", _m_ClearSnapData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSnapTargetItemIndex", _m_SetSnapTargetItemIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetItemPrefabConfData", _m_SetItemPrefabConfData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateListView", _m_UpdateListView);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForceSnapUpdateCheck", _m_ForceSnapUpdateCheck);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemPrefabConfData", _m_GetItemPrefabConfData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnItemPrefabChanged", _m_OnItemPrefabChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitListView", _m_InitListView);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetListView", _m_ResetListView);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetListItemCount", _m_SetListItemCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetShownItemByItemIndex", _m_GetShownItemByItemIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeginDrag", _m_OnBeginDrag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEndDrag", _m_OnEndDrag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrag", _m_OnDrag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MakeComponentExist", _m_MakeComponentExist);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RmoveComponent", _m_RmoveComponent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LocalIdentity", _m_LocalIdentity);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "arrangeType", _g_get_arrangeType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "snapEnable", _g_get_snapEnable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "supportScrollBar", _g_get_supportScrollBar);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vertical", _g_get_vertical);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "totalCount", _g_get_totalCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "content", _g_get_content);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scroll", _g_get_scroll);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "draging", _g_get_draging);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shownItemCount", _g_get_shownItemCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "viewPortSize", _g_get_viewPortSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "viewPortWidth", _g_get_viewPortWidth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "viewPortHeight", _g_get_viewPortHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "curSnapNearestItemIndex", _g_get_curSnapNearestItemIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onSnapFinished", _g_get_onSnapFinished);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onSnapNearestChanged", _g_get_onSnapNearestChanged);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onBeginDrag", _g_get_onBeginDrag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDraging", _g_get_onDraging);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onEndDrag", _g_get_onEndDrag);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "arrangeType", _s_set_arrangeType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "snapEnable", _s_set_snapEnable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "supportScrollBar", _s_set_supportScrollBar);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onSnapFinished", _s_set_onSnapFinished);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onSnapNearestChanged", _s_set_onSnapNearestChanged);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onBeginDrag", _s_set_onBeginDrag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDraging", _s_set_onDraging);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onEndDrag", _s_set_onEndDrag);
            
			
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
					
					var gen_ret = new IFramework.UI.SuperScrollView.LoopListView();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.SuperScrollView.LoopListView constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShownItemByIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetShownItemByIndex( _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShownItemByIndexWithoutCheck(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetShownItemByIndexWithoutCheck( _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIndexInShownItemList(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.UI.SuperScrollView.LoopListViewItem _item = (IFramework.UI.SuperScrollView.LoopListViewItem)translator.GetObject(L, 2, typeof(IFramework.UI.SuperScrollView.LoopListViewItem));
                    
                        var gen_ret = gen_to_be_invoked.GetIndexInShownItemList( _item );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoActionForEachShownItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<IFramework.UI.SuperScrollView.LoopListViewItem, object> _action = translator.GetDelegate<System.Action<IFramework.UI.SuperScrollView.LoopListViewItem, object>>(L, 2);
                    object _param = translator.GetObject(L, 3, typeof(object));
                    
                    gen_to_be_invoked.DoActionForEachShownItem( _action, _param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewListViewItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.NewListViewItem( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnItemSizeChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _itemIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.OnItemSizeChanged( _itemIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshItemByItemIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _itemIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.RefreshItemByItemIndex( _itemIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishSnapImmediately(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FinishSnapImmediately(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MovePanelToItemIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _itemIndex = LuaAPI.xlua_tointeger(L, 2);
                    float _offset = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.MovePanelToItemIndex( _itemIndex, _offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshAllShownItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RefreshAllShownItem(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshAllShownItemWithFirstIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _firstItemIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.RefreshAllShownItemWithFirstIndex( _firstItemIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshAllShownItemWithFirstIndexAndPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _firstItemIndex = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Vector3 _pos;translator.Get(L, 3, out _pos);
                    
                    gen_to_be_invoked.RefreshAllShownItemWithFirstIndexAndPos( _firstItemIndex, _pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemCornerPosInViewPort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<IFramework.UI.SuperScrollView.LoopListViewItem>(L, 2)&& translator.Assignable<IFramework.UI.SuperScrollView.LoopListView.CornerEnum>(L, 3)) 
                {
                    IFramework.UI.SuperScrollView.LoopListViewItem _item = (IFramework.UI.SuperScrollView.LoopListViewItem)translator.GetObject(L, 2, typeof(IFramework.UI.SuperScrollView.LoopListViewItem));
                    IFramework.UI.SuperScrollView.LoopListView.CornerEnum _corner;translator.Get(L, 3, out _corner);
                    
                        var gen_ret = gen_to_be_invoked.GetItemCornerPosInViewPort( _item, _corner );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<IFramework.UI.SuperScrollView.LoopListViewItem>(L, 2)) 
                {
                    IFramework.UI.SuperScrollView.LoopListViewItem _item = (IFramework.UI.SuperScrollView.LoopListViewItem)translator.GetObject(L, 2, typeof(IFramework.UI.SuperScrollView.LoopListViewItem));
                    
                        var gen_ret = gen_to_be_invoked.GetItemCornerPosInViewPort( _item );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.SuperScrollView.LoopListView.GetItemCornerPosInViewPort!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAllShownItemSnapData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateAllShownItemSnapData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearSnapData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearSnapData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSnapTargetItemIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _itemIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetSnapTargetItemIndex( _itemIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetItemPrefabConfData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<IFramework.UI.SuperScrollView.LoopListView.PrefabConfData> _itemPrefabConfDatas = (System.Collections.Generic.List<IFramework.UI.SuperScrollView.LoopListView.PrefabConfData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<IFramework.UI.SuperScrollView.LoopListView.PrefabConfData>));
                    
                    gen_to_be_invoked.SetItemPrefabConfData( _itemPrefabConfDatas );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateListView(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _distanceForRecycle0 = (float)LuaAPI.lua_tonumber(L, 2);
                    float _distanceForRecycle1 = (float)LuaAPI.lua_tonumber(L, 3);
                    float _distanceForNew0 = (float)LuaAPI.lua_tonumber(L, 4);
                    float _distanceForNew1 = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    gen_to_be_invoked.UpdateListView( _distanceForRecycle0, _distanceForRecycle1, _distanceForNew0, _distanceForNew1 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceSnapUpdateCheck(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ForceSnapUpdateCheck(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemPrefabConfData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemPrefabConfData( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnItemPrefabChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.OnItemPrefabChanged( _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitListView(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<System.Func<string, UnityEngine.RectTransform, UnityEngine.GameObject>>(L, 2)&& translator.Assignable<System.Action<UnityEngine.GameObject>>(L, 3)&& translator.Assignable<System.Func<IFramework.UI.SuperScrollView.LoopListView, int, IFramework.UI.SuperScrollView.LoopListViewItem>>(L, 4)&& translator.Assignable<IFramework.UI.SuperScrollView.LoopListView.InitParam>(L, 5)) 
                {
                    System.Func<string, UnityEngine.RectTransform, UnityEngine.GameObject> _create = translator.GetDelegate<System.Func<string, UnityEngine.RectTransform, UnityEngine.GameObject>>(L, 2);
                    System.Action<UnityEngine.GameObject> _set = translator.GetDelegate<System.Action<UnityEngine.GameObject>>(L, 3);
                    System.Func<IFramework.UI.SuperScrollView.LoopListView, int, IFramework.UI.SuperScrollView.LoopListViewItem> _onGetItemByIndex = translator.GetDelegate<System.Func<IFramework.UI.SuperScrollView.LoopListView, int, IFramework.UI.SuperScrollView.LoopListViewItem>>(L, 4);
                    IFramework.UI.SuperScrollView.LoopListView.InitParam _initParam = (IFramework.UI.SuperScrollView.LoopListView.InitParam)translator.GetObject(L, 5, typeof(IFramework.UI.SuperScrollView.LoopListView.InitParam));
                    
                    gen_to_be_invoked.InitListView( _create, _set, _onGetItemByIndex, _initParam );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<System.Func<string, UnityEngine.RectTransform, UnityEngine.GameObject>>(L, 2)&& translator.Assignable<System.Action<UnityEngine.GameObject>>(L, 3)&& translator.Assignable<System.Func<IFramework.UI.SuperScrollView.LoopListView, int, IFramework.UI.SuperScrollView.LoopListViewItem>>(L, 4)) 
                {
                    System.Func<string, UnityEngine.RectTransform, UnityEngine.GameObject> _create = translator.GetDelegate<System.Func<string, UnityEngine.RectTransform, UnityEngine.GameObject>>(L, 2);
                    System.Action<UnityEngine.GameObject> _set = translator.GetDelegate<System.Action<UnityEngine.GameObject>>(L, 3);
                    System.Func<IFramework.UI.SuperScrollView.LoopListView, int, IFramework.UI.SuperScrollView.LoopListViewItem> _onGetItemByIndex = translator.GetDelegate<System.Func<IFramework.UI.SuperScrollView.LoopListView, int, IFramework.UI.SuperScrollView.LoopListViewItem>>(L, 4);
                    
                    gen_to_be_invoked.InitListView( _create, _set, _onGetItemByIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.SuperScrollView.LoopListView.InitListView!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetListView(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ResetListView(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetListItemCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    int _itemCount = LuaAPI.xlua_tointeger(L, 2);
                    bool _resetPos = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetListItemCount( _itemCount, _resetPos );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _itemCount = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetListItemCount( _itemCount );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.UI.SuperScrollView.LoopListView.SetListItemCount!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShownItemByItemIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _itemIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetShownItemByItemIndex( _itemIndex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBeginDrag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnBeginDrag( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEndDrag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnEndDrag( _eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.EventSystems.PointerEventData _eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    gen_to_be_invoked.OnDrag( _eventData );
                    
                    
                    
                    return 0;
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
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_arrangeType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.arrangeType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_snapEnable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.snapEnable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_supportScrollBar(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.supportScrollBar);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertical(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.vertical);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_totalCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.totalCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_content(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.content);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scroll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.scroll);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_draging(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.draging);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shownItemCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.shownItemCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_viewPortSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.viewPortSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_viewPortWidth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.viewPortWidth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_viewPortHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.viewPortHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_curSnapNearestItemIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.curSnapNearestItemIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSnapFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onSnapFinished);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSnapNearestChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onSnapNearestChanged);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onBeginDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onBeginDrag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDraging(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDraging);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onEndDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onEndDrag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_arrangeType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                IFramework.UI.SuperScrollView.LoopListView.ArrangeType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.arrangeType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_snapEnable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.snapEnable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_supportScrollBar(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.supportScrollBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSnapFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onSnapFinished = translator.GetDelegate<System.Action<IFramework.UI.SuperScrollView.LoopListView, IFramework.UI.SuperScrollView.LoopListViewItem>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSnapNearestChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onSnapNearestChanged = translator.GetDelegate<System.Action<IFramework.UI.SuperScrollView.LoopListView, IFramework.UI.SuperScrollView.LoopListViewItem>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onBeginDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onBeginDrag = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDraging(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDraging = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onEndDrag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.UI.SuperScrollView.LoopListView gen_to_be_invoked = (IFramework.UI.SuperScrollView.LoopListView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onEndDrag = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
