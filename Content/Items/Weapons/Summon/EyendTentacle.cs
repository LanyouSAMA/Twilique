using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Summon
{
	public class EyendTentacle : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 55;
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.width = 38;
			Item.height = 30;
			Item.scale = 1f;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.value = Item.sellPrice(0, 4, 40, 0);
			Item.value = Item.buyPrice(0, 17, 60, 0);
			Item.rare = ItemRarityID.Red;
			Item.DefaultToWhip(ModContent.ProjectileType<Content.Projectiles.Summon.EyendTentacleProjectile>(), 60, 3, 4);
			Item.shootSpeed = 4;
		}

		public override bool MeleePrefix() {
			return true;
		}
	}
}
