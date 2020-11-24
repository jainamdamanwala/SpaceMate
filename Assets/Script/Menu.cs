using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject StoreMenu;
/*    public GameObject CoinsMenu;
    public GameObject DiamondMenu;
    public GameObject LifesMenu;*/
    public GameObject Cross;

    public PlayerHealth player;

    public Text diamondCounterUI;
    public Text coinCounterUI;

    private GameManager gm;

    public int diamondsCounter;
    public int coinsCounter;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        MainMenu.SetActive(true);
        StoreMenu.SetActive(false);
        gm.lastCheckPointPos = new Vector2(-50f,45f);
        gm.playerLifes = 3;
        /*        diamondsCounter = gm.diamond;
                coinsCounter = gm.coins;*/
        loadData();
    }

    private void Update()
    {
        //diamondsCounter = gm.diamond + diamondsCounter;
        //coinsCounter = gm.diamond + coinsCounter;
        diamondCounterUI.text = " X " + diamondsCounter.ToString();        
        coinCounterUI.text =  " X " + coinsCounter.ToString();
        StartCoroutine(startSaving());
    }

    public void savePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void loadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        coinsCounter = data.coins;
        diamondsCounter = data.diamonds;
        gm.diamond = diamondsCounter;
        gm.coins = coinsCounter;
    }

    public void store()
    {
        MainMenu.SetActive(false);
        StoreMenu.SetActive(true);
    }       
    public void CrossButton()
    {
        gm.diamond = diamondsCounter;
        MainMenu.SetActive(true);
        StoreMenu.SetActive(false);
    }

    IEnumerator startSaving()
    {
        yield return new WaitForSeconds(1f);
        SaveSystem.SavePlayer(player);
    }
/*    public void Coin()
    {
        DiamondMenu.SetActive(false);
        CoinsMenu.SetActive(true);
        LifesMenu.SetActive(false);
    }    
    public void Diamonds()
    {
        DiamondMenu.SetActive(true);
        CoinsMenu.SetActive(false);
        LifesMenu.SetActive(false);
    }    
    public void Lifes()
    {
        DiamondMenu.SetActive(false);
        CoinsMenu.SetActive(false);
        LifesMenu.SetActive(true);
    }*/

}
