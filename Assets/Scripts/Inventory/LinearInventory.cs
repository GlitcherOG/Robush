using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public Vector2 scr;

    public int money;
    public Vector2 scrollPos;

    public string sortType = "All";

    public Transform dropLocation;

    [System.Serializable]
    public struct EquippedItems
    {
        public string slotName;
        public Transform location;
        public GameObject equippedItem;
    };
    public EquippedItems[] equippedItems;
    #endregion

    private void Start()
    {
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(3));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(601));
        inv.Add(ItemData.CreateItem(602));
        inv.Add(ItemData.CreateItem(700));
        inv.Add(ItemData.CreateItem(701));
        inv.Add(ItemData.CreateItem(702));
    }

    private void Update()
    {
       if(Input.GetButtonDown("Inventory") && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if(showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
       if(Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(Random.Range(0, 3)));
        }
       if(Input.GetKey(KeyCode.KeypadPlus))
        {
            inv[10].Amount = 52;
        }
    }

    private void OnGUI()
    {
        if(showInv)
        {
            scr = new Vector2(Screen.width / 16, Screen.height / 9);
            DisplayInv();
            if(selectedItem == null)
            {
                return;
            }
            else
            {
                UseItem();
            }
        }
    }

    void DisplayInv()
    {
        if (!(sortType == "All" || sortType == ""))
        {

        }
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            else//We have more items than screen space
            {
                //our move position of our scroll window
                //The start of our scroll view
                //Our position and size of our window
                //Our current position in the scroll view
                //viewable area
                //Can we see our horizontal bar?
                //Can we see our vertical bar?
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(new Rect(0, 0, 0, inv.Count * (0.25f * scr.y))), false, true);
                #region Scrollable Space
                for (int i = 0; i < inv.Count; i++)
                {
                    if(GUI.Button(new Rect(0.5f * scr.x, i * (0.25f * scr.y), 3 * scr.x, 0.25f* scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
                #endregion
                GUI.EndScrollView();

            }
        }
    }
    void UseItem()
    {
        GUI.Box(new Rect(6.5f * scr.x, 2.4f * scr.y, 3 * scr.x, scr.y * 0.25f), selectedItem.Name);
        GUI.Box(new Rect(6.5f * scr.x, 2.7f * scr.y, 3 * scr.x, scr.y * 3), selectedItem.IconName);
        GUI.Box(new Rect(6.5f * scr.x, 5.8f * scr.y, 3 * scr.x, scr.y * 1.5f), selectedItem.Description);
        switch (selectedItem.ItemType)
        {
            case ItemTypes.Armour:
                if (GUI.Button(new Rect(6.5f * scr.x, 7.4f * scr.y, 1.75f * scr.x, 0.25f * scr.y), "Wear"))
                {

                }
                break;
            case ItemTypes.Weapon:
                if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
                {
                    if (GUI.Button(new Rect(6.5f * scr.x, 7.4f * scr.y, 1.75f * scr.x, 0.25f * scr.y), "Equip"))
                    {

                    }
                }
                break;
            case ItemTypes.Potion:
                if (GUI.Button(new Rect(6.5f * scr.x, 7.4f * scr.y, 1.75f * scr.x, 0.25f * scr.y), "Drink"))
                {

                }
                break;
            case ItemTypes.Food:
                if (GUI.Button(new Rect(6.5f * scr.x, 7.4f * scr.y, 1.75f * scr.x, 0.25f * scr.y), "Eat"))
                {

                }
                break;
            case ItemTypes.Ingredient:
                if (GUI.Button(new Rect(6.5f * scr.x, 7.4f * scr.y, 1.75f * scr.x, 0.25f * scr.y), "Use"))
                {

                }
                break;
            case ItemTypes.Craftable:
                if (GUI.Button(new Rect(6.5f * scr.x, 7.4f * scr.y, 1.75f * scr.x, 0.25f * scr.y), "Use"))
                {

                }
                break;

            default:
                break;
        }
        if (GUI.Button(new Rect(8.5f * scr.x, 7.4f * scr.y, 1f * scr.x, 0.25f * scr.y), "Discard"))
        {
            for (int i = 0; i < equippedItems.Length; i++)
            {
                if(equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
                {
                    Destroy(equippedItems[i].equippedItem);
                }
            }
            GameObject itemToDrop = Instantiate(selectedItem.MeshName, dropLocation.position, Quaternion.identity);
            itemToDrop.name = selectedItem.Name;
            itemToDrop.AddComponent<Rigidbody>().useGravity = true;

            if(selectedItem.Amount > 1)
            {
                selectedItem.Amount--;
            }
            else
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
            //Check if the item is equipped
            //If so destroy from scene
            //Spawn item at droplocation
            //Apply gravity and make sure its named correctly
            //is the amount >1
                //If so reduce from list
                //Else remove from list
        }
    }
}
