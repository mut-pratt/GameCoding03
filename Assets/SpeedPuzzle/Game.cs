using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// this is our "singleton" for the game logic
public class Game: MonoBehaviour {
    public static Game Instance;

    // -- config --
    [SerializeField] string[] m_Levels;

    // -- props --
    int m_CurrentLevel = 0;

    /// the number of coins the player currently has
    public int Coins;

    /// event when the switch gets pressed
    public UnityEvent<int> SwitchPressed;

    // -- instance --
    void Awake() {
        // there can only be one singleton, so destroy yourself if an instance already exists
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // -- commands --
    public void PressSwitch(int number) {
        Debug.Log("press switch with number " + number);
        SwitchPressed.Invoke(number);
    }

    public void TouchGoal() {
        var maxLevels = m_Levels.Length;
        m_CurrentLevel = (m_CurrentLevel + 1) % maxLevels;
        SceneManager.LoadScene(m_Levels[m_CurrentLevel]);
    }
}