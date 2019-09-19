using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSave : MonoBehaviour
{
    public PlayerHandler player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHandler>();

        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            Load();
            PlayerPrefs.SetInt("Loaded", 0);
            Save();
        }
        else
        {
            Load();
        }
    }

    public void Save()
    {
        PlayerSaveToBinary.SavePlayerData(player);
    }

    public void Load()
    {
        PlayerToSave data = PlayerSaveToBinary.LoadData(player);
        player.name = data.playerName;

        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rZ/*, data.rW*/);
    }
    /*public void Start()
    {
        if(PlayerPrefs.HasKey("Loaded"))
        {
            Load(GameObject.FindWithTag("Player").GetComponent<PlayerHandler>());
            PlayerPrefsSave.SetInt("Loaded", 0);
            Save();
        }
    }
    // Start is called before the first frame update
    public void Save(PlayerHandler player)
    {
        PlayerPrefs.SetFloat("CurHealth", player.curHealth);
        PlayerPrefs.SetFloat("CurMana", player.curMana);
        PlayerPrefs.SetFloat("CurStamina", player.curStamina);
        PlayerPrefs.SetFloat("LocationX", player.transform.localPosition.x);
        PlayerPrefs.SetFloat("LocationY", player.transform.localPosition.y);
        PlayerPrefs.SetFloat("LocationZ", player.transform.localPosition.z);
        PlayerPrefs.SetFloat("RotationX", player.transform.localRotation.x);
        PlayerPrefs.SetFloat("RotationY", player.transform.GetChild(0).localRotation.y);
        PlayerPrefs.SetFloat("RotationZ", player.transform.GetChild(0).localRotation.z);
        PlayerPrefs.SetFloat("RotationW", player.transform.GetChild(0).localRotation.w);
    }

    public void Load(PlayerHandler player)
    {
        player.curHealth = PlayerPrefs.GetFloat("CurHealth", player.maxHealth);
        player.curMana = PlayerPrefs.GetFloat("CurMana", player.maxMana);
        player.curStamina = PlayerPrefs.GetFloat("CurStamina", player.maxStamina);
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("LocationX", 3.82f), PlayerPrefs.GetFloat("LocationY", 1.18f), PlayerPrefs.GetFloat("LocationZ", 3.92f));
        player.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("RotationX", 0f), 0,0,0);
        player.transform.GetChild(0).rotation = new Quaternion(0, PlayerPrefs.GetFloat("RotationY", 0f), PlayerPrefs.GetFloat("RotationZ", 0f), PlayerPrefs.GetFloat("RotationW", 0f));
    }*/

}
