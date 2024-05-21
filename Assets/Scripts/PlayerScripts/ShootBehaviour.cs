using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float bulletVelocity;
    private void ShootWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody projectileClone = Instantiate(projectile, weaponTip.position, weaponTip.rotation);
            projectileClone.AddForce(playerCam.transform.forward * bulletVelocity, ForceMode.Impulse);
            Destroy(projectileClone.gameObject, 3f);
        }
    }
}
