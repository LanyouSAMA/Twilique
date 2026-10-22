using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
    public class RainbowSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.crit = 0;
            Item.DamageType = DamageClass.Melee;
            Item.width = 24;
            Item.height = 28;
            Item.scale = 1.4f;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7f;
            Item.value = Item.sellPrice(0, 1, 80, 0);
            Item.value = Item.buyPrice(0, 7, 20, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.RainbowShard>();
            Item.shootSpeed = 12;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
            int i = Main.rand.Next(8);
            if (i == 0)
            {
                Item.damage = 10;
                type = ModContent.ProjectileType<Projectiles.Melee.AmethystShard>();
            }
            else if (i == 1)
            {
                Item.damage = 12;
                type = ModContent.ProjectileType<Projectiles.Melee.TopazShard>();
            }
            else if (i == 2)
            {
                Item.damage = 14;
                type = ModContent.ProjectileType<Projectiles.Melee.SapphireShard>();
            }
            else if (i == 3)
            {
                Item.damage = 16;
                type = ModContent.ProjectileType<Projectiles.Melee.EmeraldShard>();
            }
            else if (i == 4)
            {
                Item.damage = 20;
                type = ModContent.ProjectileType<Projectiles.Melee.AmberShard>();
            }
            else if (i == 5)
            {
                Item.damage = 20;
                type = ModContent.ProjectileType<Projectiles.Melee.RubyShard>();
            }
            else if (i == 6)
            {
                Item.damage = 24;
                type = ModContent.ProjectileType<Projectiles.Melee.DiamondShard>();
            }
            else if (i == 7)
            {
                Item.damage = 30;
                type = ModContent.ProjectileType<Projectiles.Melee.RainbowShard>();
            }
            Item.damage = Item.damage * 3 / 4;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmethystSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TopazSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SapphireSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EmeraldSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AmberSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RubySword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DiamondSword>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            ContributionTooltipHelper.AddContributionTooltips(tooltips, Item, "蓝幽SAMA", "蓝幽SAMA");
        }

    }
}
