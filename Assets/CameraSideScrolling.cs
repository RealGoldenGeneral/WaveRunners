using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSideScrolling : MonoBehaviour
{
    GameObject gameCamera;
    GameObject player;
    GameObject levelGenerator;
    GameObject ai;
    Vector3 lastPosition;
    Vector3 aiLastPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("PlayerTest");
        levelGenerator = GameObject.Find("Level Generator");
        ai = GameObject.Find("AI Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
        if (player.GetComponent<Rigidbody>().velocity.x > ai.GetComponent<Rigidbody>().velocity.x && player.transform.position.x > ai.transform.position.x)
        {
            ai.transform.position = ai.transform.position + new Vector3((player.transform.position.x - lastPosition.x) * 0.75f, 0, 0);
        }
        if (player.GetComponent<Rigidbody>().velocity.x < 1)
        {
            levelGenerator.transform.position = levelGenerator.transform.position + new Vector3(ai.transform.position.x - aiLastPosition.x, 0, 0);
            player.transform.position = player.transform.position + new Vector3((ai.transform.position.x - aiLastPosition.x) * 0.75f, 0, 0);
        }
        else
        {
            levelGenerator.transform.position = levelGenerator.transform.position + new Vector3(player.transform.position.x - lastPosition.x, 0, 0);
        }
        lastPosition = player.transform.position;
        aiLastPosition = ai.transform.position;
    }
}
