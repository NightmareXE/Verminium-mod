using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Verminium.Items
{
    public class NaturesWand : ModItem
    {
        //public override string Texture => "Terraria/Item_" + ItemID.SpiderStaff;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Fury");
            Tooltip.SetDefault("Summons an angel of flight to fight for you");
        }
        public override void SetDefaults()
        {
            item.summon = true;
            item.mana = 20;
            item.damage = 34;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.knockBack = 2f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = item.useTime = 30;
            item.shootSpeed = 0f;
            item.width = item.height = 44;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<Projectiles.Minions.AngelOfFlight>();
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.scale = 0.1f;
            item.autoReuse = true;
            item.buffType = ModContent.BuffType<Buffs.GuardianAngel>();
            item.buffTime = 3600;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int i = 0; i < 2; i++)
            {
                Projectile.NewProjectile(Main.MouseWorld, new Vector2(speedX, speedY), type, damage, 3f, player.whoAmI);
            }
            player.AddBuff(item.buffType, 2);
            
            return false;
        }
    }
}
