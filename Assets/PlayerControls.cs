using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    private Rigidbody rb;
    private bool jumped;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Accelerate
        if (Input.GetKey(KeyCode.W) && rb.velocity.x < 15)
        {
            rb.AddForce(Vector3.right, ForceMode.Acceleration);
        }

        // Brake
        if (Input.GetKey(KeyCode.S) && rb.velocity.x > 0)
        {
            rb.AddForce(Vector3.left, ForceMode.Acceleration);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 400);
            jumped = true;
        }

        // Rotate Forwards
        if (Input.GetKey(KeyCode.A) && jumped == true)
        {
            player.transform.Rotate(Vector3.forward * 180 * Time.deltaTime);
        }
        
        // Rotate Backwards
        if (Input.GetKey(KeyCode.D) && jumped == true)
        {
            player.transform.Rotate(Vector3.back * 180 * Time.deltaTime);
        }

        if (player.transform.position.y < -4.199f)
        {
            jumped = !jumped;
        }
    }
}
