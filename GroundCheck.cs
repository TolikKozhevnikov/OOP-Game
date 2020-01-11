using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.tag == "Ground1")
            GetComponentInParent<PlayerController>().Ground = true;
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Ground1")
            GetComponentInParent<PlayerController>().Ground = false;
    }

}
