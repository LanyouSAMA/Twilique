using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.Tiles;

namespace Twilique.Content.Items.Placeable
{
	public class LiquescenceRockItem : ModItem
	{
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 20;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.value = Item.buyPrice(0, 0, 50, 0);
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.DefaultToPlaceableTile(ModContent.TileType<LiquescenceRock>());
			Item.placeStyle = 0;
		}
	}
}
