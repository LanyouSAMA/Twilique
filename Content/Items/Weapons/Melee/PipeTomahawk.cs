using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
	public class PipeTomahawk : ModItem
	{
		public override void SetDefaults()
        {
            Item.damage = 30;//武器伤害
            Item.scale = 1f;//武器尺寸
            Item.crit = 0;//暴击率
            Item.DamageType = DamageClass.Melee;//职业伤害类型
            Item.width = 23;//掉落物贴图宽度
            Item.height = 20;//掉落物贴图高度
            Item.useTime = 40;//使用时间(1秒60帧)
            Item.shoot = ModContent.ProjectileType<Content.Projectiles.Melee.PipeTomahawk>();//发射弹幕
            Item.shootSpeed = 15;//弹幕速度
            Item.useAnimation = 40;//使用动画时间
            Item.useStyle = ItemUseStyleID.Swing;//使用动作
            Item.knockBack = 7;//击退
            Item.value = Item.buyPrice(0, 20, 15, 0);//价格
            Item.rare = ItemRarityID.Blue;//稀有度
            //Item.UseSound = SoundID.Item68;//使用音效
            Item.autoReuse = true;//自动连发
            Item.scale = 1;//武器判定
            Item.noUseGraphic = true;//取消武器贴图
            Item.channel = true;//持续操作弹幕
            Item.noMelee = true;//取消近战判定
        }
        public override bool AltFunctionUse(Player player)//允许使用鼠标右键
        {
            return true;
        }

        public override bool CanUseItem(Player player)//使用鼠标右键时消耗物品(弹药)
        {
            if (player.altFunctionUse == 2)//如果使用鼠标右键
            {
                Item.useAmmo = ModContent.ItemType<Content.Items.AstrologerAmmo.Tobacco>();//消耗弹药(烟草)
                return true;
            }
            else
            {
                Item.useAmmo = AmmoID.None;//不消耗弹药(鼠标左键)
            }
                return base.CanUseItem(player);
        }

        public override bool? CanChooseAmmo(Item ammo, Player player)//选择弹药消耗
        {
            if (ammo.type == ModContent.ItemType<Content.Items.AstrologerAmmo.Tobacco>())//如果消耗烟草
            {
                return true;
            }
            return false;
        }

        public override void OnConsumeAmmo(Item ammo, Player player)
        {
            if (ammo.type == ModContent.ItemType<Content.Items.AstrologerAmmo.Tobacco>())//如果消耗烟草
            {
                //player.AddBuff(ModContent.BuffType<Content.>(), 18000);//对玩家施加5分钟buff
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, ai0: 1f);

                return false;
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOffset();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();//合成配方名字
            recipe.AddIngredient(ItemID.GoldBar, 20);//更多合成材料
            recipe.AddIngredient(ItemID.HallowedBar, 10);// 超多合成材料
            recipe.AddIngredient(ItemID.SoulofFright, 3);//合成材料
            recipe.AddIngredient(ItemID.SoulofMight, 3);//合成材料
            recipe.AddIngredient(ItemID.SoulofSight, 3);//合成材料
            recipe.AddTile(TileID.MythrilAnvil);//制作站
            recipe.Register();
        }
    }
}
