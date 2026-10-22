using System;
using Terraria.ModLoader;
using Twilique.Content.Tiles;

namespace Twilique.Content.Biomes
{
	public class LiquescenceBiomeTileCount : ModSystem
	{
		public int liquescenceBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			liquescenceBlockCount = tileCounts[ModContent.TileType<LiquescenceRock>()];
		}
	}
}
