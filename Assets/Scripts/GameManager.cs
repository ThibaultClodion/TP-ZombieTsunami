using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [Header("Map data")]
    public float mapSpeed = 30f;
    [SerializeField] private GameObject[] mapSections;
    [SerializeField] private GameObject[] mapElements;
    private float mapPositionOffset = 1.5f;

    [Header("Components")]
    [SerializeField] private PlayerController playerController;

    [Header("Game Data")]
    [SerializeField] private TextMeshProUGUI zombieText;
    private int zombieCount = 1;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI brainText;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);

        }
        if (!PlayerPrefs.HasKey("Brains"))
        {
            PlayerPrefs.SetInt("Brains", 0);
            
        }

        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
        brainText.text = PlayerPrefs.GetInt("Brains").ToString();
    }

    public void AddMoney()
    {
        //Update data
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    public void AddZombies(int amount)
    {
        //Update data
        PlayerPrefs.SetInt("Brains", PlayerPrefs.GetInt("Brains") + 1);
        brainText.text = PlayerPrefs.GetInt("Brains").ToString();

        zombieCount++;
        zombieText.text = "x " + zombieCount.ToString();
        playerController.InstantiateZombie();
    }

    public void RemoveZombie(Zombie zombie)
    {
        zombieCount--;
        zombieText.text = "x " + zombieCount.ToString();
        playerController.RemoveZombie(zombie);
    }

    public void CanJump(Zombie zombie)
    {
        playerController.CanJump(zombie);
    }

    public void CreateNextMapSection(Vector3 position)
    {
        //Get next map position
        MapSection mapSection = GetNextMapSection().GetComponent<MapSection>();
        Vector3 mapPostion = position + new Vector3(mapSection.GetSize() / 2 - mapPositionOffset, 0, 0);

        //Active the map section
        mapSection.transform.position = mapPostion;
        mapSection.gameObject.SetActive(true);
        mapSection.Enable(mapElements);
    }

    private GameObject GetNextMapSection()
    {
        GameObject nextMapSection = null;

        while (nextMapSection == null)
        {
            nextMapSection = mapSections[Random.Range(0, mapSections.Length)];

            //Be carefull of not choosing a mapSection that is already active
            if(nextMapSection.activeSelf)
            {
                nextMapSection = null;
            }
        }

        return nextMapSection;
    }
}
