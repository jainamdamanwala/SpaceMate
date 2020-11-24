using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                Destroy(gameObject);
        }
    }
}
