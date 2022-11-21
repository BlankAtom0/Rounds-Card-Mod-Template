using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Base_Card_Mod_Template.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using UnboundLib.Cards;
using UnityEngine;

namespace Base_Card_Mod_Template
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class Main : BaseUnityPlugin
    {
        private const string ModId = "com.My.Mod.Id";
        private const string ModName = "MyModName";
        public const string Version = "0.0.0";
        public const string ModInitials = "MMN";
        public static ConfigEntry<bool> DEBUG;
        public static Dictionary<string, CardInfo> Cards = new Dictionary<string, CardInfo>();
        public static int CardCount;
        internal static AssetBundle Assets;
        public static Main instance { get; private set; }

        void Awake()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();

            DEBUG = base.Config.Bind<bool>(ModInitials, "Debug", false, "Enable to turn on debug messages from this mod");
        }
        void Start()
        {
            instance = this;
            Unbound.RegisterMenu($"{ModName} Settings", delegate () { }, new Action<GameObject>(this.NewGUI), null, true);

            Assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("assets", typeof(Main).Assembly);

            foreach (Type card in typeof(Main).Assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(CardBase))))
            {
                if ((bool)card.GetMethod(nameof(CardBase.ShouldBuild)).Invoke(card.GetConstructor(new Type[] { }).Invoke(new object[] { }), new object[] { }))
                {
                    CardCount++;
                    typeof(CustomCard).GetMethod(nameof(CustomCard.BuildCard), new Type[] { typeof(Action<CardInfo>) }).MakeGenericMethod(card).Invoke(null, new object[] { (Action<CardInfo>)CardBase.BuildCallback });
                }
            }
        }

        private void NewGUI(GameObject menu)
        {
            TextMeshProUGUI textMeshProUGUI;
            MenuHandler.CreateText($"{ModName} Settings", menu, out textMeshProUGUI, 60, false, null, null, null, null);
            GameObject toggle = MenuHandler.CreateToggle(DEBUG.Value, "Debug Mode", menu, delegate (bool value)
            {
                DEBUG.Value = value;
            }, 50, false, Color.red, null, null, null);
        }

        //Use calls to this method when debugging things (Prevents log spam to users who arnt debugging)
        public static void Debug(object message)
        {
            if (DEBUG.Value)
            {
                UnityEngine.Debug.Log($"{ModName}=> {message}");
            }
        }
    }
}
