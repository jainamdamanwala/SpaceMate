using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private PlayerHealth player;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    private GameManager gm;

    public Text levelCounterUI;
    private int levelCounter;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        levelCounter = gm.levelCounter;
        levelCounterUI.text = gm.levelCounter.ToString();
        SaveSystem.SavePlayer(player);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void MainMenuLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        SaveSystem.SavePlayer(player);
        Debug.Log("Exit");
        Application.Quit();
    }

    public void LevelCompleted()
    {
        gm.lastCheckPointPos = new Vector2(-53,24);
        SaveSystem.SavePlayer(player);
        levelCounter += 1;
        gm.levelCounter = levelCounter;
        Debug.Log("Level Counter = " + levelCounter);
        Debug.Log("gm Counter = " + gm.levelCounter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GameOverMenuUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
