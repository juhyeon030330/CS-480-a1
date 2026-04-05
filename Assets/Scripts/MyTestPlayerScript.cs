using UnityEngine;
using UnityEngine.InputSystem;

public class MyTestPlayerScript : MonoBehaviour
{
    public int totalJumpsAllowed = 2;
    private int jumpsRemaining;
    public float jumpHeight = 10;
    public float speed = 10;
    private Rigidbody rb;
    private float movementX;
    private float movementY;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = totalJumpsAllowed;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 v = movementValue.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && jumpsRemaining > 0)
        {
            jumpsRemaining--;
            float x = rb.linearVelocity.x;
            float z = rb.linearVelocity.z;
            rb.linearVelocity = new Vector3(x, jumpHeight, z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = totalJumpsAllowed;
        }
    }

    void FixedUpdate()
    {
        Vector3 v3 = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(speed * v3);
    }
}
