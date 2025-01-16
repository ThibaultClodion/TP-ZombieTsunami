using UnityEngine;

public class MapSection : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider boxCollider;

    private void OnEnable()
    {
        rb.linearVelocity = -transform.right * GameManager.Instance.mapSpeed;
    }

    public float GetSize()
    {
        return boxCollider.size.x;
    }
}