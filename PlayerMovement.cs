using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 4;
    Rigidbody rb;
    CapsuleCollider col;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        if(isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}