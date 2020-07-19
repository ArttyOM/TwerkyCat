using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBroadcaster : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Messenger.Broadcast(Ar.Level.start);
        }
    }
}
