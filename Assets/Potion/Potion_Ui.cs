using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Potion_Ui : MonoBehaviour {
    public Potion Potion;
    public Image Image;
    public TMP_Text Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Image.sprite = Potion.Image;
        Text.text = Potion.DisplayName;
    }
}
