using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Melee
{
	public class AmethystShard : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 3600;
			Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
			AIType = ProjectileID.SnowBallFriendly;
		}

		public override void AI() {
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.570f;
			if (Main.GameUpdateCount % 2 == 0) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, default, 1f);
				dust.noGravity = true;
				dust.velocity *= 0;
			}
			Lighting.AddLight((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 0.7f, 0.18f, 0.96f);
		}

		public override void OnKill(int timeLeft) {
			for (int i = 0; i < 25; i++) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, default, 1f);
				dust.noGravity = false;
				dust.velocity *= 0;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return true;
		}
	}
}