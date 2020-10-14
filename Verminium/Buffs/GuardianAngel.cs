using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Verminium.Buffs
{
    public class GuardianAngel : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Guardian Angel");
            Description.SetDefault("The Angel of Flight will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            VerminiumPlayer modPlayer = player.GetModPlayer<VerminiumPlayer>();

            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.AngelOfFlight>()] > 0)
            {
                modPlayer.flightAngelMinion = true;
            }
            if (!modPlayer.flightAngelMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}
