using UnityEngine;

public class EnableMapSection : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MapSection")
        {
            GameManager.Instance.CreateNextMapSection(transform.position);
        }
    }
}