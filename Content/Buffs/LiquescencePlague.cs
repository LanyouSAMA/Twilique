using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Twilique.Content.Players;
using Twilique.Content.WorldSystem;

namespace Twilique.Content.Buffs
{
	public class LiquescencePlague : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = false;
			Main.debuff[Type] = true;
			Main.lightPet[Type] = false;
			Main.buffNoTimeDisplay[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.vanityPet[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			PlaguePlayer plaguePlayer = player.GetModPlayer<PlaguePlayer>();
			plaguePlayer.LiquescencePlagueTime++;
			if (Main.netMode == NetmodeID.SinglePlayer) ModContent.GetInstance<TwiliqueWorldSystem>().LiquescenceSky = true;
			player.lifeRegen = 0;
			if (plaguePlayer.LiquescencePlagueTime % 2 == 0) {
				player.statLife -= 1;
				CombatText.NewText(player.Hitbox, CombatText.DamagedFriendly, 1);
			}
			if (player.statLife <= 1) {
				player.KillMe(PlayerDeathReason.ByCustomReason(NetworkText.FromLiteral(player.name + Language.GetTextValue("Mods.Twilique.DeadText.LiquescencePlague"))), 1, 0);
			}
		}

		public override bool ReApply(Player player, int time, int buffIndex) {
			return false;
		}
	}
}
