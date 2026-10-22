using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Biomes
{
	public class TwilightUndergroundBiome : ModBiome
	{
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/Promise");
		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override string BestiaryIcon => base.BestiaryIcon;

		public override bool IsBiomeActive(Player player) {
			return (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) &&
				ModContent.GetInstance<TwilightBiomeTileCount>().twilightBlockCount >= 300;
		}
	}
}
