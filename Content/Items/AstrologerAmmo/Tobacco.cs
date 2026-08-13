using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.AstrologerAmmo
{
	public class Tobacco : ModItem
	{
		public override void SetDefaults()
        {
            Item.scale = 1;//物品尺寸
            Item.DamageType = DamageClass.Melee;//职业伤害类型
            Item.width = 16;//掉落物贴图宽度
            Item.height = 16;//掉落物贴图高度
            Item.maxStack = 9999;//物品堆叠上限
            Item.consumable = true;//标记物品可消耗
            //Item.ammo = ModContent.ItemType<>();//弹药类型
            Item.value = Item.buyPrice(0, 0, 50, 0);//价格
            Item.rare = ItemRarityID.Red;//稀有度
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();//合成配方名字
            recipe.AddIngredient(ItemID.EmptyBullet, 1);//合成材料
            recipe.AddTile(TileID.Campfire);//制作站
            recipe.Register();
        }
    }
}
