using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.AstrologerAmmo
{
    public class StarDust : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 14;
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.value = Item.buyPrice(0, 0, 0, 50);
            Item.maxStack = 9999;
            Item.ammo = Item.type;
            Item.consumable = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(100);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(5);
            recipe2.AddIngredient(ModContent.ItemType<StarFragments>(), 1);
            recipe2.Register();
        }
    }
}