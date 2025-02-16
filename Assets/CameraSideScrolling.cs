using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSideScrolling : MonoBehaviour
{
    GameObject gameCamera;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("PlayerTest");
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
    }
}
