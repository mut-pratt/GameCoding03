using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [Header("tuning")]
    [SerializeField] float m_Speed;
    [SerializeField] float m_TurnSpeed;

    [Header("input")]
    [SerializeField] InputActionReference m_Move;

    [Header("refs")]
    [SerializeField] CharacterController m_Controller;
    [SerializeField] GameObject m_Model;

    // Update is called once per frame
    void Update() {
        var delta = Time.deltaTime;
        var input = m_Move.action.ReadValue<Vector2>();
        var move = new Vector3(input.x, 0, input.y);
        m_Controller.SimpleMove(move * m_Speed);

        var currFwd = m_Model.transform.forward;
        var nextFwd = Vector3.RotateTowards(currFwd, move, m_TurnSpeed * delta, 0);
        m_Model.transform.forward = nextFwd;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("collided with " + other.name);
        Switch sw = other.GetComponent<Switch>();
        if (sw) {
            Game.Instance.PressSwitch(sw.Number);
        }

        Coin coin = other.GetComponent<Coin>();
        if (coin) {
            Game.Instance.AddCoin();
            Destroy(coin.gameObject);
        }

        Goal goal = other.GetComponent<Goal>();
        if (goal)
        {
            Game.Instance.TouchGoal();
        }
    }
}