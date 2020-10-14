using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Verminium.Items
{
    public class AngelusShotgun : ModItem
    {
        //public override string Texture => "Terraria/Item_" + ItemID.TacticalShotgun;
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut; //5
            item.useTime = 30;
            item.useAnimation = 30;
            item.ranged = true;
            item.value = Item.sellPrice(gold: 1);
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = SoundID.Item11;
            item.shoot = 6;
            item.shootSpeed = 8;
            item.damage = 46;
            item.rare = ItemRarityID.Blue;
           
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<Projectiles.LeadShower>();
            int numProj = 6;
            for(int i = 0; i < numProj; i++)
            {
                Vector2 rotVel = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(16));
                Projectile.NewProjectile(position, rotVel, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
