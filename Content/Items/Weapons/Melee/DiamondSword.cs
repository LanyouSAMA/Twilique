using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
    public class DiamondSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 0;
            Item.DamageType = DamageClass.Melee;
            Item.width = 24;
            Item.height = 28;
            Item.scale = 1.4f;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5.5f;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.value = Item.buyPrice(0, 2, 40, 0);
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.DiamondShard>();
            Item.shootSpeed = 9.5f;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        int i = 0;
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            i = 1;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (i == 0)
            {
                return true;
            }
            if (i == 1)
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
                i = 0;
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddIngredient(ItemID.Diamond, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
