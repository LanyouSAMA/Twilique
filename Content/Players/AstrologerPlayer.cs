using Terraria.ModLoader;

namespace Twilique.Content.Players
{
    public class AstrologerPlayer : ModPlayer
    {
        public float StarAmmoConsumption = 1f;

        public override void ResetEffects() {
            StarAmmoConsumption = 1f;
        }
    }
}
