using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStarCollected : MonoBehaviour
{

    private bool isFirstEntry = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tail" && isFirstEntry)
        {
            isFirstEntry = false;
            Messenger.Broadcast(Ar.Scores.addScore);

            Destroy(this.gameObject);
        }
    }
}
