using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class SlimeRushBoots : ModItem
	{
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 30;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.accessory = true;
		}

		public int Time = 0;
		public const int DashRight = 2;
		public const int DashLeft = 3;

		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (Time > 0) Time--;
			if (player.controlRight && player.releaseRight && player.doubleTapCardinalTimer[DashRight] < 15 && Time <= 0) {
				for (int i = 0; i < 30; i++) {
					var dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.t_Slime, 0f, 0f, 100, new Color(50, 97, 196, 1), 2f);
					dust.noGravity = false;
				}
				player.velocity.X = 9f;
				Time = 120;
			}
			else if (player.controlLeft && player.releaseLeft && player.doubleTapCardinalTimer[DashLeft] < 15 && Time <= 0) {
				for (int i = 0; i < 30; i++) {
					var dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.t_Slime, 0f, 0f, 100, new Color(50, 97, 196, 1), 2f);
					dust.noGravity = false;
				}
				player.velocity.X = -9f;
				Time = 120;
			}
		}
	}
}
