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
    public FlipMeter flipMeter;
    public FlipCounter flipCounter;
    private bool flippedOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        flips = 0;
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.hasStarted)
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
                flipMeter.Appear();
                flipCounter.Appear();
            }

            // Rotate Forwards
            if (Input.GetKey(KeyCode.D) && jumped)
            {
                player.transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
                flipMeter.SetFlipProgress(player.transform.eulerAngles.z);
                if (player.transform.eulerAngles.z > 359 && !flippedOnce)
                {
                    flips++;
                    flippedOnce = true;
                }
                if (player.transform.eulerAngles.z < 1 && flippedOnce)
                {
                    flippedOnce = false;
                }
                if (player.transform.eulerAngles.z > 355 || player.transform.eulerAngles.z < 5 && flips > 0)
                {
                    flipMeter.SetFillColour(Color.red);
                }
                else if (player.transform.eulerAngles.z < 355 || player.transform.eulerAngles.z > 5)
                {
                    flipMeter.SetFillColour(Color.green);
                }
            }

            // Rotate Backwards
            if (Input.GetKey(KeyCode.A) && jumped)
            {
                player.transform.Rotate(Vector3.back * 360 * Time.deltaTime);
                flipMeter.SetFlipProgress(player.transform.eulerAngles.z);
                if (player.transform.eulerAngles.z > 359 && !flippedOnce)
                {
                    flips++;
                    flippedOnce = true;
                }
                if (player.transform.eulerAngles.z < 1 && flippedOnce)
                {
                    flippedOnce = false;
                }
                if (player.transform.eulerAngles.z > 355 || player.transform.eulerAngles.z < 5 && flips > 0)
                {
                    flipMeter.SetFillColour(Color.red);
                }
                else if (player.transform.eulerAngles.z < 355 || player.transform.eulerAngles.z > 5 && flips > 0)
                {
                    flipMeter.SetFillColour(Color.green);
                }
            }
        }
        flipCounter.SetCounter(flips);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameState.hasStarted)
        {
            // Anti double jump
            if (jumped)
            {
                jumped = false;
            }

            // Boost mechanic
            if (player.transform.eulerAngles.z > 355 || player.transform.eulerAngles.z < 5)
            {
                rb.velocity = rb.velocity + new Vector3(flips * 5, 0, 0);
            }

            // Reset orientation and flips
            player.transform.eulerAngles = new Vector3(0, 0, 0);
            flips = 0;
            flipMeter.SetFlipProgress(0);
            flippedOnce = false;
            flipCounter.Disappear();
            flipMeter.Disappear();
        }
    }
}
