using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Dusts
{
	public class HollowCircleDust : ModDust
	{
		public override void SetStaticDefaults() {
		}
        public override void OnSpawn(Dust dust)
        {
            dust.scale *= 0.1f;
        }
        public override bool Update(Dust dust)
        {
            dust.scale += 0.1f * dust.velocity.X;
            dust.alpha += (int)dust.velocity.Y;

            float light1 = dust.color.R * 0.05f * dust.scale;
            float light2 = dust.color.G * 0.05f * dust.scale;
            float light3 = dust.color.B * 0.05f * dust.scale;

            Lighting.AddLight(dust.position, light1, light2, light3);

            return false;
        }
        public override bool PreDraw(Dust dust)
		{
            Texture2D texture = ModContent
                .Request<Texture2D>("Twilique/Content/Dusts/HollowCircleDust")
                .Value;

            Vector2 position = dust.position - Main.screenPosition;
            Vector2 origin = texture.Size() * 0.5f;

            dust.color.A *= 0;

            Main.spriteBatch.Draw(
                texture,
                position,
                texture.Bounds,
                dust.color,
                dust.rotation,
                origin,
                dust.scale,
                SpriteEffects.None,
                0f
            );

            return false;
		}
    }
}