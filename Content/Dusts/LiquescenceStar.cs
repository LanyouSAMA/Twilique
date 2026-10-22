using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Dusts
{
	public class LiquescenceStar : ModDust
	{
		public override void SetStaticDefaults() {
			UpdateType = DustID.Enchanted_Gold;
		}

		public override bool Update(Dust dust) {
			float light1 = 38f * 0.01f * dust.scale;
			float light2 = 140f * 0.01f * dust.scale;
			float light3 = 90f * 0.01f * dust.scale;

			Lighting.AddLight(dust.position, light1, light2, light3);

			return base.Update(dust);
		}
	}
}
