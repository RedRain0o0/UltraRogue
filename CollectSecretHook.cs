using HarmonyLib;
using UnityEngine;
using ULTRAKILL;

namespace UltraRogue;

[HarmonyPatch(typeof(Bonus), "OnTriggerEnter")]
class CollectSecretHook {
  private static BepInEx.Logging.ManualLogSource log = Plugin.Logger;
  static void Postfix(Bonus __instance, Collider other) {
    // Copy activated boolean
    bool shadowActivated = (bool)Traverse.Create(__instance).Field("activated").GetValue();

    // Check if the Collider was the player or if the orb was already active
    if (!other.gameObject.CompareTag("Player")) {
    	return;
    }

    UltraRogueMain.healthFromBonus = true;

    // Add health
    if (__instance.superCharge) {
      if (MonoSingleton<NewMovement>.Instance.hp > 500) {
        MonoSingleton<NewMovement>.Instance.hp += 200;
      } else {
        MonoSingleton<NewMovement>.Instance.hp = 500;
      }
    } else {
      MonoSingleton<NewMovement>.Instance.hp += 100;
    }

    UltraRogueMain.healthFromBonus = false;
  }
}