using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Wolf : Enemy
{
    [Space(5), Header("Wolf Stats")]
    public float curStanina;
    public float maxStamina;

    public override void Attack()
    {
        if (Vector3.Distance(player.position, self.transform.position) > attackRange)
        {
            return;
        }
        Debug.Log("Action 1");

        base.Attack();

        Debug.Log("Action2");
    }

    public void BiteAttack()
    {
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if(critChance==20)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().curHealth -= (baseDamage * difficulty) + critDamage;
    }
}
