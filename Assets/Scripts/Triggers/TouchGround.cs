using UnityEngine;

public class TouchGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.CanJump(other.GetComponent<Zombie>());
    }
}