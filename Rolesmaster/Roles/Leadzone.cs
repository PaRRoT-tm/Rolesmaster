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
    [CustomRole(PlayerRoles.RoleTypeId.Scientist)]
    public class Leadzone : CustomRole
    {
        public override uint Id { get; set; } = 13;
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get; set; } = "Менеджер зон содержания";
        public override string Description { get; set; } = "Наблюдает за зонами содержания комплекса";
        public override string CustomInfo { get; set; } = "Leadzone";
        public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;
        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.Medkit}",
            $"{ItemType.Painkillers}",
            $"{ItemType.Radio}",
            $"{ItemType.KeycardZoneManager}"
        };
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato9, 0 },
            { AmmoType.Ammo44Cal, 0 },
            { AmmoType.Nato556, 0 },
            { AmmoType.Nato762, 0 },
            { AmmoType.Ammo12Gauge, 0}
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
                    player.CustomName = $"{player.Nickname} | Менеджер зон содержания";
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
