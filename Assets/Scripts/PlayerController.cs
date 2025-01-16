using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Zombie zombiePrefab;
    [SerializeField] private InputActionAsset controls;
    private List<Zombie> zombies = new List<Zombie>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Zombie zombie = Instantiate(zombiePrefab, transform);
        zombies.Add(zombie);

        InputActionMap inputActions = controls.FindActionMap("Player");
        InputAction jump = inputActions.FindAction("Jump");

        jump.performed += ZombiesJump;
        jump.canceled += ZombiesStopJump;
    }

    private void ZombiesJump(InputAction.CallbackContext obj)
    {
        foreach (Zombie zombie in zombies)
        {
            zombie.Jump();
        }
    }
    private void ZombiesStopJump(InputAction.CallbackContext obj)
    {
        foreach (Zombie zombie in zombies)
        {
            zombie.StopJump();
        }
    }
}
