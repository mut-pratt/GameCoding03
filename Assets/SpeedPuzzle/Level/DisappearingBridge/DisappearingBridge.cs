using UnityEngine;

public class DisappearingBridge: MonoBehaviour {
    [Header("config")]
    [SerializeField] int m_Number;

    [Header("refs")]
    [SerializeField] GameObject m_Body;

    // -- lifecycle --
    void Start() {
        Game.Instance.SwitchPressed.AddListener(OnSwitchPressed);
    }

    // -- events --
    void OnSwitchPressed(int number) {
        if (m_Number == number) {
            m_Body.SetActive(true);
        }
    }
}