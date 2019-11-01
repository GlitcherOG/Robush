using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customistaion : MonoBehaviour
{
    public Renderer characterRenderer;
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int skinMax, eyesMax, mouthMax, hairMax, clothesMax, armourMax;
    public int points = 15;
    public string characterName = "Adventure";
    Texture[] textures;
    int selectedIndex = 0;
    [System.Serializable]
    public struct Stats
    {
        public string statName;
        public int statValue;
        public int tempStat;
    };
    public Stats[] playerStats = new Stats[6];
    public CharacterClass charClass;
    public Vector2 scr;
    public void Save()
    {

    }
    public void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        switch(type)
        { 
        case "Skin":
            index = skinIndex;
            max = skinMax;
            matIndex = 1;
            textures = skin.ToArray();
            break;
        case "Eyes":
            index = eyesIndex;
            max = eyesMax;
            matIndex = 2;
            textures = eyes.ToArray();
            break;
        case "Mouth":
            index = mouthIndex;
            max = mouthMax;
            matIndex = 3;
            textures = mouth.ToArray();
            break;
        case "Hair":
            index = hairIndex;
            max = hairMax;
            matIndex = 4;
            textures = hair.ToArray();
            break;
        case "Clothes":
            index = clothesIndex;
            max = clothesMax;
            matIndex = 5;
            textures = clothes.ToArray();
            break;
        case "Armour":
            index = armourIndex;
            max = armourMax;
            matIndex = 6;
            textures = armour.ToArray();
            break;
        }
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }
    }
    public void OnGUI()
    {
        scr = new Vector2(Screen.width / 16, Screen.height / 9);
        DisplayCustom();
        DisplayStats();
    }
    public void DisplayCustom()
    {
        int i = 0;
        #region Skin
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Skin", -1);
        }
        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Skin");
        if (GUI.Button(new Rect(scr.x * 1.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Skin", 1);
        }
        i++;
        #endregion
        #region Eyes
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Eyes", -1);
        }
        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Eyes");
        if (GUI.Button(new Rect(scr.x * 1.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Eyes", 1);
        }
        i++;
        #endregion
        #region Mouth
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Mouth", -1);
        }
        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Mouth");
        if (GUI.Button(new Rect(scr.x * 1.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Mouth", 1);
        }
        i++;
        #endregion
        #region Hair
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Hair", -1);
        }
        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Hair");
        if (GUI.Button(new Rect(scr.x * 1.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Hair", 1);
        }
        i++;
        #endregion
        #region Clothes
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Clothes", -1);
        }
        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Clothes");
        if (GUI.Button(new Rect(scr.x * 1.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Clothes", 1);
        }
        i++;
        #endregion
        #region Armour
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Armour", -1);
        }
        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Armour");
        if (GUI.Button(new Rect(scr.x * 1.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Armour", 1);
        }
        #endregion
        i++;
        if (GUI.Button(new Rect(scr.x * 0.25f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Random"))
        {
            SetTexture("Skin", Random.Range(-skinMax, skinMax));
            SetTexture("Eyes", Random.Range(-eyesMax, eyesMax));
            SetTexture("Mouth", Random.Range(-mouthMax, mouthMax));
            SetTexture("Hair", Random.Range(-hairMax, hairMax));
            SetTexture("Clothes", Random.Range(-clothesMax, clothesMax));
            SetTexture("Armour", Random.Range(-armourMax, armourMax));
        }
        if (GUI.Button(new Rect(scr.x * 1.25f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Reset"))
        {
            SetTexture("Skin", -skinIndex);
            SetTexture("Eyes", -eyesIndex);
            SetTexture("Mouth", -mouthIndex);
            SetTexture("Hair", -hairIndex);
            SetTexture("Clothes", -clothesIndex);
            SetTexture("Armour", -armourIndex);
        }
    }
    void DisplayStats()
    {
        characterName = GUI.TextField(new Rect(scr.x * 6f, scr.y * 7.5f, scr.x * 4, scr.y * 0.5f), characterName, 20);
        #region Class
        int i = 0;
        if (GUI.Button(new Rect(scr.x * 13.75f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = 11;
            }
            ChooseClass(selectedIndex);
        }
        GUI.Box(new Rect(scr.x * 14.25f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), charClass.ToString());
        if (GUI.Button(new Rect(scr.x * 15.25f, scr.y + i * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            selectedIndex++;
            if (selectedIndex > 0)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }
        #endregion
        #region StatDistribution
        //in variables public int points = 10
        GUI.Box(new Rect(scr.x * 13.75f, scr.y*1.5f + i * (0.5f * scr.y), scr.x* 2f, scr.y * 0.5f), "Points:" + points);
        for (int s = 0; s < playerStats.Length; s++)
        {
            if (points > 0)
            {
                if (GUI.Button(new Rect(scr.x * 15.25f, scr.y * 2f + s * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "+"))
                {
                    points--;
                    playerStats[s].tempStat++;
                }
            }
            GUI.Box(new Rect(scr.x * 14.25f, scr.y * 2f + s * (0.5f * scr.y), scr.x, scr.y * 0.5f), playerStats[s].statName + ": " + (playerStats[s].statValue + playerStats[s].tempStat));
            if (playerStats[s].tempStat > 0)
            {
                if (GUI.Button(new Rect(scr.x * 13.75f, scr.y * 2f + s * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "-"))
                {
                    points++;
                    playerStats[s].tempStat--;
                }
        }
    }
        #endregion
    }

    void ChooseClass(int className)
    {
        if (className < 0)
        {
            className = 11;
        }
        else if (className > 11)
        {
            className = 0;
        }
        switch (className)
        {
            case 0:
                playerStats[0].statValue = 15;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 5;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Cleric;
                break;
            case 3:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Druid;
                break;
            case 4:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Fighter;
                break;
            case 5:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Monk;
                break;
            case 6:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Paladin;
                break;
            case 7:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Ranger;
                break;
            case 8:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Rouge;
                break;
            case 9:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 15;
                charClass = CharacterClass.Sorcerer;
                break;
            case 10:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Warlock;
                break;
            case 11:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Wizard;
                break;
        }

    }
    //public int strength, dexterity, constitution, wisdom. intelligence, charisma;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            skin.Add(tempTexture);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/eyes_" + i.ToString()) as Texture2D;
            eyes.Add(tempTexture);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/mouth_" + i.ToString()) as Texture2D;
            mouth.Add(tempTexture);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/hair_" + i.ToString()) as Texture2D;
            hair.Add(tempTexture);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/clothes_" + i.ToString()) as Texture2D;
            clothes.Add(tempTexture);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/armour_" + i.ToString()) as Texture2D;
            armour.Add(tempTexture);
        }
        SetTexture("Skin", 0);
        SetTexture("Eyes", 0);
        SetTexture("Mouth", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum CharacterClass
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rouge,
 Sorcerer,
 Warlock,
 Wizard
}
