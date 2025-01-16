using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.AddMoney();
        Destroy(gameObject);
    }
}