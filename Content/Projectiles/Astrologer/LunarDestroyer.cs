using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.Dusts;

namespace Twilique.Content.Projectiles.Astrologer
{
	public class LunarDestroyer : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailingMode[Type] = 1;
			ProjectileID.Sets.TrailCacheLength[Type] = 15;
		}

		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 38;
			Projectile.scale = 1f;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 30;
			Projectile.aiStyle = 0;
		}

		Player player => Main.player[Projectile.owner];
		float DrawColor = 0;

		public override void OnSpawn(IEntitySource source) {
			Projectile.velocity = player.velocity;
			Projectile.ai[0] = Projectile.position.Y - 96f;
		}

		public override void AI() {
			if (DrawColor < 1) {
				DrawColor += 0.05f;
			}
			Projectile.position = new Vector2(Projectile.position.X, (float)Utils.Lerp(Projectile.position.Y, Projectile.ai[0], 0.05f));
		}

		public override void OnKill(int timeLeft) {
			float r = Main.rand.NextFloat(MathHelper.TwoPi);
			for (int i = 0; i < 4; i++) {
				NPC target = null;
				int t = Projectile.FindTargetWithLineOfSight(1980);
				if (t >= 0) {
					target = Main.npc[t];
					Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, (Projectile.AngleTo(target.Center) + i * MathHelper.PiOver2).ToRotationVector2() * 15f, ModContent.ProjectileType<LunarDestroyerSplit>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
				}
				else Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, (r + i * MathHelper.PiOver2).ToRotationVector2() * 15f, ModContent.ProjectileType<LunarDestroyerSplit>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
			}

			for (float i = 0; i < MathHelper.TwoPi; i += MathHelper.TwoPi / 128f) {
				int R = 10;
				Dust.NewDustPerfect(Projectile.Center, DustID.GemTopaz,
					new Vector2((float)(Math.Cos(i) * R), (float)(Math.Sin(i) * R)).ToRotation().ToRotationVector2() * 10f
					, Scale: 1.5f).noGravity = true;
			}

			SoundEngine.PlaySound(new SoundStyle("Twilique/Assets/Sounds/Bomb1"), Projectile.position);
			Main.LocalPlayer.GetModPlayer<ScreenMovePlayer>().ScreenShakeTimer = 1;
			Main.LocalPlayer.GetModPlayer<ScreenMovePlayer>().ScreenShakeScale = 10;
		}

		public override bool? CanDamage() {
			return false;
		}

		public override bool PreDraw(ref Color lightColor) {
			Lighting.AddLight((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 2.55f, 2.08f, 1.21f);

			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Rectangle rectangle = new(0, texture.Height / Main.projFrames[Type] * Projectile.frame, texture.Width, texture.Height);
			Color MyColor = lightColor; MyColor.A = 0;
			for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Type]; i++) {
				float factor = DrawColor - ((float)i / ProjectileID.Sets.TrailCacheLength[Type]);
				Vector2 oldcenter = Projectile.oldPos[i] + (Projectile.Size / 2) - Main.screenPosition;
				Main.EntitySpriteDraw(texture, oldcenter, rectangle, MyColor * factor, Projectile.oldRot[i], new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
			}
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, rectangle, lightColor * DrawColor, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
			return false;
		}

		public class LunarDestroyerSplit : ModProjectile
		{
			public override void SetStaticDefaults() {
				ProjectileID.Sets.TrailingMode[Type] = 1;
				ProjectileID.Sets.TrailCacheLength[Type] = 15;
			}

			public override void SetDefaults() {
				Projectile.width = 42;
				Projectile.height = 10;
				Projectile.scale = 1f;
				Projectile.friendly = true;
				Projectile.hostile = false;
				Projectile.penetrate = -1;
				Projectile.tileCollide = false;
				Projectile.timeLeft = 600;
				Projectile.aiStyle = 0;
			}

			public override void OnSpawn(IEntitySource source) {
			}

			public override void AI() {
				Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
				if (Main.GameUpdateCount % 1 == 0 && Projectile.timeLeft > 15) {
					var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemTopaz, 0f, 0f, 100, default, 1f);
					dust.noGravity = true;
					dust.velocity *= 0;
					dust.position = Projectile.Center;
				}
				if (Projectile.timeLeft < 15) {
					DrawColor = Projectile.timeLeft / 15f;
				}
			}

			public override bool? CanDamage() {
				return Projectile.timeLeft > 15 ? base.CanDamage() : false;
			}

			public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
				if (Projectile.timeLeft > 15) {
					Projectile.timeLeft = 15;
				}
				base.OnHitNPC(target, hit, damageDone);
			}

			float DrawColor = 1;

			public override bool PreDraw(ref Color lightColor) {
				Texture2D texture = TextureAssets.Projectile[Type].Value;
				Rectangle rectangle = new Rectangle(0, texture.Height / Main.projFrames[Type] * Projectile.frame, texture.Width, texture.Height);
				Color MyColor = lightColor; MyColor.A = 0;
				for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Type]; i++) {
					float factor = DrawColor - (float)i / ProjectileID.Sets.TrailCacheLength[Type];
					Vector2 oldcenter = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition;
					Main.EntitySpriteDraw(texture, oldcenter, rectangle, MyColor * factor, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
				}
				Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, rectangle, MyColor * DrawColor, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.projFrames[Type]), new Vector2(1, 1), SpriteEffects.None, 0);
				return false;
			}
		}
	}
}
