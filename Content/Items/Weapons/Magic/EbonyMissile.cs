using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Magic
{
	public class EbonyMissile : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 14;
			Item.DamageType = DamageClass.Magic;
			Item.crit = 10;
			Item.width = 60;
			Item.height = 60;
			Item.scale = 0.7f;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item8;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.value = Item.buyPrice(0, 0, 40, 0);
			Item.rare = ItemRarityID.Red;
			Item.autoReuse = false;
			Item.mana = 14;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Magic.EbonyMissile>();
			Item.shootSpeed = 10;
			Item.noMelee = true;
			Item.channel = true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Vilethorn, 1);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddIngredient(ItemID.ShadowScale, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
