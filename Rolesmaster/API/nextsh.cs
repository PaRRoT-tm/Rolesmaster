using MEC;
using System;
using Exiled;
using Respawning;
using Rolesmaster.Roles;
using Exiled.API.Features;
using CommandSystem.Commands;
using Exiled.Events.Handlers;
using System.Collections.Generic;
using Exiled.Events.EventArgs.Player;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System.Linq;
namespace Rolesmaster.API
{
    public class nextsh
    {
        public void OnSpawn(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency && Player.List.ToList().Count() >= 6)
            {
                int c = UnityEngine.Random.Range(0, 2);
                if (c > 0)
                {
                    ev.IsAllowed = true;
                    ev.NextKnownTeam = SpawnableTeamType.ChaosInsurgency;
                }
                else
                {
                    ev.IsAllowed = false;
                    foreach(Player pl in Player.List)
                    {
                        if (pl.Role == RoleTypeId.Spectator)
                        {
                            pl.ClearInventory();
                            CustomRole.Get(typeof(Serpentshand))?.AddRole(pl);
                        }
                    }
                }
            }
            else{ev.IsAllowed = true;}
        }
    }
}
