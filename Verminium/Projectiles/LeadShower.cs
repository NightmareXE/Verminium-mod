using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Verminium.Projectiles
{
    public class LeadShower : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.Bullet;

        public override void SetDefaults()
        {
            projectile.width = projectile.height = 16;
            projectile.friendly = true;
            projectile.aiStyle = -1;
            
            projectile.rotation = MathHelper.ToRadians(90);
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.02f, 0.01f, 0.01f);
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //Slightly randomizing the spawn position
            Vector2 spawnPos = new Vector2(Main.rand.NextBool(2) ? target.Center.X - 32 : target.Center.Y + 32, target.Center.Y - 640);
            Vector2 vel = target.Center - spawnPos;
            vel.Normalize();

            
            Projectile.NewProjectile(spawnPos, vel * 5, ModContent.ProjectileType<Tracker>(), damage, knockback, Main.myPlayer);


        }
    }
}
