using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Melee
{
    public class IridiumNeedle : ModProjectile
    {
        public override void SetDefaults()
        {
            // 弹幕负责长矛的近战判定，持续时间由使用动画控制
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.scale = 1.2f;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 99999;
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.ownerHitCheck = true;
            // 每个敌怪分别计算受击间隔
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            // 玩家不再持有依针时结束手持弹幕
            if (!player.active || player.dead || player.HeldItem.type != ModContent.ItemType<Items.Weapons.Melee.IridiumNeedle>())
            {
                Projectile.Kill();
                return;
            }

            // ai[1] 同步使用动画，让其他玩家也能看到刺出和收回
            float itemAnimation = player.itemAnimation;
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    if (Projectile.ai[1] != itemAnimation)
                    {
                        Projectile.ai[1] = itemAnimation;
                        Projectile.netUpdate = true;
                    }
                }
                else
                {
                    itemAnimation = Projectile.ai[1] > 0f ? Projectile.ai[1] : Math.Max(1f, player.itemAnimationMax);
                }
            }

            // 将弹幕设为玩家当前手持的弹幕
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.itemTime = player.itemAnimation;

            // ai[0] 是长矛沿发射方向伸出的距离系数
            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter);
            Projectile.position += Projectile.velocity * Projectile.ai[0];

            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[0] = 3f;
                Projectile.netUpdate = true;
            }

            // 使用动画的最后三分之一开始收回长矛
            if (itemAnimation < Math.Max(1f, player.itemAnimationMax) / 3f)
                Projectile.ai[0] -= 1f;
            else
                Projectile.ai[0] += 0.75f;

            if (itemAnimation <= 1f)
            {
                Projectile.Kill();
                return;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.ModifyHitInfo += Modifiers_ModifyHitInfo;
        }

        private void Modifiers_ModifyHitInfo(ref NPC.HitInfo info)
        {
            // 暴击时沿用依针原有的四倍伤害
            if (info.Crit)
                info.Damage *= 4;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // 在矛尖位置生成紫晶粒子
            Vector2 direction = Projectile.velocity.SafeNormalize(Vector2.UnitX);
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(
                    Projectile.Center + direction * (float)Math.Sqrt(Projectile.width * Projectile.height) * Projectile.scale,
                    2, 2, DustID.PurpleCrystalShard, 0f, 0f, 100, default, 1f);
                dust.velocity = Main.rand.NextVector2Circular(5f, 5f) - Projectile.velocity;
                dust.noGravity = true;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            // 以贴图左下方的握柄位置为绘制原点
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, lightColor,
                Projectile.rotation, new Vector2(6f, 36f), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
