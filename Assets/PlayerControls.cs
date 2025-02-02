using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && rb.velocity.x < 15)
        {
            rb.AddForce(Vector3.right, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S) && rb.velocity.x > 0)
        {
            rb.AddForce(Vector3.left, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.Space) && player.transform.position.y < -4.19f)
        {
            rb.AddForce(Vector3.up * 75);
        }
    }
}
