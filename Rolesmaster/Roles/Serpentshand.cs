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
    public class Serpentshand : CustomRole
    {
        public override uint Id { get; set; } = 15;
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get; set; } = "Длань змея";
        public override string Description { get; set; } = "Помогите сцп выйграть";
        public override string CustomInfo { get; set; } = "shand";
        public override RoleTypeId Role { get; set; } = RoleTypeId.Tutorial;
        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.Medkit}",
            $"{ItemType.Adrenaline}",
            $"{ItemType.Radio}",
            $"{ItemType.KeycardNTFLieutenant}",
            $"{ItemType.GrenadeHE}",
            $"{ItemType.ArmorCombat}",
            $"{ItemType.GunE11SR}",
            $"{ItemType.SCP018}"
        };
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato9, 0 },
            { AmmoType.Ammo44Cal, 0 },
            { AmmoType.Nato556, 100 },
            { AmmoType.Nato762, 0 },
            { AmmoType.Ammo12Gauge, 0}
        };
        public override void AddRole(Player player)
        {
            Vector3 pos = player.Position;
            if (this.Role != RoleTypeId.None)
            {
                player.ClearInventory();
                player.Role.Set(this.Role, RoleSpawnFlags.None);
                Timing.CallDelayed(1f, () =>
                {
                    player.Position = new Vector3(-39.46f, 991.88f, -36.2f);
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
                    player.CustomName = $"{player.Nickname} | Длань змея";
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
