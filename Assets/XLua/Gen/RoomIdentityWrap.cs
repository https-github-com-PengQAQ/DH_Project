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
    public class RoomIdentityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(RoomIdentity);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 23, 23);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "init", _m_init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "mapGameStart", _m_mapGameStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "mapGameEnd", _m_mapGameEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "doorOpenOrClose", _m_doorOpenOrClose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "propInstance", _m_propInstance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "bossInstance", _m_bossInstance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "toNextFloor", _m_toNextFloor);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "pos1", _g_get_pos1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pos2", _g_get_pos2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pos3", _g_get_pos3);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pos4", _g_get_pos4);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startPos", _g_get_startPos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pe", _g_get_pe);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "up", _g_get_up);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "down", _g_get_down);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "right", _g_get_right);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "left", _g_get_left);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "doors", _g_get_doors);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bo", _g_get_bo);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localCount", _g_get_localCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isFirst", _g_get_isFirst);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flag", _g_get_flag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "propPos", _g_get_propPos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "count", _g_get_count);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enemyGroundPos", _g_get_enemyGroundPos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enemyFlyPos", _g_get_enemyFlyPos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enemyGround", _g_get_enemyGround);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enemyFly", _g_get_enemyFly);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "enemyList", _g_get_enemyList);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Boss", _g_get_Boss);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "pos1", _s_set_pos1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pos2", _s_set_pos2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pos3", _s_set_pos3);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pos4", _s_set_pos4);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startPos", _s_set_startPos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pe", _s_set_pe);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "up", _s_set_up);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "down", _s_set_down);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "right", _s_set_right);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "left", _s_set_left);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "doors", _s_set_doors);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bo", _s_set_bo);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "localCount", _s_set_localCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isFirst", _s_set_isFirst);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flag", _s_set_flag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "propPos", _s_set_propPos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "count", _s_set_count);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enemyGroundPos", _s_set_enemyGroundPos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enemyFlyPos", _s_set_enemyFlyPos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enemyGround", _s_set_enemyGround);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enemyFly", _s_set_enemyFly);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "enemyList", _s_set_enemyList);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Boss", _s_set_Boss);
            
			
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
					
					var gen_ret = new RoomIdentity();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to RoomIdentity constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_mapGameStart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.mapGameStart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_mapGameEnd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.mapGameEnd(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_doorOpenOrClose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _flag = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.doorOpenOrClose( _flag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_propInstance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.propInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_bossInstance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.bossInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_toNextFloor(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.toNextFloor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pos1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pos1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pos2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pos2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pos3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pos3);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pos4(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pos4);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.startPos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pe(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pe);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_up(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.up);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_down(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.down);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_right(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.right);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_left(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.left);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_doors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.doors);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.bo);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.localCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isFirst(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isFirst);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.flag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_propPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.propPos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.count);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyGroundPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.enemyGroundPos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyFlyPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.enemyFlyPos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyGround(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.enemyGround);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyFly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.enemyFly);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyList(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.enemyList);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Boss(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Boss);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pos1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pos1 = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pos2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pos2 = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pos3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pos3 = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pos4(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pos4 = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startPos = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pe(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pe = (UnityEngine.PlatformEffector2D)translator.GetObject(L, 2, typeof(UnityEngine.PlatformEffector2D));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_up(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.up = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_down(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.down = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_right(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.right = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_left(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.left = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_doors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.doors = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bo = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.localCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isFirst(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isFirst = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flag = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_propPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.propPos = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.count = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyGroundPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enemyGroundPos = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyFlyPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enemyFlyPos = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyGround(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enemyGround = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyFly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enemyFly = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyList(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.enemyList = (System.Collections.Generic.List<UnityEngine.GameObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.GameObject>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Boss(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RoomIdentity gen_to_be_invoked = (RoomIdentity)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Boss = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
