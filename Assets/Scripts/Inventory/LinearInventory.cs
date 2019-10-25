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

    public static int money;
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
    public bool invFilterOptions;
    [Header("Art")]
    public GUISkin invSkin;
    public GUIStyle titleStyle;
    #endregion

    private void Start()
    {
        money += 100;
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
            GUI.skin = invSkin;
            if (GUI.Button(new Rect(4f * scr.x, 6.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Filter"))
            {
                invFilterOptions = !invFilterOptions;
            }
            DisplayInv();
            GUI.skin = null;
            if (selectedItem == null)
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
        if (invFilterOptions)
        {
            if (GUI.Button(new Rect(4f * scr.x, 4.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "All"))
            {
                sortType = "All";
            }
            if (GUI.Button(new Rect(4f * scr.x, 5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Armour"))
            {
                sortType = "Armour";
            }
            if (GUI.Button(new Rect(4f * scr.x, 5.25f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Weapon"))
            {
                sortType = "Weapon";
            }
            if (GUI.Button(new Rect(4f * scr.x, 5.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Potion"))
            {
                sortType = "Potion";
            }
            if (GUI.Button(new Rect(4f * scr.x, 5.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Food"))
            {
                sortType = "Food";
            }
            if (GUI.Button(new Rect(4f * scr.x, 6f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Ingredient"))
            {
                sortType = "Ingredient";
            }
            if (GUI.Button(new Rect(4f * scr.x, 6.25f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Craftable"))
            {
                sortType = "Craftable";
            }
            if (GUI.Button(new Rect(4f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Quest"))
            {
                sortType = "Quest";
            }
            if (GUI.Button(new Rect(4f * scr.x, 6.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Misc"))
            {
                sortType = "Misc";
            }
        }
        if (!(sortType == "All" || sortType == ""))
        {
            ItemTypes type = (ItemTypes)
                System.Enum.Parse(typeof(ItemTypes), sortType);
            int a = 0; //The amount of this type
            int s = 0; //New slot position of the item
            if (a <= 34)
            {
                for (int i = 0; i < a; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }
            }
            else//We have more items than screen space
            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPos, new Rect(new Rect(0, 0, 0, inv.Count * (0.25f * scr.y))), false, true);
                #region Scrollable Space
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }
                #endregion
            }
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
                        if (GUI.Button(new Rect(0.5f * scr.x, i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
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
        GUI.skin = invSkin;
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
