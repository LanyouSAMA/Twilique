using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Magic
{
	public class BloodMissile : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 17;
			Item.DamageType = DamageClass.Magic;
			Item.crit = 15;
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
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = false;
			Item.mana = 14;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Magic.BloodMissile>();
			Item.shootSpeed = 10;
			Item.noMelee = true;
			Item.channel = true;
			Item.staff[Type] = true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimsonRod, 1);
			recipe.AddIngredient(ItemID.CrimtaneBar, 15);
			recipe.AddIngredient(ItemID.TissueSample, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			ContributionTooltipHelper.AddContributionTooltips(tooltips, Item, "蓝幽SAMA", "蓝幽SAMA");
		}

	}
}
