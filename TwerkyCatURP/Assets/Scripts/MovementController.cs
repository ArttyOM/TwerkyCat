using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float dragPower = 3f;

    [SerializeField] private Vector2 leashPivot = Vector2.zero;
    [SerializeField] private float leashDistance = 5f;

    private Rigidbody2D _puppet;
    private Transform _puppetTransform;


    private Vector2 _positionAtStart;
    private Vector2 _counterGravity = new Vector2(0f, -9.8f);


    private void Awake()
    {
        _puppet = this.GetComponent<Rigidbody2D>();
        _puppetTransform = _puppet.transform;
        _positionAtStart = _puppetTransform.position;
        Messenger<Vector2>.AddListener(Ar.PlayerInput.MousePosition, OnInput);
    }

    private void OnDestroy()
    {
        Messenger<Vector2>.RemoveListener(Ar.PlayerInput.MousePosition, OnInput);
    }


    private void OnInput(Vector2 inputData)
    {
        Vector2 puppetPosition = _puppetTransform.position;

        Vector2 mousePositionOffset = inputData - puppetPosition; //InputMovementUtility.getMousePositionOffet(inputData, _puppetTransform);

        //Debug.Log("InputData: " + inputData);
        //Debug.Log("MousePosition offset: " + mousePositionOffset);

        if (mousePositionOffset.sqrMagnitude > 0.1f)
        {
            
            mousePositionOffset = mousePositionOffset.normalized;

            _puppet.MovePosition(puppetPosition + mousePositionOffset* dragPower *Time.deltaTime);
        }

    }
}
