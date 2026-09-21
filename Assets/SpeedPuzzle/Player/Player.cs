using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [Header("tuning")]
    [SerializeField] float m_Speed;

    [Header("input")]
    [SerializeField] InputActionReference m_Move;

    [Header("refs")]
    [SerializeField] CharacterController m_Controller;

    // Update is called once per frame
    void Update() {
        var input = m_Move.action.ReadValue<Vector2>();
        var move = new Vector3(input.x, 0, input.y);
        m_Controller.SimpleMove(move * m_Speed);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("collided with " + other.name);
        Switch sw = other.GetComponent<Switch>();
        if (sw) {
            Game.Instance.PressSwitch(sw.Number);
        }

        Coin coin = other.GetComponent<Coin>();
        if (coin) {
            Game.Instance.Coins++;
            Destroy(coin.gameObject);
        }

        Goal goal = other.GetComponent<Goal>();
        if (goal) {
            Game.Instance.TouchGoal();
        }
    }
}