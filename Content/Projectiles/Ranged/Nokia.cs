using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Ranged
{
	public class Nokia : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailingMode[Type] = 1;
			ProjectileID.Sets.TrailCacheLength[Type] = 10;
		}

		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.scale = 1f;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 4;
			Projectile.timeLeft = 300;
			Projectile.aiStyle = 0;
			Projectile.extraUpdates = 1;
		}

		public override void AI() {
			Projectile.rotation += Projectile.velocity.X * 0.5f;
			Projectile.velocity.Y += 0.4f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			SoundStyle SteelPipe = new SoundStyle("Twilique/Assets/Sounds/SteelPipe") {
				MaxInstances = 50
			};
			SoundEngine.PlaySound(SteelPipe, Projectile.position);
			Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 50; i++) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Martian, 0f, 0f, 0, default, 1f);
				dust.noGravity = false;
				dust.velocity *= 2;
			}
			if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f) {
				Projectile.velocity.X = oldVelocity.X * -1f;
			}
			if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f) {
				Projectile.velocity.Y = oldVelocity.Y * -1;
			}
			Projectile.penetrate -= 1;
			return false;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.Kill();
		}

		public override void OnKill(int timeLeft) {
			for (int i = 0; i < 50; i++) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Martian, 0f, 0f, 0, default, 1f);
				dust.noGravity = false;
				dust.velocity *= 2;
			}
			SoundStyle SteelPipe = new SoundStyle("Twilique/Assets/Sounds/SteelPipe") {
				MaxInstances = 50
			};
			SoundEngine.PlaySound(SteelPipe, Projectile.position);
		}

		public override bool PreDraw(ref Color lightColor) {
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[Type] * Projectile.frame, texture.Width, texture.Height);
			Color MyColor = lightColor; MyColor.A = 0;
			for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Type]; i++) {
				float factor = 1 - (float)i / ProjectileID.Sets.TrailCacheLength[Type];
				Vector2 oldcenter = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition;
				Main.EntitySpriteDraw(texture, oldcenter, rectangle, MyColor * factor, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
			}
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, rectangle, lightColor, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
			Main.EntitySpriteDraw(ModContent.Request<Texture2D>("Twilique/Content/Projectiles/Ranged/NokiaLight").Value, Projectile.Center - Main.screenPosition, rectangle, new Color(255, 255, 255, 0), Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
			return false;
		}
	}
}
