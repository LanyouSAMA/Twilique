using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArkVision.NPCs.BOSS
{
    [AutoloadBossHead]
    public class PrimaryBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primary Boss");
            Main.npcFrameCount[NPC.type] = 1; // Set the number of frames for the NPC's animation
        }
        public override void SetDefaults()
        {
            NPC.width = 100; // Set the width of the NPC
            NPC.height = 100; // Set the height of the NPC
            NPC.damage = 50; // Set the damage dealt by the NPC
            NPC.defense = 20; // Set the defense of the NPC
            NPC.lifeMax = 5000; // Set the maximum life of the NPC
            NPC.HitSound = SoundID.NPCHit1; // Set the sound played when hit
            NPC.DeathSound = SoundID.NPCDeath1; // Set the sound played on death
            NPC.value = Item.buyPrice(0, 10, 0, 0); // Set the value of the NPC in coins
            NPC.knockBackResist = 0.5f; // Set knockback resistance
            NPC.aiStyle = -1; // Custom AI style (set to -1 for custom behavior)
        }
        public override void AI()
        {
            // Custom AI logic for the boss goes here
        }
    }
}