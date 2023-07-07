using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.API.Features.Attributes;
using System.Collections.Generic;
using PlayerRoles;
using UnityEngine;
using MEC;
using Plug = Roles.Plugin;
using Config = Roles.Config;
namespace Rolesmaster.Roles
{
    [CustomRole(PlayerRoles.RoleTypeId.Tutorial)]
    public class Scp343 : CustomRole
    {
        public override uint Id { get; set; } = 16;
        public override int MaxHealth { get; set; } = 1000;
        public override string Name { get; set; } = "SCP-343 Бог";
        public override string Description { get; set; } = "Вы бог, вы бессметрны <color=red>ПРОЧИТАЙТЕ СООБЩЕНИЕ В КОНСОЛИ [Ё]</color>";
        public override string CustomInfo { get; set; } = "scp343";
        public override List<string> Inventory { get; set; } = new List<string>{};
        public override void AddRole(Player player)
        {
            player.ClearInventory();
            Vector3 pos = player.Position;
            if (this.Role != RoleTypeId.None)
            {
                player.Role.Set(this.Role, RoleSpawnFlags.None);
                Timing.CallDelayed(1f, () =>
                {
                    player.Position = pos;
                    player.ClearInventory();
                    player.Health = (float)this.MaxHealth;
                    player.MaxHealth = (float)this.MaxHealth;
                    player.CustomName = $"{player.Nickname} | SCP-343";
                    this.ShowMessage(player);
                    this.TrackedPlayers.Add(player);
                    this.RoleAdded(player);
                    player.UniqueRole = this.Name;
                    player.TryAddCustomRoleFriendlyFire(this.Name, this.CustomRoleFFMultiplier);
                    player.CustomInfo = $"{player.Nickname}\n{this.CustomInfo}";
                    player.InfoArea &= ~PlayerInfoArea.Role;
                    Plug.Scp343add(player);
                    player.SendConsoleMessage(Config.scp343_first, "white");
                });
            }
            base.RoleAdded(player);
        }
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
        }
    }
}
