using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string WeaponName => weaponName;

    [SerializeField] private string weaponName;
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;

    public float GetFireRate() => fireRate;

    public float GetDamage() => damage;

    public float GetBulletSpeed() => bulletSpeed;


}
