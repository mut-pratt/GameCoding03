using UnityEngine;
using UnityEngine.InputSystem;

public class Movement0914: MonoBehaviour {  
    [Header("tuning")]
    [Tooltip("the base movement speed")]
    [SerializeField] float m_BaseSpeed;

    [Tooltip("the acceleration when running")]
    [SerializeField] float m_RunAcceleration;

    [Tooltip("the gradient based on speed")]
    [SerializeField] Gradient m_Gradient;

    [Tooltip("the max movement speed color")]
    [SerializeField] float m_MaxSpeed;

    [Header("refs")]
    [Tooltip("the move input")]
    [SerializeField] InputActionReference m_Move;

    [Tooltip("the run input")]
    [SerializeField] InputActionReference m_Run;

    /// the current speed
    float m_Speed;

    ///  the sprite renderer
    SpriteRenderer m_Sprite;

    // -- lifecycle --
    void Awake() {
        m_Sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        var delta = Time.deltaTime;

        var speed = m_Speed;
        var isRun = m_Run.action.ReadValue<float>() > 0;
        if (isRun) {
            speed += m_RunAcceleration * delta;
        } else {
            speed = m_BaseSpeed;
        }

        var move = (Vector3)m_Move.action.ReadValue<Vector2>();
        var pos = transform.position;

        pos += move * speed * delta;

        // update state
        transform.position = pos;
        m_Speed = speed;

        // update color
        var color = m_Gradient.Evaluate(Mathf.InverseLerp(m_BaseSpeed, m_MaxSpeed, speed));
        m_Sprite.color = color;
    }
}
