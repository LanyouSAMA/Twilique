using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.Items.AstrologerAmmo;

namespace Twilique
{
    public static class StarDustHelper
    {
        /// <summary>
        /// 星尘的消耗(玩家， 消耗种类[0为坠星，1为碎星，2为星尘])
        /// 需要按如下格式写在CanUseItem钩子的return上：
        /// StarDustHelper.StarDustConsume(player, 2) ? base.CanUseItem(player) : false
        /// </summary>
        public static bool StarDustConsume(Player player, int StarType)
        {
            if (StarType == 0 && player.HasItem(ItemID.FallenStar))
            {
                player.ConsumeItem(ItemID.FallenStar);
                return true;
            }
            else if (StarType == 1 && player.HasItem(ModContent.ItemType<StarFragments>()))
            {
                player.ConsumeItem(ModContent.ItemType<StarFragments>());
                return true;
            }
            else if (StarType == 2 && player.HasItem(ModContent.ItemType<StarDust>()))
            {
                player.ConsumeItem(ModContent.ItemType<StarDust>());
                return true;
            }
            return false;
        }
    }
}
