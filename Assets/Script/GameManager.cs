using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerHealth player;
    private static GameManager instance;
    public Vector2 lastCheckPointPos;
    public int playerLifes;

    public int levelCounter;

    public int diamond;
    public int coins;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Debug.Log("LevelDestroyed");
            Destroy(gameObject);
        }
    }
    /*    public void levelCompleted()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.visible = true;
        }*/
}
