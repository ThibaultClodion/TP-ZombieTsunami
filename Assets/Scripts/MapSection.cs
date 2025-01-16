using UnityEngine;

public class MapSection : MonoBehaviour
{
    [System.Serializable]
    public class InterestPoint
    {
        [SerializeField] private Transform position;
        [SerializeField] private GameObject[] possibleObjectArray;
    }

    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider boxCollider;

    [Header("Interests points")]
    [SerializeField] private InterestPoint[] interestPoints;

    private void OnEnable()
    {
        rb.linearVelocity = -transform.right * GameManager.Instance.mapSpeed;
    }

    public float GetSize()
    {
        return boxCollider.size.x;
    }
}