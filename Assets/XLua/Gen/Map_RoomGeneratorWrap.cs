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
    public class MapRoomGeneratorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Map.RoomGenerator);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 20, 20);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SortMap", _m_SortMap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "destroyRooms", _m_destroyRooms);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangePointPos", _m_ChangePointPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetupRoom", _m_SetupRoom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setRoomInfo", _m_setRoomInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "switchRoom", _m_switchRoom);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "player", _g_get_player);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playeRoom", _g_get_playeRoom);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roominfo", _g_get_roominfo);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "direction", _g_get_direction);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roomPrefab", _g_get_roomPrefab);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roomNumber", _g_get_roomNumber);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startColor", _g_get_startColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endColor", _g_get_endColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "generatorPoint", _g_get_generatorPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "xOffset", _g_get_xOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "yOffset", _g_get_yOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roomLayer", _g_get_roomLayer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "theCloneRooms", _g_get_theCloneRooms);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rooms", _g_get_rooms);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rooMap", _g_get_rooMap);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "wallType", _g_get_wallType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isFirstFloor", _g_get_isFirstFloor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "t", _g_get_t);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BoosRoom", _g_get_BoosRoom);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Rooms", _g_get_Rooms);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "player", _s_set_player);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playeRoom", _s_set_playeRoom);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roominfo", _s_set_roominfo);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "direction", _s_set_direction);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roomPrefab", _s_set_roomPrefab);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roomNumber", _s_set_roomNumber);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startColor", _s_set_startColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endColor", _s_set_endColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "generatorPoint", _s_set_generatorPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "xOffset", _s_set_xOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "yOffset", _s_set_yOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roomLayer", _s_set_roomLayer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "theCloneRooms", _s_set_theCloneRooms);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rooms", _s_set_rooms);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rooMap", _s_set_rooMap);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "wallType", _s_set_wallType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isFirstFloor", _s_set_isFirstFloor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "t", _s_set_t);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "BoosRoom", _s_set_BoosRoom);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Rooms", _s_set_Rooms);
            
			
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
					
					var gen_ret = new Map.RoomGenerator();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Map.RoomGenerator constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortMap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.GameObject> _r = (System.Collections.Generic.List<UnityEngine.GameObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.GameObject>));
                    
                    gen_to_be_invoked.SortMap( _r );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_destroyRooms(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.destroyRooms(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangePointPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ChangePointPos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetupRoom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Room _newRoom = (Room)translator.GetObject(L, 2, typeof(Room));
                    UnityEngine.Vector3 _roomPosition;translator.Get(L, 3, out _roomPosition);
                    
                        var gen_ret = gen_to_be_invoked.SetupRoom( _newRoom, _roomPosition );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setRoomInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Room _room = (Room)translator.GetObject(L, 2, typeof(Room));
                    RoomIdentity _rinfo = (RoomIdentity)translator.GetObject(L, 3, typeof(RoomIdentity));
                    
                    gen_to_be_invoked.setRoomInfo( _room, _rinfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_switchRoom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _doorName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.switchRoom( _doorName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_player(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.player);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playeRoom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.playeRoom);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roominfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.roominfo);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_direction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.direction);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roomPrefab(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.roomPrefab);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roomNumber(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.roomNumber);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.startColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.endColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_generatorPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.generatorPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_xOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.xOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_yOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.yOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roomLayer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.roomLayer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_theCloneRooms(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.theCloneRooms);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rooms(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rooms);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rooMap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rooMap);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wallType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.wallType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isFirstFloor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isFirstFloor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_t(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.t);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BoosRoom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.BoosRoom);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Rooms(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Rooms);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_player(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.player = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playeRoom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playeRoom = (Room)translator.GetObject(L, 2, typeof(Room));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roominfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roominfo = (RoomIdentity)translator.GetObject(L, 2, typeof(RoomIdentity));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_direction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                Map.RoomGenerator.Direction gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.direction = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roomPrefab(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roomPrefab = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roomNumber(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roomNumber = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.endColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_generatorPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.generatorPoint = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_xOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.xOffset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_yOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.yOffset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roomLayer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                UnityEngine.LayerMask gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.roomLayer = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_theCloneRooms(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.theCloneRooms = (System.Collections.Generic.List<UnityEngine.GameObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.GameObject>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rooms(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rooms = (System.Collections.Generic.List<Room>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Room>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rooMap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rooMap = (System.Collections.Generic.Dictionary<UnityEngine.Vector2, Room>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<UnityEngine.Vector2, Room>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wallType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.wallType = (Map.WallType)translator.GetObject(L, 2, typeof(Map.WallType));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isFirstFloor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isFirstFloor = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_t(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.t = (RoomIdentity)translator.GetObject(L, 2, typeof(RoomIdentity));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BoosRoom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.BoosRoom = (RoomIdentity)translator.GetObject(L, 2, typeof(RoomIdentity));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Rooms(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Map.RoomGenerator gen_to_be_invoked = (Map.RoomGenerator)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Rooms = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
