using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    private Rigidbody rb;
    private int flips;
    private bool jumped = false;
    // Start is called before the first frame update
    void Start()
    {
        flips = 0;
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Accelerate
        if (Input.GetKey(KeyCode.W) && rb.velocity.x < 5)
        {
            rb.AddForce(Vector3.right, ForceMode.Acceleration);
        }

        // Brake
        if (Input.GetKey(KeyCode.S) && rb.velocity.x > 0)
        {
            rb.AddForce(Vector3.left, ForceMode.Acceleration);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            player.transform.position = player.transform.position + new Vector3(0, 0.05f, 0);
            rb.AddForce(Vector3.up * 400);
            jumped = true;
        }

        // Rotate Forwards
        if (Input.GetKey(KeyCode.D) && jumped)
        {
            player.transform.Rotate(Vector3.forward * 180 * Time.deltaTime);
        }
        
        // Rotate Backwards
        if (Input.GetKey(KeyCode.A) && jumped)
        {
            player.transform.Rotate(Vector3.back * 180 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (jumped)
        {
            jumped = false;
        }
    }
}
