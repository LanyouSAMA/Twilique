using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Twilique.Content.Buffs;
using Twilique.Content.Dusts;
using Twilique.Content.Players;

namespace Twilique.Content.Tiles
{
	public class TwilightRock : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileFrameImportant[Type] = false;
			TileID.Sets.Conversion.Stone[Type] = true;
			HitSound = SoundID.Tink;
			DustType = ModContent.DustType<TwilightStar>();
			MineResist = 4f;
			MinPick = 65;

			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(93, 0, 128), name);
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void RandomUpdate(int i, int j) {
			int r;
			if (Main.hardMode) r = Main.rand.Next(25);
			else r = Main.rand.Next(250);
			if (r == 0) {
				int typeI = i + Main.rand.Next(-3, 4);
				int typeJ = j + Main.rand.Next(-3, 4);
				int type = Main.tile[typeI, typeJ].TileType;
				if (type == TileID.Stone) {
					Main.tile[typeI, typeJ].TileType = (ushort)ModContent.TileType<TwilightRock>();
					WorldGen.SquareTileFrame(typeI, typeJ);
					NetMessage.SendTileSquare(-1, typeI, typeJ, 1);
				}
			}
		}

		public override void FloorVisuals(Player player) {
			PlaguePlayer plaguePlayer = player.GetModPlayer<PlaguePlayer>();
			plaguePlayer.TwilightRockTime++;
			if (plaguePlayer.TwilightRockTime % 6 == 0) {
				CombatText.NewText(player.Hitbox, CombatText.DamagedFriendly, 6);
				player.AddBuff(ModContent.BuffType<TwilightPlague>(), 12);
			}
		}
	}
}
