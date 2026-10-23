using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
    public class SapphireDagger : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.crit = 0;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 52;
            Item.scale = 1f;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.value = Item.buyPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile p = Projectile.NewProjectileDirect(player.GetSource_OnHit(target), player.Center, Vector2.Normalize(Main.MouseWorld - player.Center) * 6.5f, ModContent.ProjectileType<Projectiles.Melee.SapphireShard>(), Item.damage, Item.knockBack, player.whoAmI);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ItemID.Sapphire, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            ContributionTooltipHelper.AddContributionTooltips(tooltips, Item, "蓝幽SAMA", "蓝幽SAMA");
        }

    }
}
