using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Magic
{
	public class BloodMissileSplit : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailingMode[Type] = 2;
			ProjectileID.Sets.TrailCacheLength[Type] = 10;
		}

		public override void SetDefaults() {
			Projectile.width = 7;
			Projectile.height = 7;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 3600;
			Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
			AIType = ProjectileID.SnowBallFriendly;
		}

		public override void AI() {
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.570f;
			if (Main.GameUpdateCount % 2 == 0) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemRuby, 0f, 0f, 100, default, 1f);
				dust.noGravity = true;
				dust.velocity *= 0;
			}
			Lighting.AddLight((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 0.7f, 0f, 0f);
		}

		public override void OnKill(int timeLeft) {
			for (int i = 0; i < 25; i++) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemRuby, 0f, 0f, 100, default, 1.5f);
				dust.noGravity = false;
			}
		}

		public override bool PreDraw(ref Color lightColor) {
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[Type] * Projectile.frame, texture.Width, texture.Height);
			Color MyColor = Color.DarkRed; MyColor.A = 0;
			for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Type]; i++) {
				float factor = 1 - (float)i / ProjectileID.Sets.TrailCacheLength[Type];
				Vector2 oldcenter = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition;
				Main.EntitySpriteDraw(texture, oldcenter, rectangle, MyColor * factor, Projectile.oldRot[i], new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
			}
			return false;
		}
	}
}
