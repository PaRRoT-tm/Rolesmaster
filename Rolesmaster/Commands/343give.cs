using System;
using CommandSystem;
using Rolesmaster.Roles;
using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Config = Roles.Config;
using System.Linq;
using Plug = Roles.Plugin;
namespace scp008
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Give343 : ICommand
    {
        public string Command { get; } = "give";
        public string[] Aliases { get; } = { "giv" };
        public string Description { get; } = "Выдаёт предметы";

        bool ICommand.Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(((CommandSender)sender).SenderId);
            if (pl.UserId == Plug.scp343id)
            {
                if (arguments.Count != 1)
                {
                    response = "Использование: give <название предмета>";
                    return false;
                }

                string itemName = arguments.At(0);

                if (itemName.Equals("list", StringComparison.OrdinalIgnoreCase))
                {
                    response = "Список доступных предметов:\n\n";
                    pl.SendConsoleMessage(
                        "\nAdrenaline - Адреналин" +
                        "\nArmorCombat - Боевая броня" +
                        "\nArmorHeavy - Тяжёлая броня" +
                        "\nArmorLight - Лёгкая броня" +
                        "\nFlashlight - Фонарик" +
                        "\nAK - Автомат AK" +
                        "\nCOM15 - Пистолет COM-15" +
                        "\nCOM18 - Пистолет COM-18" +
                        "\nCrossvec - Автомат Crossvec" +
                        "\nE11SR - Автомат E-11 SR" +
                        "\nFSP9 - Пистолет FSP-9" +
                        "\nLogicer - Автомат Logicer" +
                        "\nRevolver - Револьвер" +
                        "\nShotgun - Дробовик" +
                        "\nkey1 - Карта доступа Хаоса" +
                        "\nkey2 - Карта доступа Охраны" +
                        "\nkey3 - Карта доступа Командира МОГ" +
                        "\nkey4 - Карта доступа O5" +
                        "\nkey5 - Карта доступа Учёного" +
                        "\nMedkit - Аптечка" +
                        "\nPainkillers - Болеутоляющие" +
                        "\nRadio - Рация" +
                        "\nSCP500 - SCP-500",
                        "\nMedkit - Аптечка"
                    );
                    return true;

                }

                if (Config.AvailableItems.TryGetValue(itemName, out ItemType itemType))
                {

                    Player player = Player.Get((CommandSender)sender);
                    player.AddItem(itemType);

                    response = $"Вы получили предмет: {GetLocalizedItemName(itemType)}";
                    return true;
                }
                response = $"Предмет '{itemName}' не найден или не разрешён, чтобы посмотреть список доступных => .give list .";
                return false;
            }
            else
            {
                response = "Это команда для SCP-343";
                return false;
            }
        }
        private string GetLocalizedItemName(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Adrenaline:
                    return "Адреналин";
                case ItemType.ArmorCombat:
                    return "Боевая броня";
                case ItemType.ArmorHeavy:
                    return "Тяжёлая броня";
                case ItemType.ArmorLight:
                    return "Лёгкая броня";
                case ItemType.Flashlight:
                    return "Фонарик";
                case ItemType.GunAK:
                    return "AK";
                case ItemType.GunCOM15:
                    return "COM-15";
                case ItemType.GunCOM18:
                    return "COM-18";
                case ItemType.GunCrossvec:
                    return "Crossvec";
                case ItemType.GunE11SR:
                    return "E-11 SR";
                case ItemType.GunFSP9:
                    return "FSP-9";
                case ItemType.GunLogicer:
                    return "Logicer";
                case ItemType.GunRevolver:
                    return "Револьвер";
                case ItemType.GunShotgun:
                    return "Дробовик";
                case ItemType.KeycardChaosInsurgency:
                    return "Карта доступа Хаоса";
                case ItemType.KeycardGuard:
                    return "Карта доступа Охраны";
                case ItemType.KeycardNTFCommander:
                    return "Карта доступа Командира МОГ";
                case ItemType.KeycardO5:
                    return "Карта доступа O5";
                case ItemType.KeycardScientist:
                    return "Карта доступа Учёного";
                case ItemType.Medkit:
                    return "Аптечка";
                case ItemType.Painkillers:
                    return "Болеутоляющие";
                case ItemType.Radio:
                    return "Рация";
                case ItemType.SCP500:
                    return "SCP-500";
                default:
                    return itemType.ToString();
            }
        }
    }
}
