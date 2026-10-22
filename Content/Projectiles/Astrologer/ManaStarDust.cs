using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.Dusts;

namespace Twilique.Content.Projectiles.Astrologer
{
	public class ManaStarDust : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.scale = 1f;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 10;
			Projectile.aiStyle = 0;
		}

		public override void OnSpawn(IEntitySource source) {
			for (int i = 0; i < 30; i++) {
				Color color = new Color(255, 219, 094);
				if (Main.rand.NextBool(2)) color = new Color(184, 70, 122);
				var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<NoColorTorch>(), Projectile.velocity.X, Projectile.velocity.Y, 100, color, 1.5f);
				dust.noGravity = true;
			}
		}

		public override void AI() {
		}
	}
}
