using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory: MonoBehaviour {
    public List<Potion> Potions;
    public Potion_Ui PotionUiPrefab;
    public Transform PotionsGrid;
    public TMPro.TMP_Text Description;

    public UnityEvent<Potion> OnAnyPotionClicked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < Potions.Count; i++)
        {
            Potion potion = Potions[i];
            CreateUiPotion(potion);
        }
    }

    /// <summary>
    /// gets a new potion and adds it to our inventory
    /// </summary>
    public void GetPotion(Potion potion)
    {
        Potions.Add(potion);
        CreateUiPotion(potion);
        UpdateDescription(potion);
    }

    /// <summary>
    /// create a new ui potion icon
    /// </summary>
    void CreateUiPotion(Potion potion)
    {
        Potion_Ui potionUi = Instantiate<Potion_Ui>(PotionUiPrefab, PotionsGrid);
        potionUi.Potion = potion;

        // this is creating an annonymous function, we need it to be able to "capture"
        // the local variable potion on the onClick callback (the function thats called
        // when the button is clicked)
        potionUi.OnPotionClicked.AddListener(OnPotionClicked);
    }

    void OnPotionClicked(Potion potion) {
        OnAnyPotionClicked.Invoke(potion);
    }

    public void UpdateDescription(Potion potion)
    {
        Description.text = potion.Description;
    }

    public void DestroyPotion(Potion_Ui potionUi) {
        Potions.Remove(potionUi.Potion);
        Destroy(potionUi.gameObject);
    }
}