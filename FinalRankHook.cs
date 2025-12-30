using HarmonyLib;
using UnityEngine;
using ULTRAKILL;

namespace UltraRogue;

[HarmonyPatch(typeof(FinalRank), "Appear")]
public class FinalRankHook {
  private static BepInEx.Logging.ManualLogSource log = Plugin.Logger;
  static void Postfix() {
    UltraRogueMain.storedHealth = MonoSingleton<NewMovement>.Instance.hp;
  }
}