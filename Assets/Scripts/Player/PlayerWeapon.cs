using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform weaponPos;

    private Weapon currentWeapon;

    
    private void Start()
    {
        CreateWeaon(initialWeapon);
    }

    private void CreateWeaon(Weapon weaponPrefab)
    {
        Instantiate(weaponPrefab, weaponPos.position,
            Quaternion.identity, weaponPos);
    }
}
