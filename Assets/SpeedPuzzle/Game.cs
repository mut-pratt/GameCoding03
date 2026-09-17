using UnityEngine;

// this is our "singleton" for the game logic
public class Game: MonoBehaviour {
    public static Game Instance;
    
    // make this number show on the UI and increment it when you get a coin
    public int Coins;

    void Awake() {
        Instance = this; 
    }

    public void PressedSwitch(int number) {
        Debug.Log("pressed switch with number " + number);
    }
}
