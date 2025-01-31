using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.right, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.Acceleration);
        }
    }
}
