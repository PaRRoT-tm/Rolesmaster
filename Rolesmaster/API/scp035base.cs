using Exiled.Events.EventArgs.Player;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;
using Onspawn = Rolesmaster.API.nextsh;
using PlayerRoles;
using System.Linq;
using System.IO;
using Achievements.Handlers;
using Exiled.API.Enums;
using Exiled.Events.EventArgs;
using UnityEngine;
using Exiled.Events.EventArgs.Server;
using Plug = Roles.Plugin;
using System;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using System.Collections.Generic;
using Exiled.API.Features.Items;

namespace Rolesmaster.API
{
    public class scp035base
    {
        public void Hit035(HurtingEventArgs ev)
        {
            if (ev.Attacker is Player attacker && attacker.UserId == Plug.scp035id)
            {
                Vector3 targetpos = ev.Player.Position;
                ev.Attacker.ClearInventory();

                foreach (var item in ev.Player.Items)
                {
                    ev.Attacker.AddItem(item);
                }
                ev.Player.Kill(DamageType.Scp);
                Log.Debug($"scp035 захватил -> {ev.Player}");
                ev.Attacker.ShowHint($"<color=green>Вы захватили тело игрока</color><color=yellow>{ev.Player.Nickname}</color>");
            }
        }
    }
}
