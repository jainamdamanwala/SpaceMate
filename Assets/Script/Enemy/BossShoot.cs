using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint1;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
/*        GameObject bullet1 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);        
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);*/
        //Destroy(bullet, 3f);
/*        Destroy(bullet1, 3f);        
        Destroy(bullet2, 3f);
        Destroy(bullet3, 3f);*/
    }
}
