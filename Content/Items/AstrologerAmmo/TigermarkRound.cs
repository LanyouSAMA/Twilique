using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.AstrologerAmmo
{
	public class TigermarkRound : ModItem
	{
		public override void SetDefaults()
        {
            Item.damage = 37;//武器伤害
            Item.crit = 0;//暴击率
            Item.knockBack = 1;//击退
            Item.scale = 1;//物品尺寸
            Item.DamageType = DamageClass.Melee;//职业伤害类型
            Item.width = 16;//掉落物贴图宽度
            Item.height = 16;//掉落物贴图高度
            Item.maxStack = 64;//物品堆叠上限
            Item.consumable = true;//标记物品可消耗
            //Item.ammo = ModContent.ItemType<>();//弹药类型
            Item.value = Item.buyPrice(0, 25, 0, 0);//价格
            Item.rare = ItemRarityID.Red;//稀有度
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();//合成配方名字
            recipe.AddIngredient(ItemID.EmptyBullet, 1);//合成材料
            recipe.AddIngredient(ItemID.ExplosivePowder, 5);//更多合成材料
            recipe.AddIngredient(ItemID.ChlorophyteBar, 1);// 超多合成材料
            recipe.AddTile(TileID.MythrilAnvil);//制作站
            recipe.Register();
        }
    }
}
