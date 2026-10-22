using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Ranged
{
	public class Nokia : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 100;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Ranged.Nokia>();
			Item.shootSpeed = 15;
			Item.UseSound = SoundID.Item1;
			Item.noMelee = true;
		}
	}
}
