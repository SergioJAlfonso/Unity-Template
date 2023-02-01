using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float velocity;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //rb.velocity = Input.GetAxis("Horizontal") * velocity;
        }

    }
}
