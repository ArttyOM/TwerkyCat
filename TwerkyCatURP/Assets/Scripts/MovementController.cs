using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float dragPower = 7f;

    private Rigidbody2D _puppet;
    private Transform _puppetTransform;

    private Rigidbody2D _head;
    private List<Rigidbody2D> _tail;


    private Vector2 _positionAtStart;
    private Vector2 _counterGravity = new Vector2(0f, -9.8f);


    private void Awake()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("Puppet");
        _puppet = tmp.GetComponent<Rigidbody2D>();
        _puppetTransform = _puppet.transform;
        _positionAtStart = _puppetTransform.position;
        Messenger<Vector2>.AddListener(Ar.PlayerInput.MousePosition, OnInput);

        _head = GameObject.FindGameObjectWithTag("Head").GetComponent<Rigidbody2D>();
        _tail = GameObject.FindGameObjectWithTag("Tail").GetComponentsInChildren<Rigidbody2D>().ToList();
    }

    private void OnDestroy()
    {
        Messenger<Vector2>.RemoveListener(Ar.PlayerInput.MousePosition, OnInput);
    }

    private void FixedUpdate()
    {
        CompensateGravity();
    }

    private void CompensateGravity()
    {
        Vector2 forceSummary = Vector2.zero;

        forceSummary -= _head.mass * _head.gravityScale * Physics2D.gravity;
        for (int i=0; i< _tail.Count; i++)
        {
            forceSummary -= _tail[i].mass * _tail[i].gravityScale * Physics2D.gravity;
        }
        _puppet.AddForce(forceSummary);
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

            Vector2 deltaMove = mousePositionOffset * dragPower; //* Time.deltaTime;
            _puppet.velocity = puppetPosition + deltaMove;
            //_puppet.MovePosition(puppetPosition + mousePositionOffset* dragPower *Time.deltaTime);
        }

    }
}
