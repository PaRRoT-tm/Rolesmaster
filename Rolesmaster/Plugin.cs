using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Player = Exiled.API.Features.Player;
using Onspawn = Rolesmaster.API.nextsh;
using Hit035 = Rolesmaster.API.scp035base;
using Main = Rolesmaster.API.main;
namespace Roles
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Roles";
        public override string Author => "pelemenb";
        public override string Prefix { get; } = "Rolemaster";  
        public override Version Version => new Version(1, 1, 0);
        public Plugin Instance;
        public Onspawn onspawn;
        public Hit035 hit035;
        public Main main;
        public static string scp343id;
        public static string scp035id;
        public override void OnEnabled()
        {
            Instance = this;
            onspawn = new Onspawn();
            hit035 = new Hit035();
            main = new Main();
            Exiled.Events.Handlers.Server.RoundStarted += main.OnRoundStarted;
            Exiled.Events.Handlers.Server.RespawningTeam += onspawn.OnSpawn;
            Exiled.Events.Handlers.Player.Hurting += hit035.Hit035;
            Exiled.Events.Handlers.Player.Died += main.OnDie;
            CustomRole.RegisterRoles(true, Config.Enginer);
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= main.OnRoundStarted;
            Exiled.Events.Handlers.Server.RespawningTeam -= onspawn.OnSpawn;
            Exiled.Events.Handlers.Player.Hurting -= hit035.Hit035;
            Exiled.Events.Handlers.Player.Died -= main.OnDie;
            CustomRole.UnregisterRoles();
            base.OnDisabled();
        }
        public static void Scp343add(Player pl)
        {
            Log.Info($"SCP-343: {pl.Nickname}");
            scp343id = pl.UserId;
        }
        public static void Scp035add(Player pl)
        {
            Log.Info($"SCP-035: {pl.Nickname}");
            scp035id = pl.UserId;
        }
    }
}
    