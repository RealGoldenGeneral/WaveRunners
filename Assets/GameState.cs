using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject player;
    public GameObject AI1;
    public GameObject AI2;
    public GameObject AI3;
    public static GameObject[] positions;

    public static int CompareRacers(GameObject p1, GameObject p2)
    {
        if (p1.transform.position.x > p2.transform.position.x) return -1;
        else if (p1.transform.position.x == p2.transform.position.x) return 0;
        else return 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        positions = new GameObject[4];
        positions[0] = player;
        positions[1] = AI1;
        positions[2] = AI2;
        positions[3] = AI3;
    }

    // Update is called once per frame
    void Update()
    {
        Array.Sort(positions, CompareRacers);
    }
}
