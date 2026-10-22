using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Dusts
{
	public class TwilightStar : ModDust
	{
		public override void SetStaticDefaults() {
			UpdateType = DustID.Enchanted_Gold;
		}

		public override bool Update(Dust dust) {
			float light1 = 110f * 0.01f * dust.scale;
			float light2 = 11f * 0.01f * dust.scale;
			float light3 = 145f * 0.01f * dust.scale;

			Lighting.AddLight(dust.position, light1, light2, light3);

			return base.Update(dust);
		}
	}
}
