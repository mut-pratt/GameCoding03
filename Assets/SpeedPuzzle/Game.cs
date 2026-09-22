using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// this is our "singleton" for the game logic
public class Game: MonoBehaviour 
{
    // -- statics --
    public static Game Instance;

    [Header("config")]
    public int NumLevels;

    // -- props --
    /// when the switch gets pressed
    public UnityEvent<int> SwitchPressed;

    /// when the player wins
    public UnityEvent PlayerWon;

    /// the current number of coins
    int _Coins;

    /// the current level
    int _CurrentLevel;

    // -- lifecycle --
    void Awake() 
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // -- commands -- (methods that do something and change state)
    /// command to indicate the switch was pressed
    public void PressSwitch(int number) 
    {
        Debug.Log("pressed switch with number " + number);
        SwitchPressed.Invoke(number);
    }

    /// command to indicate the goal was touched
    public void TouchGoal()
    {
        _CurrentLevel++;
        if (_CurrentLevel >= NumLevels)
        {
            PlayerWon.Invoke();
        } 
        else
        {
            SceneManager.LoadScene(_CurrentLevel);
        }
    }

    /// command: gets a coin (a way to modify Coins)
    public void AddCoin()
    {
        _Coins++;
    }

    /// command to lose coins
    public void LoseCoins(int count)
    {
        _Coins -= count;

        if (_Coins < 0)
        {
            _Coins = 0;
        }
    }

    // -- queries -- methods that get values in the state
    /// query: gives us the current amount of coins
    // a query, with no parameters, that basically returns a simple value of a property
    // we call that a "getter"
    public int GetCoins()
    {
        return _Coins;
    }

    // these are syntax that exists, and is the same as a getter
    /* 
    public int Coins {
        get {
            return _Coins;
        }
    }

    or this

    public int Coins {
        get => _Coins;
    }
    */
}
