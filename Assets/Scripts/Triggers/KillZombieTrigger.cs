using UnityEngine;

public class KillZombieTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.RemoveZombie(other.GetComponent<Zombie>());
    }
}
