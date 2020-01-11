using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public float damage = 1;
    public LayerMask isPlayer;
    public Transform HelpPos;
    int Range = 1;
    public float HelpR;

    void OnTriggerEnter2D(Collider2D Help)
    {
        if ((Help.gameObject.name == "Player"))
        {
            Collider2D[] playerToHelp = Physics2D.OverlapCircleAll(HelpPos.position, HelpR, isPlayer);
            for (int i = 0; i < playerToHelp.Length; i++)
            {
                playerToHelp[i].GetComponent<PlayerController>().Help();
            }
            Destroy(gameObject);
        }

    }

}
