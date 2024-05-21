using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShootBehaviour shoot;
    [SerializeField] private JumpBehaviour jump;

    private void Update()
    {
        CheckJumpInput();
        CheckShootInput();

        
    }

    private void CheckShootInput()
    {
        if (shoot)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                shoot.ShootWeapon();
            }
        }
    }

    private void CheckJumpInput()
    {
        if (jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump.JumpPlayer();
            }
        }
    }
}
