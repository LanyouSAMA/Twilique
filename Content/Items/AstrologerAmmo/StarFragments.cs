using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.AstrologerAmmo
{
    public class StarFragments : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.value = Item.buyPrice(0, 0, 2, 50);
            Item.maxStack = 9999;
            Item.ammo = Item.type;
            Item.consumable = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.Register();
        }
    }
}