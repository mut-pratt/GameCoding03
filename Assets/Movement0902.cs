using UnityEngine;
using UnityEngine.InputSystem;

class Movement0902: MonoBehaviour {
    /// the movement speed
    public float Speed;

    public InputActionReference Move;

    // -- lifecycle --
    void Update() {
        var input = Move.action.ReadValue<Vector2>();
        transform.position += (Vector3)input * Speed * Time.deltaTime;
    }
}