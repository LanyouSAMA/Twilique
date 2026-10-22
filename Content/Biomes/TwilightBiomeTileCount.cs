using System;
using Terraria.ModLoader;
using Twilique.Content.Tiles;

namespace Twilique.Content.Biomes
{
	public class TwilightBiomeTileCount : ModSystem
	{
		public int twilightBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			twilightBlockCount = tileCounts[ModContent.TileType<TwilightRock>()];
		}
	}
}
