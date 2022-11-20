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
    public class EasyMobaGameLogicBattleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(EasyMoba.GameLogic.Battle);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 2, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCurFrame", _m_GetCurFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMapData", _m_SetMapData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartGame", _m_StartGame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseGame", _m_CloseGame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadFrame", _m_ReadFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartPlayLogic", _m_StartPlayLogic);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Role_id", _g_get_Role_id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Room_id", _g_get_Room_id);
            
			
			
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
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<EasyMoba.GameLogic.IBattleView>(L, 2) && translator.Assignable<LockStep.LCollision2D.CollisionLayerConfig>(L, 3))
				{
					EasyMoba.GameLogic.IBattleView _monoBattle = (EasyMoba.GameLogic.IBattleView)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.IBattleView));
					LockStep.LCollision2D.CollisionLayerConfig _collision = (LockStep.LCollision2D.CollisionLayerConfig)translator.GetObject(L, 3, typeof(LockStep.LCollision2D.CollisionLayerConfig));
					
					var gen_ret = new EasyMoba.GameLogic.Battle(_monoBattle, _collision);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EasyMoba.GameLogic.Battle constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetCurFrame(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMapData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    EasyMoba.GameLogic.MapInitData _map_data = (EasyMoba.GameLogic.MapInitData)translator.GetObject(L, 2, typeof(EasyMoba.GameLogic.MapInitData));
                    
                    gen_to_be_invoked.SetMapData( _map_data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartGame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _role_id = LuaAPI.lua_toint64(L, 2);
                    string _room_id = LuaAPI.lua_tostring(L, 3);
                    MatchRoomType _type;translator.Get(L, 4, out _type);
                    System.Collections.Generic.List<BattlePlayer> _players = (System.Collections.Generic.List<BattlePlayer>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<BattlePlayer>));
                    
                    gen_to_be_invoked.StartGame( _role_id, _room_id, _type, _players );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseGame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CloseGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    SPBattleFrame _obj = (SPBattleFrame)translator.GetObject(L, 2, typeof(SPBattleFrame));
                    
                    gen_to_be_invoked.ReadFrame( _obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartPlayLogic(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    SPBattleAllReady _obj = (SPBattleAllReady)translator.GetObject(L, 2, typeof(SPBattleAllReady));
                    
                    gen_to_be_invoked.StartPlayLogic( _obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Role_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.Role_id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Room_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                EasyMoba.GameLogic.Battle gen_to_be_invoked = (EasyMoba.GameLogic.Battle)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Room_id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
