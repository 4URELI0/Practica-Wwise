using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Transform head;
    private Rigidbody rb;
    private Vector3 direction;

    public float playerSpeed = 5.0f;
    public float playerAcceleration = 2.0f;
    public float jumpForce = 6.0f;

    public LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal") * head.right + Input.GetAxisRaw("Vertical") * head.forward;
        rb.velocity = Vector3.Lerp(rb.velocity, direction.normalized * playerAcceleration + rb.velocity.y * Vector3.up, playerAcceleration * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && IsTouchingDown())
        {
            rb.velocity += jumpForce * Vector3.up;
            Debug.Log("Saltando!");
        }
    }
    private bool IsTouchingDown()
    {
        return Physics.CheckBox(transform.position, new Vector3(0.1f, 0.1f, 0.1f), Quaternion.identity, groundLayer);
    }
}