using Rolesmaster.Roles;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;
using PlayerRoles;
using System.Linq;
using Exiled.Events.Handlers;
using Exiled.Events.EventArgs.Player;
using Plug = Roles.Plugin;
using Server = Exiled.API.Features.Server;
namespace Rolesmaster.API
{
    public class main
    {
        public void OnRoundStarted()
        {
            Log.Debug("Roles>>Start");
            bool leadguard = false;
            bool leadscientist = false;
            bool leadzone = false;
            bool leadenginer = false;
            if (Player.List.ToList().Count >= 5)
            {
                foreach (Player player in Player.List)
                {
                    switch (player.Role.Type)
                    {
                        case RoleTypeId.FacilityGuard when !leadguard:
                            {
                                CustomRole.Get(typeof(LeadGuard))?.AddRole(player);
                                leadguard = true;
                                Log.Debug("LeadG+");
                                break;
                            }
                        case RoleTypeId.Scientist when !leadscientist || !leadzone || !leadenginer:
                            {
                                if (!leadscientist)
                                {
                                    CustomRole.Get(typeof(Leadscientist))?.AddRole(player);
                                    leadscientist = true;
                                    Log.Debug("LeadS+");
                                    break;
                                }
                                if (!leadzone)
                                {
                                    CustomRole.Get(typeof(Leadzone))?.AddRole(player);
                                    leadzone = true;
                                    Log.Debug("LeadZ+");
                                    break;
                                }
                                if (!leadenginer)
                                {
                                    CustomRole.Get(typeof(Enginer))?.AddRole(player);
                                    leadenginer = true;
                                    Log.Debug("LeadE+");
                                    break;
                                }
                                break;
                            }
                    }
                }
            }
        }
        public void OnDie(DiedEventArgs ev)
        {
            if(ev.Player.UserId == Plug.scp035id)
            {
                int scp = 0;
                foreach(Player pl in Player.List)
                {
                    if (pl.IsScp) { scp += 1; }
                }
                ev.Player.Kill(Exiled.API.Enums.DamageType.Recontainment, $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSCP 0 35 .G6 RECONTAINED .G3 REMAINING {scp} SCP");
            }
        }
    }
}
