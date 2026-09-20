using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Things/Potion", order = 0)]
// Potion is a ScriptableObject
public class Potion: ScriptableObject {
    public string DisplayName;
    public string Description;
    public Sprite Image;
    public string Type;
    public float Power;
    public float Duration;
}
