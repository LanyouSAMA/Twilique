using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Projectiles.Melee
{
	public class RainbowShard : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 3600;
			Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
			AIType = ProjectileID.SnowBallFriendly;
		}

		public override void AI() {
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.570f;
			if (Main.GameUpdateCount % 3 == 0) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1f);
				dust.noGravity = true;
				dust.velocity *= 0;
				var dust1 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch, 0f, 0f, 100, default, 1f);
				dust1.noGravity = true;
				dust1.velocity *= 0;
				var dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, 0f, 0f, 100, default, 1f);
				dust2.noGravity = true;
				dust2.velocity *= 0;
				var dust3 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, 0f, 0f, 100, default, 1f);
				dust3.noGravity = true;
				dust3.velocity *= 0;
				var dust4 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1f);
				dust4.noGravity = true;
				dust4.velocity *= 0;
				var dust5 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 1f);
				dust5.noGravity = true;
				dust5.velocity *= 0;
				var dust6 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, default, 1f);
				dust6.noGravity = true;
				dust6.velocity *= 0;
			}
			Lighting.AddLight((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 1f, 0.5f, 0.75f);
		}

		public override void OnKill(int timeLeft) {
			for (int i = 0; i < 5; i++) {
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1f);
				dust.noGravity = false;
				dust.velocity *= 0;
				var dust1 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch, 0f, 0f, 100, default, 1f);
				dust1.noGravity = false;
				dust1.velocity *= 0;
				var dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, 0f, 0f, 100, default, 1f);
				dust2.noGravity = false;
				dust2.velocity *= 0;
				var dust3 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, 0f, 0f, 100, default, 1f);
				dust3.noGravity = false;
				dust3.velocity *= 0;
				var dust4 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1f);
				dust4.noGravity = false;
				dust4.velocity *= 0;
				var dust5 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 1f);
				dust5.noGravity = false;
				dust5.velocity *= 0;
				var dust6 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, default, 1f);
				dust6.noGravity = false;
				dust6.velocity *= 0;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return true;
		}
	}
}