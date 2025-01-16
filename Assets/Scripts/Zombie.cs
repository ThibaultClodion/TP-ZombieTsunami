using System.Collections;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    [Header("Data")]
    [SerializeField] private float jumpForce;

    //Gravities
    [SerializeField] private float holdJumpGravity;
    [SerializeField] private float normalGravity;
    private float actualGravity;

    //Return to spawn position
    private Vector3 spawnPosition;
    private bool isMovingToSpawnPosition;

    private void Awake()
    { 
        spawnPosition = transform.position;
        actualGravity = normalGravity;
        animator.speed = 2 + GameManager.Instance.mapSpeed / 50;
    }

    private void FixedUpdate()
    {
        //Return to spawn position when moved
        if (spawnPosition.x -  transform.position.x > 0.1f)
        {
            isMovingToSpawnPosition = true;
            rb.linearVelocity = (spawnPosition - transform.position).normalized * GameManager.Instance.mapSpeed;
        }
        else if(isMovingToSpawnPosition)
        {
            isMovingToSpawnPosition = false;
            rb.linearVelocity = Vector3.zero;
        }

        //If the map accelerate, player drop fastest
        rb.AddForce(Vector3.down * actualGravity);
    }

    public void Jump(float timeBeforeJump)
    {
        StartCoroutine(JumpCoroutine(timeBeforeJump));
    }
    IEnumerator JumpCoroutine(float timeBeforeJump)
    {
        yield return new WaitForSeconds(timeBeforeJump);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        actualGravity = holdJumpGravity;
    }

    public void StopJump(float timeBeforeStopJump)
    {
        StartCoroutine(StopJumpCoroutine(timeBeforeStopJump));

    }
    IEnumerator StopJumpCoroutine(float timeBeforeStopJump)
    {
        yield return new WaitForSeconds(timeBeforeStopJump);
        actualGravity = normalGravity;
    }
}