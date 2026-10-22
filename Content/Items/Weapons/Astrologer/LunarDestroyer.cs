using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.DamageClasses;

namespace Twilique.Content.Items.Weapons.Astrologer
{
	public class LunarDestroyer : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 35;
			Item.DamageType = ModContent.GetInstance<AstrologerDamage>();
			Item.crit = 21;
			Item.width = 26;
			Item.height = 38;
			Item.scale = 1f;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(0, 0, 0, 10);
			Item.value = Item.buyPrice(0, 0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.Astrologer.LunarDestroyer>();
			Item.shootSpeed = 0;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

		public override bool CanUseItem(Player player) {
			return StarDustHelper.HasStarAmmo(player, 1) && base.CanUseItem(player);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			return StarDustHelper.ConsumeStarAmmo(player, 1);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			StarDustHelper.AddStarAmmoTooltip(tooltips, Item, 1);
			ContributionTooltipHelper.AddContributionTooltips(tooltips, Item, "蓝幽SAMA", "冬天的叶");
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
