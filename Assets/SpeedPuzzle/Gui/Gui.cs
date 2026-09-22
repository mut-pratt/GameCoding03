using TMPro;
using UnityEngine;

public class Gui: MonoBehaviour {
    [SerializeField] TMP_Text m_Coins;
    [SerializeField] TMP_Text m_PlayerWin;

    // -- lifecycle --
    private void Start()
    {
        Game.Instance.PlayerWon.AddListener(OnPlayerWon);  
    }

    void Update() {
        var coins = Game.Instance.GetCoins();
        m_Coins.text = $"{coins} coins";
    }

    void OnPlayerWon()
    {
        m_PlayerWin.gameObject.SetActive(true);
    }
}