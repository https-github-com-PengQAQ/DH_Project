using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
namespace G
{
    [Hotfix]
    [LuaCallCSharp]
    public static class Global
    {
        /// <summary>
        /// 人物属性变化
        /// </summary>
        public static GameObject Player;        //主角
        public static int choose;               //近战为0，远程为1
        public static int Gold;                 //金币
        public static int life;                 //生命
        public static int attack;               //攻击力
        public static float speed;              //速度
        public static float attackSpeed;        //攻击速度
        public static int jumpCount;            //跳跃次数

        /// <summary>
        /// 敌人属性变化
        /// </summary>
        public static int enemyLife;            //敌人基础生命
        public static int enemyAttack;          //敌人基础攻击力
        public static bool isBoom;              //死亡爆炸是否会对玩家造成伤害
        public static int coin;                 //死亡掉落钱币多少



        /// <summary>
        /// 每次一进游戏进行数值初始化
        /// </summary>
        public static void init()
        {
            Gold = 0;
            life = 10;
            attack = 1;
            speed = 5;
        }


    }
}