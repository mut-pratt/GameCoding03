using UnityEngine;

class Coin: MonoBehaviour {
    [Header("tuning")]
    [SerializeField] float m_RotationSpeed;

    // -- lifecycle --
    void Update() {
        transform.rotation *= Quaternion.AngleAxis(m_RotationSpeed * Time.deltaTime, Vector3.up);
    }
}