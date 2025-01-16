using TMPro;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    [SerializeField] private int nbZombieToEat;
    [SerializeField] private int nbZombieGain;

    [SerializeField] private TextMeshProUGUI actualZombieText;
    private int nbActualZombie;

    [SerializeField] private ParticleSystem smokeCloud;

    private void OnEnable()
    {
        UpdateText();
    }

    //For some reasons, cube in movement can't detect collision but can detect trigger
    private void OnTriggerEnter(Collider other)
    {
        nbActualZombie++;
        UpdateText();

        if (nbActualZombie >= nbZombieToEat)
        {
            ParticleSystem smokeCloudParticle = Instantiate(smokeCloud, transform.position, Quaternion.identity);
            smokeCloudParticle.Play();

            GameManager.Instance.AddZombies(nbZombieGain);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nbActualZombie--;
        UpdateText();
    }

    private void UpdateText()
    {
        actualZombieText.text = nbActualZombie.ToString() + "/" + nbZombieToEat.ToString();
    }
}