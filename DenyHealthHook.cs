using HarmonyLib;
using UnityEngine;
using ULTRAKILL;

namespace UltraRogue;

[HarmonyPatch(typeof(NewMovement), "GetHealth")]
public class DenyHealthHook() {
  static int health;
  static void Prefix() {
    health = MonoSingleton<NewMovement>.Instance.hp;
  }

  static void Postfix() {
    MonoSingleton<NewMovement>.Instance.hp = health;
  }
}
