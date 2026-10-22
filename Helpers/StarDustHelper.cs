using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
        /// <summary>
        /// 获取星尘弹药的物品类型(消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式调用：StarDustHelper.StarAmmoType(2)
        /// </summary>
        public static int StarAmmoType(int StarType)
        {
            if (StarType == 0) return ItemID.FallenStar;
            if (StarType == 1) return ModContent.ItemType<StarFragments>();
            if (StarType == 2) return ModContent.ItemType<StarDust>();
            return 0;
        }

        /// <summary>
        /// 检查星尘弹药是否持有，不会消耗(玩家，消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式写在CanUseItem钩子的return上：
        /// StarDustHelper.HasStarAmmo(player, 2) ? base.CanUseItem(player) : false
        /// </summary>
        public static bool HasStarAmmo(Player player, int StarType)
        {
            int ammoType = StarAmmoType(StarType);
            return ammoType > 0 && player.HasItem(ammoType);
        }

        /// <summary>
        /// 按当前消耗率结算一次星尘弹药(玩家，消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式写在Shoot钩子的return上：
        /// StarDustHelper.ConsumeStarAmmo(player, 2)
        /// </summary>
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

        /// <summary>
        /// 星尘弹药的旧版合并入口，会检查并结算消耗(玩家，消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式写在Shoot钩子的return上：
        /// StarDustHelper.StarDustConsume(player, 2)
        /// </summary>
        public static bool StarDustConsume(Player player, int StarType)
        {
            return HasStarAmmo(player, StarType) && ConsumeStarAmmo(player, StarType);
        }

        /// <summary>
        /// 获取星尘弹药的物品图标文本(消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式调用：StarDustHelper.StarAmmoIcon(2)
        /// </summary>
        public static string StarAmmoIcon(int StarType)
        {
            if (StarType == 1) return "[i:Twilique/StarFragments]";
            if (StarType == 2) return "[i:Twilique/StarDust]";
            int ammoType = StarAmmoType(StarType);
            return ammoType > 0 ? "[i:" + ammoType + "]" : "";
        }

        /// <summary>
        /// 添加星尘弹药的消耗率提示(提示列表，物品，消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式写在ModifyTooltips钩子里：
        /// StarDustHelper.AddStarAmmoTooltip(tooltips, Item, 2);
        /// </summary>
        public static void AddStarAmmoTooltip(List<TooltipLine> tooltips, Item item, int StarType)
        {
            if (Main.dedServ) return;

            int ammoType = StarAmmoType(StarType);
            if (ammoType <= 0) return;

            int percent = (int)Math.Round(Main.LocalPlayer.GetModPlayer<AstrologerPlayer>().StarAmmoConsumption * 100);
            string text = Language.GetTextValue("Mods.Twilique.Items.StarAmmoTooltip", percent, Lang.GetItemNameValue(ammoType), StarAmmoIcon(StarType));

            TooltipLine line = new TooltipLine(item.ModItem.Mod, "AmmoTooltip", text);
            line.OverrideColor = new Color(135, 206, 235);
            tooltips.Add(line);
        }
    }
}
