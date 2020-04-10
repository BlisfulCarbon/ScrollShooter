using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Fire Variables")] public Transform firePoint;

    public float fireWait = 3f;
    private float fireWaitSeconds;
    public GameObject weapon;

    private void Start()
    {
        fireWaitSeconds = fireWait;
    }

    private void Update()
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