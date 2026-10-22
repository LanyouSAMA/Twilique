using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Dusts
{
	public class LanyouTorch : ModDust
	{
		public override void SetStaticDefaults() {
			UpdateType = DustID.Torch;
		}

		public override bool Update(Dust dust) {
			float light1 = 35f * 0.01f * dust.scale;
			float light2 = 200f * 0.01f * dust.scale;
			float light3 = 254f * 0.01f * dust.scale;

			Lighting.AddLight(dust.position, light1, light2, light3);

			return base.Update(dust);
		}
	}
}
