using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.API.Features.Attributes;
using System.Collections.Generic;
using PlayerRoles;
using UnityEngine;
using MEC;
namespace Rolesmaster.Roles
{
    [CustomRole(PlayerRoles.RoleTypeId.Tutorial)]
    public class Testrole : CustomRole
    {
        public override uint Id { get; set; } = 14;
        public override int MaxHealth { get; set; } = 100000000;
        public override string Name { get; set; } = "TestRole";
        public override string Description { get; set; } = "Чисто админская роль которую я сделал по приколу, она ничего не несёт, но прикрольно ~пельмень";
        public override string CustomInfo { get; set; } = "для связи мой дс => pelemenb xD P.s если вы не админ то обратитесь к ним ведь у вас не должно тут быть";
        public override RoleTypeId Role { get; set; } = RoleTypeId.Tutorial;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato9, 1000 },
            { AmmoType.Ammo44Cal, 1000 },
            { AmmoType.Nato556, 1000 },
            { AmmoType.Nato762, 1000 },
            { AmmoType.Ammo12Gauge, 1000}
        };
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
                    foreach (string PlyItem in this.Inventory)
                    {
                        this.TryAddItem(player, PlyItem);
                    }
                    foreach (AmmoType key in this.Ammo.Keys)
                    {
                        player.SetAmmo(key, this.Ammo[key]);
                    }
                    player.Health = (float)this.MaxHealth;
                    player.MaxHealth = (float)this.MaxHealth;
                    player.CustomName = $"{player.Nickname} | TestRole";
                    this.ShowMessage(player);
                    this.TrackedPlayers.Add(player);
                    this.RoleAdded(player);
                    player.UniqueRole = this.Name;
                    player.TryAddCustomRoleFriendlyFire(this.Name, this.CustomRoleFFMultiplier);
                    player.CustomInfo = $"{player.Nickname}\n{this.CustomInfo}";
                    player.InfoArea &= ~PlayerInfoArea.Role;
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
