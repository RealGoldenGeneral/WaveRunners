using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public GameObject AIPlayer;
    Rigidbody body;
    bool jumped;
    int flips;
    // Start is called before the first frame update
    void Start()
    {
        flips = 0;
        body = AIPlayer.GetComponent<Rigidbody>();
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x < 5)
        {
            body.AddForce(Vector3.right, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(AIPlayer.transform.position, Vector3.right, out hit))
        {
            if (hit.distance < 1 && !jumped)
            {
                AIPlayer.transform.position = AIPlayer.transform.position + new Vector3(0, 0.05f, 0);
                body.AddForce(Vector3.up * 400);
                jumped = true;
            }
        }

        if (Physics.Raycast(AIPlayer.transform.position, Vector3.down, out hit))
        {
            if (hit.distance > 1 && jumped)
            {
                AIPlayer.transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
                if (AIPlayer.transform.eulerAngles.z > 359)
                {
                    flips++;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (jumped)
        {
            jumped = false;
        }
        if (AIPlayer.transform.eulerAngles.y > 355 || AIPlayer.transform.eulerAngles.y < 5)
        {
            body.velocity = body.velocity + new Vector3(flips * 5, 0, 0);
        }
        flips = 0;
    }
}
