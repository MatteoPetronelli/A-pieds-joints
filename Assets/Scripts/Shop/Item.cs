using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Inventory/Items")]
public class Items : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public int price;
    public Sprite image;
    public int ControlSeconds;
    public int BonusSeconds;
    public int upgradeZone;
    public int timeToDestroy;
}
