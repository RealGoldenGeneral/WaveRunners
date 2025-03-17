using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PositionText : MonoBehaviour
{
    private TMP_Text _textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update player position
        for (int i = 0; i < GameState.positions.Length; i++)
        {
            if (GameState.positions[i].name == "PlayerTest")
            {
                _textMeshPro.text = $"Position: {i + 1}/4";
            }
        }
    }
}
