using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Melee
{
    public class PipeTomahawk : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 23; // 投射物碰撞箱宽度
            Projectile.height = 20; // 投射物碰撞箱高度
            Projectile.scale = 1f; // 缩放
            Projectile.friendly = true; // 是否对敌怪造成伤害
            Projectile.hostile = false; // 是否对玩家造成伤害
            Projectile.penetrate = 3; // 穿透次数，-1 表示无限穿透
            Projectile.tileCollide = true; // 是否与方块碰撞
            Projectile.timeLeft = 300;//存在时间
            Projectile.aiStyle = -1; // AI 类型，-1 表示自定义
            //AIType = ProjectileID.WoodenBoomerang; // 使用回旋镖的 AI
            Projectile.alpha = 0; // 透明度
            Projectile.tileCollide = false; // 允许穿墙
            Projectile.usesLocalNPCImmunity = false;//独立无敌帧
            //Projectile.localNPCHitCooldown = 10;//独立无敌帧时间
        }

        Player player => Main.player[Projectile.owner]; // 获取发射该投射物的玩家
        public override void AI()//弹幕AI
        {
            Projectile.ai[0] += 1f;//计时器
            if (Projectile.ai[0] >= 60f)//如果计时器大于等于60帧
            {
                Projectile.Center -= Projectile.velocity;//回到原来的位置
            }

            if (player.direction == 1)//如果玩家面朝右方
            {
                Projectile.rotation += 0.1f;//设置旋转角度
            }
            else if (player.direction == -1)//如果玩家面朝左方
            {
                Projectile.rotation += -0.1f;//设置旋转角度
                Projectile.direction = Projectile.spriteDirection = -1;//翻转弹幕
            }
        }

        public override void OnSpawn(IEntitySource source) // 当投射物生成时调用
        {
            if (player.altFunctionUse == 1)
            {
                if (player.direction == 1)
                {
                    Projectile.rotation = 0.785f;//设置旋转角度
                }
                else if (player.direction == -1)
                {
                    Projectile.rotation = -0.785f;//设置旋转角度
                    Projectile.direction = Projectile.spriteDirection = -1;//翻转弹幕
                }
            }

            if (player.altFunctionUse == 2)
            {

            }
        }

        public override bool PreDraw(ref Color lightColor)//弹幕绘制
        {
            if (player.direction == -1)//如果玩家面朝左方
            {
                return true;
            }
            return base.PreDraw(ref lightColor);
        }
    }
}
