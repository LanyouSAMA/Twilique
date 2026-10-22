using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Twilique.Content.WorldSystem
{
	public class TwiliqueWorldSystem : ModSystem
	{
		public bool TwilightSky = false;
		public int TwilightSkyTime = 0;
		public bool LiquescenceSky = false;
		public int LiquescenceSkyTime = 0;

		public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor) {
			if (TwilightSky) {
				if (TwilightSkyTime < 10) TwilightSkyTime++;
				tileColor = new Color(56 / 10 * TwilightSkyTime, 0 / 10 * TwilightSkyTime, 76 / 10 * TwilightSkyTime);
				backgroundColor = new Color(56 / 10 * TwilightSkyTime, 0 / 10 * TwilightSkyTime, 76 / 10 * TwilightSkyTime, 0);
				TwilightSky = false;
			}
			else if (TwilightSky == false && TwilightSkyTime >= 0) {
				TwilightSkyTime--;
				tileColor = new Color(56 / 10 * TwilightSkyTime, 0 / 10 * TwilightSkyTime, 76 / 10 * TwilightSkyTime);
				backgroundColor = new Color(56 / 10 * TwilightSkyTime, 0 / 10 * TwilightSkyTime, 76 / 10 * TwilightSkyTime, 0);
			}

			if (LiquescenceSky) {
				if (LiquescenceSkyTime < 10) LiquescenceSkyTime++;
				tileColor = new Color(33 / 10 * LiquescenceSkyTime, 87 / 10 * LiquescenceSkyTime, 60 / 10 * LiquescenceSkyTime);
				backgroundColor = new Color(33 / 10 * LiquescenceSkyTime, 87 / 10 * LiquescenceSkyTime, 60 / 10 * LiquescenceSkyTime);
				LiquescenceSky = false;
			}
			else if (LiquescenceSky == false && LiquescenceSkyTime >= 0) {
				LiquescenceSkyTime--;
				tileColor = new Color(33 / 10 * LiquescenceSkyTime, 87 / 10 * LiquescenceSkyTime, 60 / 10 * LiquescenceSkyTime);
				backgroundColor = new Color(33 / 10 * LiquescenceSkyTime, 87 / 10 * LiquescenceSkyTime, 60 / 10 * LiquescenceSkyTime);
			}
		}
	}
}
