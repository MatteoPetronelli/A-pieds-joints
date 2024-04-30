using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;
    public Items item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if (inventory.sanityCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.sanityCount -= item.price;
            inventory.UpdateTextUI();
        }
    }
}
