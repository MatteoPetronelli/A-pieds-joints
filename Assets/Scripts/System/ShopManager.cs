using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject sellButton;
    public Transform sellButtonsParent;
    public static ShopManager instance;
    public Items[] itemsToSell;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public void Start()
    {
        UpdateItemsToSell(itemsToSell);

    }

    public void UpdateItemsToSell(Items[] items)
    {
        for (int i = 0; i < sellButtonsParent.childCount; i++)
        {
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(sellButton, sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = items[i].name;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();

            buttonScript.item = items[i];

            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); });
        }
    }
}