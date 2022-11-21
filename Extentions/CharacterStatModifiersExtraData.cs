using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ROUNDS_the_Spire.Extentions
{
    [Serializable]
    public class CharacterStatModifiersExtraData
    {
        public string example_data;
        public CharacterStatModifiersExtraData()
        {
            this.example_data = "Defult Value";
        }
        public void Reset()
        {
            this.example_data = "Defult Value";
        }
    }

    public static class CharacterStatModifiersExtension
    {
        public static readonly ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersExtraData> data =
          new ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersExtraData>();


        public static CharacterStatModifiersExtraData ObtainAdditionalData(this CharacterStatModifiers characterstats)
        {
            return data.GetOrCreateValue(characterstats);
        }


        public static void AddData(this CharacterStatModifiers characterstats, CharacterStatModifiersExtraData value)
        {
            try
            {
                data.Add(characterstats, value);
            }
            catch (Exception) { }
        }

    }
    [HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
    class CharacterStatModifiersPatchResetStats
    {
        private static void Prefix(CharacterStatModifiers __instance)
        {
            __instance.ObtainAdditionalData().Reset();
        }
    }
}
