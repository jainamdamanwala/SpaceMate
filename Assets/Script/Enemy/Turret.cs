using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 3f);
    }
}
