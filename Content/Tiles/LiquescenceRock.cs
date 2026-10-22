using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Twilique.Content.Buffs;
using Twilique.Content.Dusts;

namespace Twilique.Content.Tiles
{
	public class LiquescenceRock : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileFrameImportant[Type] = false;
			TileID.Sets.Conversion.Sand[Type] = true;
			HitSound = SoundID.Dig;
			DustType = ModContent.DustType<LiquescenceStar>();
			MineResist = 1f;
			MinPick = 65;

			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(0, 115, 57), name);
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void RandomUpdate(int i, int j) {
			int r;
			if (Main.hardMode) r = Main.rand.Next(5);
			else r = Main.rand.Next(50);
			if (r == 0) {
				int typeI = i + Main.rand.Next(-3, 4);
				int typeJ = j + Main.rand.Next(-3, 4);
				int type = Main.tile[typeI, typeJ].TileType;
				if (TileID.Sets.Conversion.Dirt[type] || type == TileID.Grass || type == TileID.GolfGrass ||
					type == TileID.Stone || type == TileID.Sand || type == TileID.HardenedSand || type == TileID.Sandstone ||
					type == TileID.JungleGrass || type == TileID.Mud) {
					Main.tile[typeI, typeJ].TileType = (ushort)ModContent.TileType<LiquescenceRock>();
					WorldGen.SquareTileFrame(typeI, typeJ);
					NetMessage.SendTileSquare(-1, typeI, typeJ, 1);
				}
			}
		}

		public override void FloorVisuals(Player player) {
			player.AddBuff(ModContent.BuffType<LiquescencePlague>(), 2);
		}
	}
}
