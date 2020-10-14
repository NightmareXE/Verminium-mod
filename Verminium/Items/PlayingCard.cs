using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Verminium.Items
{
    public class PlayingCard : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.WarAxeoftheNight;
        public override void SetDefaults()
        {
            item.damage = 14;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = ModContent.ProjectileType<Projectiles.PlayingCard>();
            item.shootSpeed = 7f;
            item.thrown = true;
            item.maxStack = 999;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.width = item.height = 16;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cobweb, 10);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();


        }
    }
}
