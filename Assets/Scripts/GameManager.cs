using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [Header("Map data")]
    [SerializeField] private GameObject[] mapSections;
    private float mapPositionOffset = 0.8f;
    [HideInInspector] public float mapSpeed = 10f;

    [Header("Components")]
    [SerializeField] private PlayerController playerController;

    public void AddZombies(int amount)
    {
        playerController.InstantiateZombie();
    }

    public void RemoveZombie(Zombie zombie)
    {
        playerController.RemoveZombie(zombie);
    }

    public void CreateNextMapSection(Vector3 position)
    {
        //Get next map position
        MapSection mapSection = GetNextMapSection().GetComponent<MapSection>();
        Vector3 mapPostion = position + new Vector3(mapSection.GetSize() / 2 - mapPositionOffset, 0, 0);

        //Active the map section
        mapSection.transform.position = mapPostion;
        mapSection.gameObject.SetActive(true);
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
