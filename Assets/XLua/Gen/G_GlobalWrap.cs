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
    public class GGlobalWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(G.Global);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 12, 12);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "init", _m_init_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Player", _g_get_Player);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "choose", _g_get_choose);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Gold", _g_get_Gold);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "life", _g_get_life);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "attack", _g_get_attack);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "speed", _g_get_speed);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "attackSpeed", _g_get_attackSpeed);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "jumpCount", _g_get_jumpCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enemyLife", _g_get_enemyLife);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enemyAttack", _g_get_enemyAttack);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isBoom", _g_get_isBoom);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "coin", _g_get_coin);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Player", _s_set_Player);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "choose", _s_set_choose);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Gold", _s_set_Gold);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "life", _s_set_life);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "attack", _s_set_attack);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "speed", _s_set_speed);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "attackSpeed", _s_set_attackSpeed);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "jumpCount", _s_set_jumpCount);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enemyLife", _s_set_enemyLife);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enemyAttack", _s_set_enemyAttack);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "isBoom", _s_set_isBoom);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "coin", _s_set_coin);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "G.Global does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_init_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    G.Global.init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Player(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, G.Global.Player);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_choose(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.choose);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Gold(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.Gold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_life(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.life);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_attack(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.attack);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_speed(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, G.Global.speed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_attackSpeed(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, G.Global.attackSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_jumpCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.jumpCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyLife(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.enemyLife);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enemyAttack(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.enemyAttack);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isBoom(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, G.Global.isBoom);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_coin(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, G.Global.coin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Player(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    G.Global.Player = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_choose(RealStatePtr L)
        {
		    try {
                
			    G.Global.choose = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Gold(RealStatePtr L)
        {
		    try {
                
			    G.Global.Gold = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_life(RealStatePtr L)
        {
		    try {
                
			    G.Global.life = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_attack(RealStatePtr L)
        {
		    try {
                
			    G.Global.attack = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_speed(RealStatePtr L)
        {
		    try {
                
			    G.Global.speed = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_attackSpeed(RealStatePtr L)
        {
		    try {
                
			    G.Global.attackSpeed = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_jumpCount(RealStatePtr L)
        {
		    try {
                
			    G.Global.jumpCount = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyLife(RealStatePtr L)
        {
		    try {
                
			    G.Global.enemyLife = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enemyAttack(RealStatePtr L)
        {
		    try {
                
			    G.Global.enemyAttack = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isBoom(RealStatePtr L)
        {
		    try {
                
			    G.Global.isBoom = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_coin(RealStatePtr L)
        {
		    try {
                
			    G.Global.coin = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
