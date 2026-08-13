using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items
{
	public class IridiumBar : ModItem
	{
		public override void SetDefaults()
        {
            Item.scale = 1;//物品尺寸
            Item.width = 32;//掉落物贴图宽度
            Item.height = 32;//掉落物贴图高度
            Item.maxStack = 9999;//物品堆叠上限
            Item.consumable = true;//标记物品可消耗或可放置
            Item.useStyle = ItemUseStyleID.Swing;//使用动作
            Item.placeStyle = ItemUseStyleID.Swing;//放置动作
            Item.createTile = ModContent.TileType<Content.Tiles.IridiumBarBlock>();//放置物块
            Item.useTime = 10;//使用时间
            Item.useAnimation = 15;//使用动画时间
            Item.value = Item.buyPrice(0, 7, 0, 0);//价格
            Item.rare = ItemRarityID.LightPurple;//稀有度
            Item.autoReuse = true;//自动连发
        }
    }
}
