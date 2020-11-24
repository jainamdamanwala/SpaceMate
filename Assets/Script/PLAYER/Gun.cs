using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float bullet_damage = 10f;
    //public Animator AimAnim;
    public Joystick joystick;
    public int MaxAmmo = 20;
    public int currentAmmo = 20;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public float speedBoost;
    public float jumpBoost;

    private AmmoCrate ammoValue;
    private CharacterButtonController fastrun;

    AudioManager shoot;

    public Text currentAmmoText;
    public Text MaxAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        fastrun = GetComponent<CharacterButtonController>();
        shoot = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        ammoValue = GameObject.FindGameObjectWithTag("AmmoCrate").GetComponent<AmmoCrate>();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (joystick.Vertical < 0.5f && joystick.Vertical > 0)
        {
            AimAnim.Play("StraightAim");
        }
        if (joystick.Vertical >0.5f && joystick.Vertical < 0.9f)
        {
            AimAnim.Play("HalfAim");
        }        
        if(joystick.Vertical >0.9f)
        {
            AimAnim.Play("UpAim");
        }
        if (joystick.Vertical > -0.5f && joystick.Vertical < 0f)
        {
            AimAnim.Play("StraightAim");
        }
        if (joystick.Vertical < -0.5f && joystick.Vertical > -0.9f)
        {
            AimAnim.Play("DownHalf");
        }        
        if(joystick.Vertical < -0.9f)
        {
            AimAnim.Play("DownAim");
        }*/

        currentAmmoText.text = currentAmmo.ToString();
        MaxAmmoText.text = MaxAmmo.ToString();

        if (joystick.Horizontal > 0.7f && Time.time >= nextTimeToFire || joystick.Horizontal < -0.7f && Time.time >= nextTimeToFire || joystick.Vertical > 0.7f && Time.time >= nextTimeToFire || joystick.Vertical <-0.7f && Time.time >= nextTimeToFire)
        {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
        }
/*        if (Input.GetKeyDown("r"))
        {
            Invoke("Reload", reloadTime);
            isReloading = true;
        }*/
    }
    void Shoot()
    {
        if (currentAmmo != 0 && isReloading == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shoot.Play("Shoot");
            Destroy(bullet, 3f);
            currentAmmo -= 1;
        }
        if (currentAmmo == 0)
        {
            Invoke("Reload", reloadTime);
            isReloading = true;
        }
    }

    void Reload()
    {
        if(MaxAmmo > 20 && isReloading)
        {
            currentAmmo = currentAmmo + 20;
            MaxAmmo = MaxAmmo - 20;
            isReloading = false;
        }
        if(MaxAmmo <= 20 && isReloading)
        {
            currentAmmo = currentAmmo + MaxAmmo;
            MaxAmmo = 0;
            isReloading = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("FastShoot"))
        {
            fireRate = fireRate * 2;
            reloadTime = reloadTime / 2;
        }        
        if (collide.gameObject.CompareTag("AmmoCrate"))
        {
            MaxAmmo = MaxAmmo + ammoValue.ammoValue;
        }
        if (collide.gameObject.CompareTag("FastRun"))
        {
            fastrun.moveSpeed += speedBoost;
            fastrun.jumpForce += jumpBoost;
        }
    }
}
