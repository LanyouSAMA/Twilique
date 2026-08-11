using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Items.Weapons.Melee
{
    public class RustyHunter : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 33;
            Item.width = 40;
            Item.height = 38;
            Item.scale = 1f;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.knockBack = 5f;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.value = Item.buyPrice(0, 4, 0, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.RustyHunter>();
            Item.shootSpeed = 12;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                foreach (Projectile projectile in Main.projectile)
                {
                    if (projectile.active && projectile.type == ModContent.ProjectileType<Projectiles.Melee.RustyHunter>() && Main.myPlayer == projectile.owner)
                    {
                        projectile.ai[2] = 1f;
                    }
                }
            }
            else
            {
                Projectile.NewProjectile(player.GetSource_FromAI(), player.Center, velocity * Item.shootSpeed / 3, ModContent.ProjectileType<Projectiles.Melee.RustyHunter>(), damage, 3f, Main.myPlayer);
            }
            return false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
    }



    public class RustyHunterDrop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            return npc.type == NPCID.GoblinWarrior;
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RustyHunter>(), 100, 1, 1));
            base.ModifyNPCLoot(npc, npcLoot);
        }
    }
}