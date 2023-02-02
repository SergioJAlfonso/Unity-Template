using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float velocity;

    [SerializeField]
    float jumpVelocity;

    private Rigidbody rb;
    private PlayerController playerActions;

    bool jump = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerActions = new PlayerController();
    }

    void FixedUpdate()
    {
        //Movement WASD
        Vector2 moveVal = playerActions.Player.Move.ReadValue<Vector2>();
        Vector3 inputDirection = new Vector3(moveVal.x, 0, moveVal.y).normalized * velocity;

        rb.velocity = inputDirection;

        //Jump
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode.Impulse);
            jump = false;
        }

    }

    private void Update()
    {
        if (playerActions.Player.Jump.triggered)
            jump = true;
    }

    private void OnEnable()
    {
        playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerActions.Player.Disable();
    }
}
