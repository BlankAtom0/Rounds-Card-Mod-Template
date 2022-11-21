using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;
namespace Base_Card_Mod_Template.Cards
{
    internal abstract class CardBase : CustomCard
    {
        //when extening this class, you only need to override the methods you need to change
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            Main.Debug($"Card {GetTitle()} has been setup");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Main.Debug($"Card {GetTitle()} has been added to player {player.playerID}");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Main.Debug($"Card {GetTitle()} has been removed from player {player.playerID}");
        }
        protected override GameObject GetCardArt()
        {
            return Main.ArtAssets.LoadAsset<GameObject>($"C_{GetType().Name.ToUpper()}");
        }
        protected override string GetDescription()
        {
            return "";
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[0];
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.NatureBrown;
        }
        protected override string GetTitle()
        {
            return GetType().Name.Replace('_', ' '); ;
        }
        public override string GetModName()
        {
            return Main.ModInitials;
        }

        public virtual bool ShouldBuild()
        {
            return true;
        }
        internal static void BuildCallback(CardInfo card)
        {
            Main.Cards.Add(card.cardName, card);
            // uncomment if using Willuwontu's curse manager
            /*if(card.categories.Contains(CurseManager.instance.curseCategory))     
                CurseManager.instance.RegisterCurse(card);*/

            if (!((ObservableCollection<CardInfo>)typeof(CardManager).GetField("activeCards", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null)).Contains(card))
                ModdingUtils.Utils.Cards.instance.AddHiddenCard(card);
        }

        public static string CardName<T>() where T : CardBase;
        {
            return T.Name.Replace('_', ' '); ;
        }

    }
}
