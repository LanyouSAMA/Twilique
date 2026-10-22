using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Twilique.Content.Items.AstrologerAmmo;
using Twilique.Content.Players;

namespace Twilique
{
    public static class StarDustHelper
    {
        public static int StarAmmoType(int StarType)
        {
            if (StarType == 0) return ItemID.FallenStar;
            if (StarType == 1) return ModContent.ItemType<StarFragments>();
            if (StarType == 2) return ModContent.ItemType<StarDust>();
            return 0;
        }

        public static bool HasStarAmmo(Player player, int StarType)
        {
            int ammoType = StarAmmoType(StarType);
            return ammoType > 0 && player.HasItem(ammoType);
        }

        public static bool ConsumeStarAmmo(Player player, int StarType)
        {
            int ammoType = StarAmmoType(StarType);
            if (ammoType <= 0 || !player.HasItem(ammoType)) return false;

            float consumption = player.GetModPlayer<AstrologerPlayer>().StarAmmoConsumption;
            if (consumption <= 0f) return true;
            if (consumption >= 1f || Main.rand.NextFloat() < consumption)
            {
                player.ConsumeItem(ammoType);
            }
            return true;
        }

        public static bool StarDustConsume(Player player, int StarType)
        {
            return HasStarAmmo(player, StarType) && ConsumeStarAmmo(player, StarType);
        }

        public static void AddStarAmmoTooltip(List<TooltipLine> tooltips, Item item, int StarType)
        {
            if (Main.dedServ) return;

            int ammoType = StarAmmoType(StarType);
            if (ammoType <= 0) return;

            int percent = (int)Math.Round(Main.LocalPlayer.GetModPlayer<AstrologerPlayer>().StarAmmoConsumption * 100);
            string text = Language.GetTextValue("Mods.Twilique.Items.StarAmmoTooltip", percent, "[i:" + ammoType + "]", Lang.GetItemNameValue(ammoType));

            tooltips.Add(new TooltipLine(item.ModItem.Mod, "AmmoTooltip", "[c/87CEEB:" + text + "]"));
        }
    }
}
