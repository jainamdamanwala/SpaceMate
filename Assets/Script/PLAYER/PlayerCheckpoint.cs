using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpoint : MonoBehaviour
{
    private PlayerHealth player;
    private GameManager gm;

    public GameMenu gameOver;
    public GameOver buyLifes;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.playerLifes != 0)
        {
            if (player.PlayerDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if(gm.playerLifes <= 0)
        {
            gameOver.GameOverMenuUI();
        }
        if (buyLifes.boughtLifes)
        {
            gm.playerLifes = buyLifes.LifeCounter;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(gm.playerLifes);
        }

    }
}
