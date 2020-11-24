using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Gun damage;
    public GameObject EnemyDeathEffect;
    public GameObject DeathEffectPoint;
    public float enemyMaxHealth = 100f;
    public float enemyCurrentHealth = 100f;

    public GameObject levelCompleteUI;
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (enemyCurrentHealth > 0)
            {
                TakeDamage();
            }
            else if (enemyCurrentHealth <= 0)
            {
                levelCompleteUI.SetActive(true);
                GameObject deathEffect = Instantiate(EnemyDeathEffect, DeathEffectPoint.transform.position, DeathEffectPoint.transform.rotation);
                Destroy(gameObject);
                Destroy(deathEffect,1f);
            }
        }
    }
    void TakeDamage()
    {
        enemyCurrentHealth = enemyCurrentHealth - damage.bullet_damage; 
    }
}
