using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Humanizer.In;

namespace Twilique.Content.Projectiles.Melee
{
    public class RustyHunter : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.scale = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 3600;
            Projectile.aiStyle = 0;
        }

        public bool HitTile { get { return HitTileNum != 0; } set { HitTileNum = value ? 1 : 0; } }
        int HitTileNum = 0;
        bool OldHitTile = false;

        public bool Sticking { get { return Projectile.ai[0] != 0; } set { Projectile.ai[0] = value ? 1 : 0; } }
        public int TargetWho { get { return (int)Projectile.ai[1]; } set { Projectile.ai[1] = value; } }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(HitTileNum);
            if (Main.netMode == NetmodeID.Server) OldHitTile = HitTile;
            writer.Write(stickOffset.X);
            writer.Write(stickOffset.Y);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                HitTileNum = reader.ReadInt32();
                stickOffset.X = reader.ReadSingle();
                stickOffset.Y = reader.ReadSingle();
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            for (int i = 0; i < 9; i++)
            {
                var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Iron, 0f, 0f, 80, default, 1.1f);
                dust.velocity = Projectile.velocity * 0.12f + Main.rand.NextVector2Circular(2.8f, 2.8f);
                dust.noGravity = false;
                dust.scale = Main.rand.NextFloat(0.9f, 1.35f);
            }

            if (Projectile.owner == Main.myPlayer)
            {
                int num = 0;
                foreach (Projectile projectile in Main.projectile)
                {
                    if (projectile.active && projectile.type == ModContent.ProjectileType<RustyHunter>() && projectile.owner == Main.myPlayer)
                    {
                        num++;
                        if (num > 5)
                        {
                            foreach (Projectile projectile2 in Main.projectile)
                            {
                                if (projectile2.active && projectile2.type == ModContent.ProjectileType<RustyHunter>() && projectile2.owner == Main.myPlayer)
                                {
                                    projectile2.ai[2] = 1f;
                                    projectile2.netUpdate = true;
                                }
                            }
                            Projectile.Kill();
                        }
                    }
                }
            }
        }

        private Vector2 stickOffset;

        public override void AI()
        {
            Player player1 = Main.player[Projectile.owner];
            if (Vector2.Distance(player1.Center, Projectile.Center) > 1000)
            {
                if (Sticking) Projectile.ai[2] = 1f;
                else HitTile = true;
            }

            if (Sticking)
            {
                if (TargetWho < 0 || TargetWho >= Main.maxNPCs) { Sticking = false; return; }

                NPC target = Main.npc[TargetWho];
                if (!target.active || target.friendly || target.life <= 0)
                {
                    HitTile = true;
                    Sticking = false;
                    return;
                }

                Projectile.tileCollide = false;

                if (Projectile.ai[2] == 1f)
                {
                    Player player = Main.player[Projectile.owner];
                    if (!target.boss && target.type != NPCID.TargetDummy && target.knockBackResist != 0)
                    {
                        target.SimpleStrikeNPC(Projectile.damage / 2, 0);
                        target.velocity = target.DirectionTo(player.Center) * 24f;
                    }
                    else target.SimpleStrikeNPC(Projectile.damage / 2, 0);
                    HitTile = true;
                    Sticking = false;
                    Main.LocalPlayer.GetModPlayer<ScreenMovePlayer>().ScreenShakeTimer = 5;
                    Main.LocalPlayer.GetModPlayer<ScreenMovePlayer>().ScreenShakeScale = 10;
                    SoundEngine.PlaySound(new SoundStyle("Twilique/Sounds/Chain"), Projectile.position);
                }
                else
                {
                    Projectile.Center = target.Center + stickOffset;
                    Projectile.velocity = Vector2.Zero;
                    Projectile.rotation = Projectile.rotation;
                }
            }
            else
            {
                Player player = Main.player[Projectile.owner];
                Projectile.velocity.Y += 0.1f;

                if (HitTile)
                {
                    float HitReturnSpeed = (Projectile.Center - player.Center).Length() / 5;
                    if (HitReturnSpeed < 1.5f * player.velocity.Length()) HitReturnSpeed = 1.5f * player.velocity.Length();
                    if (HitReturnSpeed < 12) HitReturnSpeed = 12;

                    Projectile.velocity = Projectile.DirectionTo(player.Center) * HitReturnSpeed;
                    Projectile.rotation += Projectile.velocity.Length() / 50;

                    if (Main.rand.NextBool(2))
                    {
                        Vector2 dustPos = Projectile.position + (Projectile.rotation + 1.57f).ToRotationVector2() * Projectile.height / 2;
                        var dust = Dust.NewDustPerfect(dustPos, DustID.Iron, Projectile.velocity * 0.15f, 100, default, 1.1f);
                        dust.velocity += Main.rand.NextVector2Circular(1.5f, 1.5f);
                        dust.noGravity = false;
                        dust.scale = Main.rand.NextFloat(0.7f, 1.25f);

                        if (Main.rand.NextBool(5))
                        {
                            var smoke = Dust.NewDustPerfect(dustPos, DustID.Smoke, Projectile.velocity * 0.1f, 120, default, 0.9f);
                            smoke.velocity *= 0.6f;
                            smoke.noGravity = true;
                        }
                    }
                    Projectile.tileCollide = false;
                    if (Vector2.Distance(player.Center, Projectile.Center) < 16) Projectile.Kill();
                }
                else Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Sticking = true;
            TargetWho = target.whoAmI;
            Projectile.hide = true;
            stickOffset = Projectile.Center - target.Center;
            Projectile.netUpdate = true;

            for (int i = 0; i < 6; i++)
            {
                var dust = Dust.NewDustDirect(target.position, target.width, target.height, DustID.Iron, 0f, 0f, 60, default, 1f);
                dust.velocity = Main.rand.NextVector2Circular(3f, 3f) + Projectile.velocity * 0.2f;
                dust.noGravity = false;
            }
        }

        public override void Kill(int timeLeft) { }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

            for (int i = 0; i < 9; i++)
            {
                var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Iron, 0f, 0f, 70, default, 1.1f);
                dust.velocity = oldVelocity * -0.25f + Main.rand.NextVector2Circular(3.2f, 3.2f);
                dust.noGravity = false;
                dust.scale = Main.rand.NextFloat(0.85f, 1.3f);
            }

            for (int i = 0; i < 8; i++)
            {
                var dust = Dust.NewDustPerfect(Projectile.Center, DustID.Iron, Main.rand.NextVector2CircularEdge(2.8f, 2.8f) * 1.2f, 90, default, 0.9f);
                dust.noGravity = false;
            }

            HitTile = true;
            return false;
        }

        public override bool? CanDamage() => !Sticking && !HitTile;

        private float currentSag;
        private float currentInertia;

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 playerArmPosition = Main.GetPlayerArmPosition(Projectile);
            playerArmPosition.Y -= Main.player[Projectile.owner].gfxOffY;

            Asset<Texture2D> chainTexture = ModContent.Request<Texture2D>("Twilique/Content/Projectiles/Melee/RustyHunterChain");

            Rectangle? chainSourceRectangle = null;
            Vector2 chainOrigin = chainSourceRectangle.HasValue ? (chainSourceRectangle.Value.Size() / 2f) : (chainTexture.Size() / 2f);

            float attachOffset = Projectile.height / 2f - 6;
            Vector2 localOffset = new Vector2(0, attachOffset);
            Vector2 startPos = Projectile.Center + localOffset.RotatedBy(Projectile.rotation);
            Vector2 endPos = playerArmPosition;

            Vector2 toPlayer = endPos - startPos;
            float totalLength = toPlayer.Length();
            if (totalLength < 1f) return true;

            float segmentLength = chainSourceRectangle.HasValue ? chainSourceRectangle.Value.Height : chainTexture.Height();
            if (segmentLength <= 0) segmentLength = 10f;

            int segmentCount = Math.Max(2, (int)(totalLength / segmentLength) + 2);

            float targetSag = Sticking ? 0.105f : (HitTile ? 0.008f : -0.028f);
            float lerpSpeed = HitTile ? 0.5f : 0.15f;
            currentSag = MathHelper.Lerp(currentSag, targetSag, lerpSpeed);
            float sagStrength = currentSag;

            float targetInertia = (!Sticking && !HitTile) ? 0.085f : 0.015f;
            currentInertia = MathHelper.Lerp(currentInertia, targetInertia, lerpSpeed);
            float inertiaStrength = currentInertia;

            for (int i = 0; i < segmentCount; i++)
            {
                float progress = (float)i / segmentCount;
                Vector2 basePos = Vector2.Lerp(startPos, endPos, progress);

                float sag = MathF.Sin(progress * MathHelper.Pi) * totalLength * sagStrength;
                Vector2 gravityOffset = new Vector2(0, sag);
                Vector2 inertiaOffset = Vector2.Zero;

                if (!Sticking && !HitTile)
                {
                    Vector2 chainDir = (endPos - startPos).SafeNormalize(Vector2.Zero);
                    Vector2 perp = new Vector2(-chainDir.Y, chainDir.X);
                    float cross = chainDir.X * Projectile.velocity.Y - chainDir.Y * Projectile.velocity.X;
                    float inertiaAmount = cross * 0.012f;
                    inertiaOffset = perp * (MathF.Sin(progress * MathHelper.Pi) * totalLength * inertiaStrength * inertiaAmount);
                }

                Vector2 drawPos = basePos + gravityOffset + inertiaOffset;

                float nextProgress = (float)(i + 1) / segmentCount;
                Vector2 nextBase = Vector2.Lerp(startPos, endPos, nextProgress);
                float nextSag = MathF.Sin(nextProgress * MathHelper.Pi) * totalLength * sagStrength;
                Vector2 nextGravity = new Vector2(0, nextSag);
                Vector2 nextInertia = Vector2.Zero;

                if (!Sticking && !HitTile)
                {
                    Vector2 chainDir = (endPos - startPos).SafeNormalize(Vector2.Zero);
                    Vector2 perp = new Vector2(-chainDir.Y, chainDir.X);
                    float cross = chainDir.X * Projectile.velocity.Y - chainDir.Y * Projectile.velocity.X;
                    nextInertia = perp * (MathF.Sin(nextProgress * MathHelper.Pi) * totalLength * inertiaStrength * cross * 0.012f);
                }

                Vector2 nextPos = nextBase + nextGravity + nextInertia;
                Vector2 direction = nextPos - drawPos;
                if (direction.LengthSquared() < 0.01f) direction = Vector2.UnitX;

                float rotation = direction.ToRotation() + MathHelper.PiOver2;

                Color chainDrawColor = Lighting.GetColor((int)(drawPos.X / 16), (int)(drawPos.Y / 16));

                Main.spriteBatch.Draw(
                    chainTexture.Value,
                    drawPos - Main.screenPosition,
                    chainSourceRectangle,
                    chainDrawColor,
                    rotation,
                    chainOrigin,
                    1f,
                    SpriteEffects.None,
                    0f);
            }

            Color projColor = Lighting.GetColor(Projectile.Center.ToTileCoordinates());
            Main.EntitySpriteDraw(
                TextureAssets.Projectile[Type].Value,
                Projectile.Center - Main.screenPosition,
                new Rectangle(0, TextureAssets.Projectile[Type].Value.Height / Main.projFrames[Type] * Projectile.frame,
                    TextureAssets.Projectile[Type].Value.Width, TextureAssets.Projectile[Type].Value.Height),
                projColor,
                Projectile.rotation,
                new Vector2(TextureAssets.Projectile[Type].Value.Width / 2, TextureAssets.Projectile[Type].Value.Height / 2 / Main.projFrames[Type]) +
                    ((float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.570f).ToRotationVector2(),
                new Vector2(1, 1),
                SpriteEffects.None, 0);

            return false;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCs.Add(index);
        }
    }
}