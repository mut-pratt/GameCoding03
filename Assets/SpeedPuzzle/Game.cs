using UnityEngine;

// this is our "singleton" for the game logic
public class Game: MonoBehaviour 
{
    public static Game Instance;
    
    // make this number show on the UI and increment it when you get a coin
    int _Coins;

    void Awake() 
    {
        Instance = this; 
    }

    public void PressSwitch(int number) 
    {
        Debug.Log("pressed switch with number " + number);
    }

    // commands - methods that do something and change state
    // command: gets a coin (a way to modify Coins)
    public void AddCoin()
    {
        _Coins++;
    }

    public void LoseCoins(int count)
    {
        _Coins -= count;

        if (_Coins < 0)
        {
            _Coins = 0;
        }
    }

    // queries - methods that get values in the state
    // query: gives us the current amount of coins
    // query, with no parameters, that basically returns a simple value of a property
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

    //public void SetCoins(int coins) {
    //    _Coins = coins;
    //}
}
