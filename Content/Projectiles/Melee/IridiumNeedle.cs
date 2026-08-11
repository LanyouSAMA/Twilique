using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Melee
{
    public class IridiumNeedle : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30; //同理，贴图的宽与高
            Projectile.scale = 1; //大小
            Projectile.friendly = true; //弹幕是否对敌方造成伤害
            Projectile.hostile = false; //弹幕是否对友方造成伤害
            Projectile.penetrate = -1; //弹幕可穿透的敌怪数量，设为-1则为无限
            Projectile.tileCollide = false; //弹幕能否受物块阻挡
            Projectile.timeLeft = 8; //弹幕自动消失的时间
            Projectile.aiStyle = -1; //弹幕模仿的AI。-1为无
            Projectile.alpha = 0; //弹幕的透明度
            Projectile.tileCollide = false; //使弹幕可以穿墙
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.ModifyHitInfo += Modifiers_ModifyHitInfo;
        }
        private void Modifiers_ModifyHitInfo(ref NPC.HitInfo info)
        {
            if (info.Crit)
            {
                info.Damage *= 4;
            }
        }

        Player player => Main.player[Projectile.owner]; //设置一个名为player的变量并将其记录为发射这个弹幕的玩家

        public override void OnSpawn(IEntitySource source) //OnSpawn钩子会在弹幕生成时执行
        {
            Projectile.Center -= Projectile.velocity; //使弹幕生成时在初始速度方向上倒退
            Projectile.rotation += 0.785f; //因为弹幕的贴图是斜着的，所以在生成时将弹幕顺时针旋转45度
        }
        public override void AI() //AI钩子会在弹幕存在的每一帧都执行一次
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + 0.785f; //使弹幕时刻朝向其运行方向
            Projectile.Center += player.velocity; //使弹幕始终跟随玩家
        }
    }
}