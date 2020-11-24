using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int coins;
    public int diamonds;

    public PlayerData(PlayerHealth player)
    {
        coins = player.Coins;
        diamonds = player.Diamond;

/*        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;*/
    }
}
