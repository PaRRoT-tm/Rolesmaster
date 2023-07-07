namespace CustomRoles.Commands.Abilities
{
    using System;
    using CommandSystem;
    using Rolesmaster.Roles;
    using Exiled.API.Features;
    using Exiled.CustomRoles.API;
    using Exiled.CustomRoles.API.Features;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TestCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string[] args = arguments.Array;
            if (args == null)
            {
                response = "Нужен аргументs. roles - выводит список ролей";
                return false;
            }

            Player player = Player.Get(((CommandSender)sender).SenderId);
            Log.Debug(args[1]);
            Player target = Player.Get(args[1]);

            if (target == null)
            {
                response = "Нужна цель";
                return false;
            }

            switch (args[2])
            {
                case "roles":
                    response = string.Empty;
                    foreach (CustomRole role in target.GetCustomRoles())
                        response += $"{role.Name}\n";
                    return true;
                case "enginer":
                    CustomRole.Get(typeof(Enginer)).AddRole(target);
                    break;
                case "leadguard":   
                    CustomRole.Get(typeof(LeadGuard)).AddRole(target);
                    break;
                case "leadscientist":
                    CustomRole.Get(typeof(Leadscientist)).AddRole(target);
                    break;
                case "leadzone":
                    CustomRole.Get(typeof(Leadzone)).AddRole(target);
                    break;
                case "techrole":
                    CustomRole.Get(typeof(Testrole)).AddRole(target);
                    break;
            }

            response = "Успешно!";
            return true;
        }

        public string Command { get; } = "debugrole";
        public string[] Aliases { get; } = { "rtest" };
        public string Description { get; } = "для дебага кастом роли";
    }
}