using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.WorldSystem;

namespace Twilique.Content.Biomes
{
	public class LiquescenceSurfaceBiome : ModBiome
	{
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/AllInYourHead");
		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Twilique/LiquescenceSurfaceBackgroundStyle");

		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => base.BackgroundPath;
		public override string MapBackground => BackgroundPath;

		public override bool IsBiomeActive(Player player) {
			return (player.ZoneSkyHeight || player.ZoneOverworldHeight) &&
				ModContent.GetInstance<LiquescenceBiomeTileCount>().liquescenceBlockCount >= 300;
		}

		public override void OnInBiome(Player player) {
			ModContent.GetInstance<TwiliqueWorldSystem>().LiquescenceSky = true;
		}
	}

	public class LiquescenceBiomeNPC : GlobalNPC
	{
		public static bool spawn = false;

		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
			if ((spawnInfo.Player.InModBiome(ModContent.GetInstance<LiquescenceSurfaceBiome>()) || spawnInfo.Player.InModBiome(ModContent.GetInstance<LiquescenceUndergroundBiome>()))
				&& (!spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)) {
				pool[0] = 0;
				spawn = true;
			}
			else spawn = false;
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
			if (spawn) {
				maxSpawns = (int)(maxSpawns * 1.5f);
				spawnRate = (int)(spawnRate * 0.75f);
			}
		}
	}
}
