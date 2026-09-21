using TMPro;
using UnityEngine;

public class Gui: MonoBehaviour {
    [SerializeField] TMP_Text m_Coins;

    // -- lifecycle --
    void Update() {
        var coins = Game.Instance.GetCoins();
        m_Coins.text = $"{coins} coins";
    }
}