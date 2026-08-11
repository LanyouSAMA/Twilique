using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
	public class CorrodeFractureSword : ModItem
	{
		public override void SetDefaults()
        {
            Item.damage = 18;//武器伤害
            Item.crit = 0;//暴击率
            Item.scale = 1;//武器尺寸
            Item.DamageType = DamageClass.Melee;//职业伤害类型
            Item.width = 40;//掉落物贴图宽度
            Item.height = 40;//掉落物贴图高度
            Item.useTime = 20;//使用时间(1秒60帧)
            //Item.shoot = ModContent.ProjectileType<Content.Projectiles.Melee.Pollutant>();//发射弹幕
            Item.shootSpeed = 10f;//弹幕速度
            Item.useAnimation = 20;//使用动画时间
            Item.useStyle = ItemUseStyleID.Swing;//使用动作
            Item.knockBack = 5;//击退
            Item.value = Item.buyPrice(0, 1, 50, 0);//价格
            Item.rare = ItemRarityID.Blue;//稀有度
            Item.UseSound = SoundID.Item1;//使用音效
            Item.scale = 1;//武器判定
            Item.autoReuse = false;//自动连发
        }

        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(player.GetSource_FromThis(), Item.Center, Item.velocity, ModContent.ProjectileType<Content.Projectiles.Melee.Pollutant>(), Item.damage, Item.knockBack, player.whoAmI); //更加泛用的自由弹幕生成方式

            for (int i = 0; i < 3; i++) //执行3次发射偏转弹幕
            {
                Projectile.NewProjectile(source, position, velocity.RotatedBy(Main.rand.NextFloat(-0.25f, 0.25f)) //将弹幕偏转至-0.25到0.25之间的随机值
                    , ModContent.ProjectileType<Content.Projectiles.Melee.Pollutant>(), damage, knockback, player.whoAmI);
            }
            return true;
        }*/
    }
}
