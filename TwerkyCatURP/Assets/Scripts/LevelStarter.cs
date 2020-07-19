using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    private Rigidbody2D _level;
    private bool _isGameStarted = false;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        _level = GameObject.FindGameObjectWithTag("LevelPivot").GetComponent<Rigidbody2D>();

        Messenger.AddListener(Ar.Level.start, OnGameStarted);
    }


    private void FixedUpdate()
    {
        if (!_isGameStarted) return;

        Vector2 currentPosition = _level.transform.position;
        float deltaMove = 1 - speed * Time.deltaTime;
        _level.MovePosition(currentPosition* deltaMove);
    }

    private void OnGameStarted()
    {
        Messenger.RemoveListener(Ar.Level.start, OnGameStarted);

        _isGameStarted = true;
    }
}
