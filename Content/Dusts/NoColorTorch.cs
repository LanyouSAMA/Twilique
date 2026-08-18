using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Dusts
{
	public class NoColorTorch : ModDust
	{
		public override void SetStaticDefaults() {
			UpdateType = DustID.Torch;
		}
        public override bool Update(Dust dust)
        {
            float light1 = dust.color.R * 0.01f * dust.scale;
            float light2 = dust.color.G * 0.01f * dust.scale;
            float light3 = dust.color.B * 0.01f * dust.scale;

            Lighting.AddLight(dust.position, light1, light2, light3);

            return base.Update(dust);
        }
    }
}