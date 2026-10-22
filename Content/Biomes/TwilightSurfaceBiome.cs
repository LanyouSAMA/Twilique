using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Twilique.Content.WorldSystem;

namespace Twilique.Content.Biomes
{
	public class TwilightSurfaceBiome : ModBiome
	{
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/Promise");
		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Twilique/TwilightSurfaceBackgroundStyle");

		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => base.BackgroundPath;
		public override string MapBackground => BackgroundPath;

		public override bool IsBiomeActive(Player player) {
			return (player.ZoneSkyHeight || player.ZoneOverworldHeight) &&
				ModContent.GetInstance<TwilightBiomeTileCount>().twilightBlockCount >= 300;
		}

		public override void OnInBiome(Player player) {
			ModContent.GetInstance<TwiliqueWorldSystem>().TwilightSky = true;
		}
	}

	public class TwilightBiomeNPC : GlobalNPC
	{
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
			if (spawnInfo.Player.InModBiome(ModContent.GetInstance<TwilightSurfaceBiome>()) || spawnInfo.Player.InModBiome(ModContent.GetInstance<LiquescenceUndergroundBiome>())) pool[0] = 0;
		}
	}
}
