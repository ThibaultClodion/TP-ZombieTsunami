using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Moving obstacle settings")]
    [SerializeField] private bool isOnMovement;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        if(isOnMovement && transform.position.x < 20f)
        {
            rb.linearVelocity = Vector3.left * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.RemoveZombie(other.GetComponent<Zombie>());
        Destroy(gameObject);
    }
}
