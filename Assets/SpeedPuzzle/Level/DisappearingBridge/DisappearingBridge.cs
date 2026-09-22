using UnityEngine;

public class DisappearingBridge : MonoBehaviour {
    public int Number;

    public GameObject Body;

    void Start()
    {
        Body.SetActive(false);
        Game.Instance.SwitchPressed.AddListener(OnSwitchPressed);
    }

    void OnSwitchPressed(int number)
    {
        Debug.Log("bridge received: " + number);
        if (number == Number)
        {
            Body.SetActive(true);
        }
    }
}
