using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _mainCamera;

    

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 tmp = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector2 input = tmp ;

            //Debug.Log("mousePosition " +Input.mousePosition);
            //Debug.Log("input " + tmp);

            Messenger<Vector2>.Broadcast(Ar.PlayerInput.MousePosition, input, MessengerMode.DONT_REQUIRE_LISTENER);
        }
    }
}
