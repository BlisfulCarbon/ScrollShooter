using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Fire Variables")]
    public Transform firePoint;
    public GameObject weapon;
    public float fireWait = 3f;
    private float fireWaitSeconds;
    
    void Start()
    {
        fireWaitSeconds = fireWait;
    }
    void Update()
    {
        fireWaitSeconds -= Time.deltaTime;
        if (fireWaitSeconds <= 0)
        {
            Fire();
            fireWaitSeconds = fireWait;
        }
    }

    public void Fire()
    {
        Instantiate(weapon, firePoint.position, Quaternion.identity);
    }
}
