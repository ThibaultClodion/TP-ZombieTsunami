using UnityEngine;

public class MapSection : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;

    private void Update()
    {
        transform.position -= transform.right * GameManager.Instance.mapSpeed * Time.deltaTime;
    }

    public float GetSize()
    {
        return boxCollider.size.x;
    }
}
