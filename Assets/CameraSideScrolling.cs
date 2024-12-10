using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSideScrolling : MonoBehaviour
{
    GameObject gameCamera;
    AudioSource source;
    GameObject levelGenerator;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera");
        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        levelGenerator = GameObject.Find("Level Generator");
    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying)
        {
            gameCamera.transform.position = new Vector3(gameCamera.transform.position.x + 0.1f, gameCamera.transform.position.y, gameCamera.transform.position.z);
            levelGenerator.transform.position = new Vector3(levelGenerator.transform.position.x + 0.1f, levelGenerator.transform.position.y, levelGenerator.transform.position.z);
        }
    }
}
