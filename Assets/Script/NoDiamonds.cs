using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDiamonds : MonoBehaviour
{
    public void Store()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
