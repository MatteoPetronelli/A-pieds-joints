using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int sanityCount;
    public Text txtSanity;
    public List<Items> content = new List<Items>();
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Text itemNameUI;
    public Sprite emptyItemImage;
    public static Inventory instance;
    private int destroyCount = 2;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        Items currentItem = content[contentCurrentIndex];
        TimerUI.instance.AddTime(currentItem.BonusSeconds);
        if (currentItem.ControlSeconds > 0) { 
            TimerUI.instance.FreezeTime(currentItem.ControlSeconds);
        }
        if(currentItem.upgradeZone > 0)
        {
            pointerColl.instace.UpgradeZone(currentItem.upgradeZone);
        }
        if (currentItem.timeToDestroy > 0)
        {
            pointerColl.instace.boolDestroy = true;
            StartCoroutine(destroyTime());
        }
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }

    public void AddSanity(int count)
    {
        sanityCount += count;
        UpdateTextUI();
    }

    public void RemoveSanity(int count)
    {
        sanityCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        txtSanity.text = sanityCount.ToString();
    }

    IEnumerator destroyTime()
    {
        while (destroyCount > 0)
        {
            yield return new WaitForSeconds(1f);
            destroyCount--;
            if (destroyCount <= 0)
            {
                pointerColl.instace.boolDestroy = false;
                StopCoroutine(destroyTime());
            }
        }
    }
}
