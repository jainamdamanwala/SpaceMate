using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete2 : MonoBehaviour
{
    public PlayerHealth player;
    public GameMenu levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void levelComplete()
    {
        SaveSystem.SavePlayer(player);
        levelManager.LevelCompleted();
    }
}
