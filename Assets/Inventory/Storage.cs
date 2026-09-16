using UnityEngine;
using UnityEngine.EventSystems;

public class Storage : MonoBehaviour, IDropHandler
{
    Inventory _Inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Inventory = GetComponentInParent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject target = eventData.pointerDrag;
        if (!target)
        {
            return;
        }

        Debug.Log("dropped " + target.name);
        Potion_Ui potionUi = target.GetComponent<Potion_Ui>();
        if (potionUi)
        {
            _Inventory.DestroyPotion(potionUi);
        }
    }
}