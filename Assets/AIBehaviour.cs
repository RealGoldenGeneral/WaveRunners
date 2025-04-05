using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public GameObject AIPlayer;
    Rigidbody body;
    bool jumped;
    int flips;
    bool flippedOnce;
    // Start is called before the first frame update
    void Start()
    {
        flips = 0;
        body = AIPlayer.GetComponent<Rigidbody>();
        jumped = false;
        flippedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        // AI moves constantly
        if (GameState.hasStarted)
        {
            if (body.velocity.x < 5)
            {
                body.AddForce(Vector3.right, ForceMode.Acceleration);
            }
        }

        if (AIPlayer.transform.position.y < -4)
        {
            AIPlayer.transform.position = new Vector3(AIPlayer.transform.position.x - 1, 0, AIPlayer.transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Waves");
        Vector3 rayPosition = new Vector3(AIPlayer.transform.position.x, -3.95f, AIPlayer.transform.position.z);

        if (GameState.hasStarted)
        {
            // AI jumps when it detects a wave
            if (Physics.Raycast(rayPosition, Vector3.right, out hit, mask))
            {
                if (hit.distance < 1 && !jumped)
                {
                    AIPlayer.transform.position = AIPlayer.transform.position + new Vector3(0, 0.05f, 0);
                    body.AddForce(Vector3.up * 600);
                    jumped = true;
                }
            }

            // AI flips when it is in the air
            if (Physics.Raycast(AIPlayer.transform.position, Vector3.down, out hit, mask))
            {
                if (hit.distance > 1.5f && jumped)
                {
                    AIPlayer.transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
                    if (AIPlayer.transform.eulerAngles.z > 359 && !flippedOnce)
                    {
                        flips++;
                        flippedOnce = false;
                    }
                    if (AIPlayer.transform.eulerAngles.z < 1 && flippedOnce)
                    {
                        flippedOnce = true;
                    }
                }

                // Rotation correction for AI
                else
                {
                    if (AIPlayer.transform.eulerAngles.z < 359 && hit.distance > 0 && jumped)
                    {
                        AIPlayer.transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameState.hasStarted)
        {
            // Anti-double jump
            if (jumped)
            {
                jumped = false;
            }

            // Boost mechanic on collision
            if (AIPlayer.transform.eulerAngles.z > 355 || AIPlayer.transform.eulerAngles.z < 5)
            {
                body.velocity = body.velocity + new Vector3(flips * 5, 0, 0);
            }

            // Reset rotation and boost
            AIPlayer.transform.eulerAngles = new Vector3(0, 0, 0);
            flips = 0;
            flippedOnce = false;
        }
    }
}
