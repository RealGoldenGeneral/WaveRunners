using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSideScrolling : MonoBehaviour
{
    GameObject gameCamera;
    GameObject player;
    GameObject levelGenerator;
    //GameObject ai;
    Vector3[] lastPositions;
    //Vector3 lastPosition;
    //Vector3 aiLastPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("PlayerTest");
        levelGenerator = GameObject.Find("Level Generator");
        lastPositions = new Vector3[4];
        //ai = GameObject.Find("AI Player 1");
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
        levelGenerator.transform.position += new Vector3(GameState.positions[0].transform.position.x - lastPositions[0].x, 0, 0);
        for (int j = 1; j < GameState.positions.Length; ++j)
        {
            GameState.positions[j].transform.position += new Vector3((GameState.positions[0].transform.position.x - lastPositions[0].x) * 0.5f, 0, 0);
        }
        //if (player.GetComponent<Rigidbody>().velocity.x > ai.GetComponent<Rigidbody>().velocity.x && player.transform.position.x > ai.transform.position.x)
        //{
        //    ai.transform.position = ai.transform.position + new Vector3((player.transform.position.x - lastPosition.x) * 0.25f, 0, 0);
        //}
        //if (player.GetComponent<Rigidbody>().velocity.x < 1)
        //{
        //    levelGenerator.transform.position = levelGenerator.transform.position + new Vector3(ai.transform.position.x - aiLastPosition.x, 0, 0);
        //    player.transform.position = player.transform.position + new Vector3((ai.transform.position.x - aiLastPosition.x) * 0.75f, 0, 0);
        //}
        //else
        //{
        //    levelGenerator.transform.position = levelGenerator.transform.position + new Vector3(player.transform.position.x - lastPosition.x, 0, 0);
        //}
        //lastPosition = player.transform.position;
        //aiLastPosition = ai.transform.position;
        for (int i = 0; i < lastPositions.Length; i++)
        {
            lastPositions[i] = GameState.positions[i].transform.position;
        }
    }
}
