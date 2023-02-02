using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public enum Direccion { up, down, left, right }

    [SerializeField]
    float velocity;

    private Rigidbody rb;
    private PlayerInput input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {

    }

    public void Move()
    {
        // normalise input direction
        input.actionEvents.GetEnumerator();
        Vector3 inputDirection = new Vector3(input.move.x, 0.0f, input.move.y).normalized;
    }
}
