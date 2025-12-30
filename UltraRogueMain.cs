public class UltraRogueMain {
  public static int storedHealth = 400;

  public static void OnSceneLoad() {
    MonoSingleton<NewMovement>.Instance.hp = storedHealth;
  }
}