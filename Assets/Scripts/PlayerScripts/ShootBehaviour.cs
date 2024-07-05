using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private List<WeaponData> inventory = new List<WeaponData>();
    [SerializeField] private WeaponData equippedWeapon;
    [SerializeField] private ObjectPool bulletsPool;

    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float bulletVelocity;

    private void Start()
    {
        
    }
    public void ShootWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PooledObject pooledObj = bulletsPool.RetrievePoolObject();
            Rigidbody projectileClone = pooledObj.GetRigidbody();
            projectileClone.position = weaponTip.position;
            projectileClone.rotation = weaponTip.rotation;
            projectileClone.AddForce(playerCam.transform.forward * equippedWeapon.GetFireRate(), ForceMode.Impulse);
            pooledObj.ResetPooledObject(4f);
        }
    }
}
