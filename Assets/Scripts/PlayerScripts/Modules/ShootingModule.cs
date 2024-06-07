using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModule : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform shootingPoint;


    public void Shoot()
    {
        //CREATE PROJECTILE
        Rigidbody bulletInstantiated = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        bulletInstantiated.AddForce(10f * camera.transform.forward, ForceMode.Impulse);
        Destroy(bulletInstantiated.gameObject, 5f);
    }
}
