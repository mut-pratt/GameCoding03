using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// class inherits from one other class
// class can implement as many interfaces as you need
public class Potion_Ui: MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Potion Potion;
    public Image Image;
    public Button Button;
    public TMP_Text Text;

    Vector3 _StoredPosition;
    Inventory _Inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Image.sprite = Potion.Image;
        Text.text = Potion.DisplayName;
        name = Potion.DisplayName;
        _Inventory = GetComponentInParent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        _StoredPosition = transform.position;
        transform.parent = _Inventory.transform;

        // disable the raycast target so that its not consuming raycasts
        Image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.position = _StoredPosition;
        transform.parent = _Inventory.PotionsGrid;


        // re-enable the raycast target to make object interactable again
        Image.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
