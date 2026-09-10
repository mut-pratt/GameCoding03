using UnityEngine;
using UnityEngine.InputSystem;


public class Movement0909 : MonoBehaviour
{
    [SerializeField] InputActionReference Move;
    [SerializeField] InputActionReference Run;
    [SerializeField] Tuning Tuning;

    void Update()
    {
        var delta = Time.deltaTime;

        var move = Move.action.ReadValue<Vector2>();
        var isRun = Run.action.ReadValue<bool>();
        var speed = isRun ? Tuning.RunSpeed : Tuning.MoveSpeed;
        transform.position += (Vector3)move * speed * delta;
    }
}
