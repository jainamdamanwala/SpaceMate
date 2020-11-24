using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private PLAYERMOVEMENT player;
    private GameManager gm;
    public Text Lifes;
    public Text Diamonds;
    public Text Coin;

    public Image healthBar1, healthBar2, healthBar3;
    public int playercurrentLifes = 3;
    public int playerHealth = 3;
    public bool PlayerDead = false;
    public int Coins = 0;
    public int Diamond = 0;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        player = GetComponent<PLAYERMOVEMENT>();
        playercurrentLifes = gm.playerLifes;

        Diamond = gm.diamond;
        Coins = gm.coins;
    }
    private void Update()
    {
        gm.diamond = Diamond;
        gm.coins = Coins;
        Lifes.text = playercurrentLifes.ToString();
        Diamonds.text = gm.diamond.ToString();
        Coin.text = gm.coins.ToString();


        if (playerHealth == 3)
        {
            healthBar1.enabled = true;
            healthBar2.enabled = true;
            healthBar3.enabled = true;
        }
        if (playerHealth == 2)
        {
            healthBar1.enabled = false;
            healthBar2.enabled = true;
            healthBar3.enabled = true;
        }
        if (playerHealth == 1)
        {
            healthBar1.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = true;
        }
        if (playerHealth == 0)
        {
            healthBar1.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = false;
/*            playercurrentLifes = playercurrentLifes - 1;

            gm.playerLifes = playercurrentLifes;
            PlayerDead = true;*/
        }
        SaveSystem.SavePlayer(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playercurrentLifes = playercurrentLifes - 1;

            gm.playerLifes = playercurrentLifes;
            PlayerDead = true;
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (playerHealth > 0)
            {
                playerHealth = playerHealth - 1;
            }
            if(playerHealth <= 0)
            {
                playercurrentLifes = playercurrentLifes - 1;

                gm.playerLifes = playercurrentLifes;
                PlayerDead = true;
            }
        }     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            if (playerHealth < 3)
            {
                playerHealth++;
            }
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coins++;
        }        
        if (collision.gameObject.CompareTag("Diamond"))
        {
            Diamond += 1;
        }     
    }


    /*    public void savePlayer()
        {
            SaveSystem.SavePlayer(this);
        }

        public void loadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            Coins = data.coins;
            Diamond = data.diamonds;
        public void loadData()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            coinsCounter = data.coins;
            diamondsCounter = data.diamonds;
            gm.diamond = diamondsCounter;
            gm.coins = coinsCounter;
        }
        }*/
}
