using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;

    [Header("Data")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float holdJumpGravity;
    private float normalGravity = 12f;
    private float actualGravity;

    private void Start()
    {
        actualGravity = normalGravity;
    }

    private void FixedUpdate()
    {
        //When holding jump action, the gravity is lower
        rb.AddForce(Vector3.down * rb.mass * actualGravity);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        actualGravity = holdJumpGravity;
    }

    public void StopJump()
    {
        actualGravity = normalGravity;
    }
}
