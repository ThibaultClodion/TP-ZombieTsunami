using UnityEngine;

public class MapSection : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider boxCollider;

    [Header("Interests points")]
    [SerializeField] private Transform[] interestPoints;

    private void OnEnable()
    {
        rb.linearVelocity = -transform.right * GameManager.Instance.mapSpeed;
    }

    public void Enable(GameObject[] mapElements)
    {
        foreach (Transform interestPoint in interestPoints)
        {
            GameObject mapElement = Instantiate(mapElements[Random.Range(0, mapElements.Length)], transform);
            mapElement.transform.position = interestPoint.position;
        }
    }

    public float GetSize()
    {
        return boxCollider.size.x;
    }
}