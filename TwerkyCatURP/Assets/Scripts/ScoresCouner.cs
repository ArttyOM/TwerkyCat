using Ar;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresCouner : MonoBehaviour
{
    private int _scores = 0;
    private TextMeshProUGUI textHolder;

    private void Awake()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("Scores");
        textHolder = tmp.GetComponent<TextMeshProUGUI>();
        Messenger.AddListener(Ar.Scores.addScore, AddScore);
        
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(Ar.Scores.addScore, AddScore);
    }

    private void AddScore()
    {
        _scores++;
        textHolder.text = _scores.ToString();
    }
}

