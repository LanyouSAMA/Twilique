using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.Projectiles.Magic;

namespace Twilique.Content.Projectiles.Magic
{
	public class MissileExplosion : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 81;
			Projectile.height = 81;
			Projectile.penetrate = -1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 4;
			Projectile.alpha = 255;
		}

		public override bool? CanHitNPC(NPC target) {
			if (target.whoAmI == (int)Projectile.ai[0]) return false;
			return base.CanHitNPC(target);
		}
	}
}
