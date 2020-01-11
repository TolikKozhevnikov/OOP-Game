using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUpdate : SawSpaen
{
    bool attack = true;
    public float damage = 1;
    public LayerMask isPlayer;
    public Transform attackPos;
    int Range = 1;
    public float attackRange;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -3f));
        Destroy(gameObject, 2);

    }

    void OnTriggerEnter2D(Collider2D saw)
    {
        if (saw.gameObject.name == "Player")
        {

                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isPlayer);
                for (int i = 0; i < playerToDamage.Length; i++)
                    playerToDamage[i].GetComponent<PlayerController>().Damage(damage);
            }
        }
    }




