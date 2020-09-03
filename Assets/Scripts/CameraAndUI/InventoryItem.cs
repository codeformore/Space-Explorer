using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    //UI Variables
    public Text itemName;
    public Text itemDescription;
    public Text weight;
    public Image itemIcon;

    //Set the display of the inventoryItemUI
    public void SetDisplay(Item itemToDisplay, float totalWeight)
    {

        itemName.text = itemToDisplay.itemName;
        itemDescription.text = itemToDisplay.description;
        itemIcon.sprite = itemToDisplay.icon;
        weight.text = totalWeight + " kg";
        gameObject.SetActive(true);

    }
    
}
