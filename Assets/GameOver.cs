using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public PlayerHealth player;
    public Text lifeCounterUI;
    public Text PriceUI;
    public bool boughtLifes = false;
    public int LifeCounter = 1;
    int price = 10;

    public IAPManager inApp;
    public GameObject gameOverUI;
    public GameObject noDiamondsUI;
    // Start is called before the first frame update
    void Start()
    {
        LifeCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounterUI.text = LifeCounter.ToString();
        PriceUI.text = (price * LifeCounter).ToString();
        //SaveSystem.SavePlayer(player);
    }
    public void AddLife()
    {
        LifeCounter += 1;
    }
    public void SubtractLife()
    {
        LifeCounter -= 1;
    }
    public void BuyLife()
    {
        if (player.Diamond >= (price * LifeCounter))
        {
            player.Diamond = player.Diamond - (price * LifeCounter);
            boughtLifes = true;
            gameOverUI.SetActive(false);
        }
        else if (player.Diamond < (price * LifeCounter))
        {
            gameOverUI.SetActive(false);
            noDiamondsUI.SetActive(true);
        }
    }
}
