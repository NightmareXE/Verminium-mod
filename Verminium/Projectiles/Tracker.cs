using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace Verminium.Projectiles
{
    public class Tracker : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.MeteorShot;
        public override void SetStaticDefaults()
        {
            //THis is just classification
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 16;
            projectile.friendly = true;
            projectile.rotation = MathHelper.ToRadians(90);
            projectile.aiStyle = -1;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.02f, 0.01f, 0.01f);
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            Vector2 move = Vector2.Zero;
            float Distance = 384f;
            bool LockOn = false;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].dontTakeDamage)
                {
                    Vector2 newMove = Main.npc[i].Center - projectile.Center;
                    float DistanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (Distance > DistanceTo)
                    {
                        move = newMove;
                        Distance = DistanceTo;
                        LockOn = true;
                    }

                }
            }
            if (LockOn)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 40f;
                AdjustMagnitude(ref projectile.velocity);

            }
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude < 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}
