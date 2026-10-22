using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Magic
{
	public class LightBanisher : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.crit = 10;
			Item.width = 60;
			Item.height = 60;
			Item.scale = 1f;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item8;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.autoReuse = false;
			Item.mana = 14;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Magic.LightBanisher>();
			Item.shootSpeed = 10;
			Item.noMelee = true;
			Item.channel = true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EbonyMissile>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BloodMissile>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
