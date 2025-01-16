using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Zombie zombiePrefab;
    [SerializeField] private InputActionAsset controls;
    [SerializeField] private LayerMask zombieLayerMask;
    private List<Zombie> zombies = new List<Zombie>();
    private bool canJump = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstantiateZombie();

        InputActionMap inputActions = controls.FindActionMap("Player");
        InputAction jump = inputActions.FindAction("Jump");

        jump.performed += ZombiesJump;
        jump.canceled += ZombiesStopJump;
    }

    private void OnDisable()
    {
        InputActionMap inputActions = controls.FindActionMap("Player");
        InputAction jump = inputActions.FindAction("Jump");

        jump.performed -= ZombiesJump;
        jump.canceled -= ZombiesStopJump;
    }

    public void RemoveZombie(Zombie zombie)
    {
        zombies.Remove(zombie);
        Destroy(zombie.gameObject);
    }

    public void InstantiateZombie()
    {
        Vector3 zombiePosition = GetRandomZombiePosition();
        int positionInList = 0;

        //Find zombie place in list (sorted by x positions)
        foreach (Zombie zombie in zombies)
        {
            if(zombie.transform.position.x < zombiePosition.x)
            {
                break;
            }
            else
            {
                positionInList++;
            }
        }

        //Insert the zombie at this place in list
        Zombie newZombie = Instantiate(zombiePrefab, zombiePosition, zombiePrefab.transform.rotation);
        zombies.Insert(positionInList, newZombie);
    }

    private Vector3 GetRandomZombiePosition()
    {
        Vector3 position = new Vector3(Random.Range(-10f, 0f), 1f, Random.Range(-3f, 3f));

        while(Physics.CheckSphere(position, 0.8f, zombieLayerMask))
        {
            position = new Vector3(Random.Range(-10f, 0f), 1f, Random.Range(-3f, 3f));
        }

        return position;
    }

    public void CanJump(Zombie zombie)
    {
        //If the zombie to fall is the first one that player can jump again
        if (zombies[0] == zombie)
        {
            canJump = true;
        }
    }

    private void ZombiesJump(InputAction.CallbackContext obj)
    {
        if (zombies.Count == 0) return;

        if (canJump)
        {
            canJump = false;
            float jumpPosition = zombies[0].transform.position.x;

            //Be sure that all zombie jump at same position
            foreach (Zombie zombie in zombies)
            {
                zombie.Jump((jumpPosition - zombie.transform.position.x) / GameManager.Instance.mapSpeed);
            }
        }
    }

    private void ZombiesStopJump(InputAction.CallbackContext obj)
    {
        if (zombies.Count == 0) return;

        float stopJumpPosition = zombies[0].transform.position.x;

        //Be sure that all zombie stop jump at same position
        foreach (Zombie zombie in zombies)
        {
            zombie.StopJump((stopJumpPosition - zombie.transform.position.x) / GameManager.Instance.mapSpeed);
        }
    }
}