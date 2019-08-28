using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerToSave
{
    //Data
    public string playerName;
    public int level;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;

    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.name;
        level = 0;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        pX = player.transform.postion.x;
        pY = player.transform.postion.y;
        pZ = player.transform.postion.z;

        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;
    }
}
