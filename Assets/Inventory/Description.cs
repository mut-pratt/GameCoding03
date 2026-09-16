using UnityEngine;
using TMPro;

public class Description : MonoBehaviour {
    TMP_Text _Text;
    Inventory _Inventory;

    void Awake() {
        _Text = GetComponent<TMP_Text>();
        _Inventory = GetComponentInParent<Inventory>();
        _Inventory.OnAnyPotionClicked.AddListener(ChangeDescription);
    }

    public void ChangeDescription(Potion potion) {
        _Text.text = potion.Description;
    }
}