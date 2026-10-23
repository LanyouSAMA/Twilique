using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
    public class TopazDagger : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.crit = 0;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 52;
            Item.scale = 1f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3.5f;
            Item.value = Item.sellPrice(0, 0, 6, 0);
            Item.value = Item.buyPrice(0, 0, 24, 0);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useTurn = true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile p = Projectile.NewProjectileDirect(player.GetSource_OnHit(target), player.Center, Vector2.Normalize(Main.MouseWorld - player.Center) * 6.5f, ModContent.ProjectileType<Projectiles.Melee.TopazShard>(), Item.damage, Item.knockBack, player.whoAmI);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TinBar, 10);
            recipe.AddIngredient(ItemID.Topaz, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            ContributionTooltipHelper.AddContributionTooltips(tooltips, Item, "蓝幽SAMA", "蓝幽SAMA");
        }

    }
}
