using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelCompleteUI.SetActive(true);
        }
    }
}
