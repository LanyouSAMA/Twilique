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
    public class IridiumNeedle : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 42; // 投射物碰撞箱宽度
            Projectile.height = 42; // 投射物碰撞箱高度
            Projectile.scale = 1.2f; // 缩放
            Projectile.friendly = true; // 是否对敌怪造成伤害
            Projectile.hostile = false; // 是否对玩家造成伤害
            Projectile.penetrate = -1; // 穿透次数，-1 表示无限穿透
            Projectile.tileCollide = false; // 是否与方块碰撞
            Projectile.timeLeft = 99999; // 存在时间，实际由 AI 控制
            Projectile.aiStyle = -1; // AI 类型，-1 表示自定义
            Projectile.alpha = 0; // 透明度
            Projectile.tileCollide = false; // 允许穿墙

            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
        }

        Player player => Main.player[Projectile.owner]; // 该投射物所属玩家

        public override void OnSpawn(IEntitySource source) // 投射物生成时执行
        {
            Projectile.Center -= Projectile.velocity; // 出生时沿初速度方向回退一格
            Projectile.rotation += 0.785f; // 由于贴图是斜的，初始顺时针旋转 45 度
        }

        public override void AI() // 每帧执行一次
        {
            // 强制维持使用动作
            player.itemTime = 2;

            // 从 ai[0] 读取蓄力/刺击计时器
            int stabTimer = (int)Projectile.ai[0];

            // 计算当前瞄准方向
            Vector2 aimDirection = (Main.MouseWorld - player.MountedCenter).SafeNormalize(Vector2.UnitX);

            // 玩家跟随瞄准方向转向
            if (aimDirection.X < 0)
            {
                player.direction = -1;
            }
            else
            {
                player.direction = 1;
            }

            bool holding = player.controlUseItem && !player.HeldItem.IsAir;

            stabTimer++;

            int mod = player.itemTimeMax > 0 ? player.itemTimeMax : 12;

            if (!holding && (stabTimer % mod == 0))
            {
                Projectile.Kill();
                return;
            }

            if (holding && (stabTimer % mod == 0))
            {
                float angleDeflect = Main.rand.NextFloat(-0.2f, 0.2f); // 角度偏转
                Vector2 stabDir = aimDirection.RotatedBy(angleDeflect);

                Projectile.Center = player.MountedCenter - stabDir * 21f;
                Projectile.velocity = stabDir * 9f;
            }

            // 刺击过程中做一个前推后收的节奏
            int phase = stabTimer % mod;
            if (phase < mod / 2)
            {
                Projectile.Center += Projectile.velocity * 0.5f; // 前推
            }
            else
            {
                Projectile.Center -= Projectile.velocity * 0.3f; // 回收
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + 0.785f; // 让投射物始终朝向运动方向
            Projectile.Center += player.velocity * 0.6f; // 跟随玩家移动


            // 让玩家手部动作跟随投射物朝向
            // 鼠标在玩家左侧时，将角度反转 180 度，避免贴图朝向和实际挥舞方向错位
            if (aimDirection.X < 0) player.itemRotation = Projectile.rotation - 0.785f + MathHelper.Pi;
            else player.itemRotation = Projectile.rotation - 0.785f;

            Projectile.ai[0] = stabTimer;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.ModifyHitInfo += Modifiers_ModifyHitInfo;
        }

        private void Modifiers_ModifyHitInfo(ref NPC.HitInfo info)
        {
            if (info.Crit)
            {
                info.Damage *= 4; // 暴击时伤害乘 4
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // 命中特效
            Vector2 dir = Projectile.velocity;
            if (dir.Length() < 0.1f)
                dir = (Main.MouseWorld - player.MountedCenter).SafeNormalize(Vector2.UnitX); // 速度过小时改用瞄准方向
            dir.Normalize();

            for (int i = 0; i < 15; i++)
            {
                var dust = Dust.NewDustDirect(
                    Projectile.Center + (Projectile.rotation - 0.785f).ToRotationVector2() * (float)Math.Sqrt(Projectile.width * Projectile.height) * Projectile.scale,
                    2, 2,
                    DustID.PurpleCrystalShard,
                    0f, 0f, 100, default, 1f);
                dust.velocity = Main.rand.NextVector2Circular(5f, 5f) + Projectile.velocity * -1f;
                dust.noGravity = true;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Main.EntitySpriteDraw(
                TextureAssets.Projectile[Type].Value,
                Projectile.Center - Main.screenPosition,
                new Rectangle(0, TextureAssets.Projectile[Type].Value.Height / Main.projFrames[Type] * Projectile.frame,
                    TextureAssets.Projectile[Type].Value.Width, TextureAssets.Projectile[Type].Value.Height),
                lightColor,
                Projectile.rotation,
                new Vector2(TextureAssets.Projectile[Type].Value.Width / 2, TextureAssets.Projectile[Type].Value.Height / 2 / Main.projFrames[Type]) +
                    ((float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.570f).ToRotationVector2(),
                new Vector2(1, 1),
                SpriteEffects.None, 0);

            return false; // 返回 false 阻止 tModLoader 使用默认绘制
        }
    }
}
