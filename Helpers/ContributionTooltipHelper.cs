using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Twilique
{
    public static class ContributionTooltipHelper
    {
        /// <summary>
        /// 添加代码与纹理贡献提示(提示列表，物品，代码贡献者，纹理贡献者)
        /// 两条提示分别显示在两行
        /// </summary>
        public static void AddContributionTooltips(List<TooltipLine> tooltips, Item item, string codeContributor, string textureContributor)
        {
            if (Main.dedServ) return;

            TooltipLine codeLine = new TooltipLine(item.ModItem.Mod, "CodeContribution", Language.GetTextValue("Mods.Twilique.Items.CodeContributionTooltip", codeContributor));
            codeLine.OverrideColor = Colors.RarityGreen;
            tooltips.Add(codeLine);

            TooltipLine textureLine = new TooltipLine(item.ModItem.Mod, "TextureContribution", Language.GetTextValue("Mods.Twilique.Items.TextureContributionTooltip", textureContributor));
            textureLine.OverrideColor = Colors.RarityGreen;
            tooltips.Add(textureLine);
        }
    }
}
