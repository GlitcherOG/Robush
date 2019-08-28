using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]
    public float curHealth,curMana,curStamina;
    public float maxHealth,maxMana,maxStamina;
    [Header("Value Variables")]    // Start is called before the first frame update
    public Slider healthBar, manaBar, staminaBar;
    public GameObject PlayerObject;
    void Start()
    {
        PlayerObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value != Mathf.Clamp01(curHealth / maxHealth))
        {
            curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
            healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        }
        if (manaBar.value != Mathf.Clamp01(curMana / maxMana))
        {
            curMana = Mathf.Clamp(curMana, 0, maxMana);
            manaBar.value = Mathf.Clamp01(curMana / maxMana);
        }
        if (staminaBar.value != Mathf.Clamp01(curStamina / maxStamina))
        {
            curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
            staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
        }
    }
}
