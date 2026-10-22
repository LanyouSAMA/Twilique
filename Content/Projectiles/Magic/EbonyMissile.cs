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
	public class EbonyMissile : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailingMode[Type] = 1;
			ProjectileID.Sets.TrailCacheLength[Type] = 20;
		}

		public override void SetDefaults() {
			Projectile.width = 54;
			Projectile.height = 54;
			Projectile.scale = 0.5f;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 3600;
			Projectile.aiStyle = ProjAIStyleID.MagicMissile;
		}

		public override void AI() {
			Lighting.AddLight((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 0.7f, 0f, 1.25f);
		}

		public override void OnKill(int timeLeft) {
			Vector2 launchVelocity = new Vector2(0, 0);
			Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, launchVelocity * 0, ModContent.ProjectileType<MissileExplosion>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
			for (int i = 0; i < 100; i++) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemAmethyst, 0f, 0f, 100, default, 1.5f);
				dust.noGravity = true;
				dust.velocity *= 2;
			}
			for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Type]; i++) {
				for (int i2 = 0; i2 < 3; i2++) {
					var dust = Dust.NewDustDirect(Projectile.oldPos[i], Projectile.width, Projectile.height, DustID.GemAmethyst, 0f, 0f, 0, default, 1f);
					dust.noGravity = true;
				}
			}
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}

		public override bool PreDraw(ref Color lightColor) {
			TwiliqueTailHelper.ProjectileDrawTail(Projectile, ModContent.Request<Texture2D>("Twilique/Assets/Textures/Trail2").Value, new Vector2(13, 13), new Color(149, 0, 255, 0), new Color(149, 0, 255, 0), 54f, true);

			Main.EntitySpriteDraw(TextureAssets.Projectile[Type].Value, Projectile.Center - Main.screenPosition,
				new Rectangle(0, TextureAssets.Projectile[Type].Value.Height / Main.projFrames[Type] * Projectile.frame, TextureAssets.Projectile[Type].Value.Width, TextureAssets.Projectile[Type].Value.Height),
				new Color(255, 255, 255, 0), Projectile.rotation, new Vector2(TextureAssets.Projectile[Type].Value.Width / 2, TextureAssets.Projectile[Type].Value.Height / 2 / Main.projFrames[Type]),
				new Vector2(1, 1), SpriteEffects.None, 0);
			Main.EntitySpriteDraw(ModContent.Request<Texture2D>("Twilique/Content/Projectiles/Magic/EbonyMissile2").Value, Projectile.Center - Main.screenPosition,
				new Rectangle(0, TextureAssets.Projectile[Type].Value.Height / Main.projFrames[Type] * Projectile.frame, TextureAssets.Projectile[Type].Value.Width, TextureAssets.Projectile[Type].Value.Height),
				new Color(255, 255, 255, 0), Projectile.rotation, new Vector2(TextureAssets.Projectile[Type].Value.Width / 2, TextureAssets.Projectile[Type].Value.Height / 2 / Main.projFrames[Type]) +
				((float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.570f).ToRotationVector2(),
				new Vector2(1, 1), SpriteEffects.None, 0);

			return false;
		}
	}
}
