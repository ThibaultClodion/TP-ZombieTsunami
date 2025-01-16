using UnityEngine;

public class DisableMapSection : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MapSection")
        {
            other.gameObject.SetActive(false);
        }
        //Destroy previous map elements like vehicules or powerups to make spawns new ones
        else if(other.tag == "MapElement")
        {
            Destroy(other.gameObject);
        }
    }
}