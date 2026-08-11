using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
	public class IridiumNeedle : ModItem
	{
		public override void SetDefaults()
        {
            Item.damage = 20;//武器伤害
            Item.scale = 1;//武器尺寸
            Item.crit = 21;//暴击率
            Item.DamageType = DamageClass.Melee;//职业伤害类型
            Item.width = 26;//掉落物贴图宽度
            Item.height = 26;//掉落物贴图高度
            Item.useTime = 8;//使用时间(1秒60帧,用你看的懂的话来说就是数值越小越快)
            Item.shoot = ModContent.ProjectileType < Content.Projectiles.Melee.IridiumNeedle>();//发射弹幕
            Item.shootSpeed = 10f;//弹幕速度(用你看的懂的话来说就是数值越大越快)
            Item.useAnimation = 8;//使用动画时间
            Item.useStyle = ItemUseStyleID.Rapier;//使用动作
            Item.knockBack = 3;//击退
            Item.value = Item.buyPrice(0, 8, 0, 0);//价格
            Item.rare = ItemRarityID.LightPurple;//稀有度
            Item.UseSound = SoundID.Item1;//使用音效
            Item.autoReuse = true;//自动连发
            Item.scale = 1;//武器判定
            Item.noUseGraphic = true;//取消武器贴图
            Item.channel = true;//持续操作弹幕
            Item.noMelee = true;//取消近战判定
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();//合成配方名字
            //recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 20);//合成材料
            recipe.AddTile(TileID.MythrilAnvil);//制作站
            recipe.Register();
        }
    }
}
