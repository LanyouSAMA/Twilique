using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Twilique.Content.Players;
using Twilique.Content.WorldSystem;
namespace Twilique.Content.Buffs
{
	public class TwilightPlague : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = false;
			Main.debuff[Type] = true;
			Main.lightPet[Type] = false;
			Main.buffNoTimeDisplay[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.vanityPet[Type] = false;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			PlaguePlayer plaguePlayer = player.GetModPlayer<PlaguePlayer>();
			plaguePlayer.TwilightPlagueTime++;
			if (Main.netMode == NetmodeID.SinglePlayer) ModContent.GetInstance<TwiliqueWorldSystem>().TwilightSky = true;
			player.statLifeMax2 -= (int)(player.buffTime[buffIndex] / 2);
			player.controlUseItem = false;
			player.lifeRegen = 0;
			if (plaguePlayer.TwilightPlagueTime % 12 == 0) {
				player.statLife -= 1;
				CombatText.NewText(player.Hitbox, CombatText.DamagedFriendly, 1);
			}
			if (player.statLife <= 1) {
				player.KillMe(PlayerDeathReason.ByCustomReason(NetworkText.FromLiteral(player.name + Language.GetTextValue("Mods.Twilique.DeadText.TwilightPlague"))), 1, 0);
			}
		}

		public override bool ReApply(Player player, int time, int buffIndex) {
			player.buffTime[buffIndex] += time;
			return true;
		}
	}
}
