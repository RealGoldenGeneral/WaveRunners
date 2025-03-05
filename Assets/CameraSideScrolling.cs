using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSideScrolling : MonoBehaviour
{
    GameObject gameCamera;
    GameObject player;
    GameObject levelGenerator;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("PlayerTest");
        levelGenerator = GameObject.Find("Level Generator");
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
        levelGenerator.transform.position = levelGenerator.transform.position + new Vector3(player.transform.position.x - lastPosition.x, 0, 0);
        lastPosition = player.transform.position;
    }
}
