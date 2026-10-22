using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Ranged
{
	public class SandStorm : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 72;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 0;
			Item.width = 40;
			Item.height = 16;
			Item.scale = 1f;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item11;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.value = Item.buyPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.SandBallFalling;
			Item.shootSpeed = 24;
			Item.useAmmo = AmmoID.Sand;
			Item.noMelee = true;
		}

		public override void ModifyWeaponDamage(Player player, ref StatModifier damage) {
			if (player.ZoneSandstorm) {
				Item.damage = 144;
				Item.useTime = 4;
				Item.useAnimation = 4;
				Item.useAmmo = AmmoID.Sand;
			}
			else {
				Item.damage = 72;
				Item.useTime = 8;
				Item.useAnimation = 8;
				Item.useAmmo = AmmoID.Sand;
			}
		}

		public override bool? CanChooseAmmo(Item ammo, Player player) {
			if (ammo.type == ItemID.SandBlock) {
				Item.shoot = ProjectileID.SandBallGun;
				return true;
			}
			else if (ammo.type == ItemID.EbonsandBlock) {
				Item.shoot = ProjectileID.EbonsandBallGun;
				return true;
			}
			else if (ammo.type == ItemID.PearlsandBlock) {
				Item.shoot = ProjectileID.PearlSandBallGun;
				return true;
			}
			else if (ammo.type == ItemID.CrimsandBlock) {
				Item.shoot = ProjectileID.CrimsandBallGun;
				return true;
			}
			return null;
		}

		public override bool CanConsumeAmmo(Item ammo, Player player) {
			if (player.ZoneSandstorm) {
				return Main.rand.Next(100) < 50;
			}
			else {
				return true;
			}
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			position = position + velocity.SafeNormalize(Vector2.Zero) * 24;
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sandgun, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddIngredient(ItemID.Amber, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			ContributionTooltipHelper.AddContributionTooltips(tooltips, Item, "蓝幽SAMA", "蓝幽SAMA");
		}

	}
}
