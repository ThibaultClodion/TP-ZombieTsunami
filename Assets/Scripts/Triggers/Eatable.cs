using UnityEngine;

public class Eatable : MonoBehaviour
{
    [SerializeField] private int nbZombieToEat;
    [SerializeField] private int nbZombieGain;
    private int nbActualZombie;

    //For some reasons, cube in movement can't detect collision but can detect trigger
    private void OnTriggerEnter(Collider other)
    {
        nbActualZombie++;

        if (nbActualZombie > nbZombieToEat)
        {
            GameManager.Instance.AddZombies(nbZombieGain);
            Destroy(gameObject);
        }
    }
}
