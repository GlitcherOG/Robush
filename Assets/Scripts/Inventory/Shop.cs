using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool showShop;
    public int[] itemsToSpawn;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;

    private void Start()
    {
        itemsToSpawn = new int[Random.Range(1, 11)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            itemsToSpawn[i] = Random.Range(0, 4);
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
        }
    }

    private void OnGUI()
    {
        if (showShop)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            GUI.Box(new Rect(6.5f * scr.x, 0.25f * scr.y, 3 * scr.x, 0.45f * scr.y), "$" + LinearInventory.money);
            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y + (i * 0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedShopItem = shopInv[i];
                }
            }
            if (selectedShopItem == null)
            {
                return;
            }
            else
            {
                int cost = (int)((float)selectedShopItem.Value * (5f / 4f));
                GUI.Box(new Rect(6.5f * scr.x, 0.75f * scr.y, 3 * scr.x, 0.45f * scr.y), "$" + cost);
                if (LinearInventory.money >= cost)
                {
                    if (GUI.Button(new Rect(12.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Buy"))
                    {
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedShopItem.ID));
                        LinearInventory.money -= cost;
                        shopInv.Remove(selectedShopItem);
                        selectedShopItem = null;
                    }
                }
            }
        }
    }
}