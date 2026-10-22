using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
    public class RubySword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 0;
            Item.DamageType = DamageClass.Melee;
            Item.width = 24;
            Item.height = 28;
            Item.scale = 1.4f;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4.75f;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.value = Item.buyPrice(0, 1, 20, 0);
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.RubyShard>();
            Item.shootSpeed = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        int i = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (i == 0)
            {
                return Main.rand.Next(100) < 75;
            }
            if (i == 1)
            {
                i = 0;
                return true;
            }
            return false;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            i = 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldOre, 10);
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
