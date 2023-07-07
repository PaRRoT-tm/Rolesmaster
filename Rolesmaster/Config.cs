using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Exiled.Loader;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Rolesmaster.Roles;
namespace Roles
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public Enginer Enginer { get; set; } = new Enginer();
        public LeadGuard LeadGuard { get; set; } = new LeadGuard();
        public Leadscientist Leadscientist { get; set; } = new Leadscientist();
        public Leadzone Leadzone { get; set; } = new Leadzone();
        public Testrole Testrole { get; set; } = new Testrole();

        public static Dictionary<string, ItemType> AvailableItems { get; set; } = new Dictionary<string, ItemType>
        {
            { "Adrenaline", ItemType.Adrenaline },
            { "ArmorCombat", ItemType.ArmorCombat },
            { "ArmorHeavy", ItemType.ArmorHeavy },
            { "ArmorLight", ItemType.ArmorLight },
            { "Flashlight", ItemType.Flashlight },
            { "AK", ItemType.GunAK },
            { "COM15", ItemType.GunCOM15 },
            { "COM18", ItemType.GunCOM18 },
            { "Crossvec", ItemType.GunCrossvec },
            { "E11SR", ItemType.GunE11SR },
            { "FSP9", ItemType.GunFSP9 },
            { "Logicer", ItemType.GunLogicer },
            { "Revolver", ItemType.GunRevolver },
            { "Shotgun", ItemType.GunShotgun },
            { "key1", ItemType.KeycardChaosInsurgency },
            { "key2", ItemType.KeycardGuard },
            { "key3", ItemType.KeycardNTFCommander },
            { "key4", ItemType.KeycardO5 },
            { "key5", ItemType.KeycardScientist },
            { "Medkit", ItemType.Medkit },
            { "Painkillers", ItemType.Painkillers },
            { "Radio", ItemType.Radio },
            { "SCP500", ItemType.SCP500 },
        };

        public static string scp343_first { get; set; } = "<color=red>\n-------------------------------------------------------------------</color>"+
                                                           "<color=white>\nВЫ SCP-343 (Бог), у вас нет таковой цели => вы можете делать что хотите</color>" +
                                                           "<color=green>\nУ вас есть доступные команды в это консоли [Ё]:</color>" +
                                                           "<color=blue>\n.give [id предмета который хотите] или list - он выведет лист с доступными idшками</color>"+
                                                           "<color=red>\n-------------------------------------------------------------------</color>";

        public static string scp035_first { get; set; } = "<color=red>\n-------------------------------------------------------------------</color>" +
                                                           "<color=white>\nВЫ SCP-035 (Маска), у вас есть цель уничтожить всех и сбежать!</color>" +
                                                           "<color=green>\nВажно! если вы конётесь другого человека то получите его инвентарь</color>" +
                                                           "<color=red>\n-------------------------------------------------------------------</color>";

    }
}
