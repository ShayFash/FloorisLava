
using UnityEngine;

public static class PlayerAccess
{
    private static GameObject player;
    public static GameObject getInstance()
    {
        if (player == null)
        {
            player=GameObject.FindGameObjectWithTag("Player");
        }

        return player;
    }

    public static PlayerStats getStats()
    {
        return getInstance().GetComponent<PlayerStats>();
    }
    
    public static PlayerMovement getMovement()
    {
        return getInstance().GetComponent<PlayerMovement>();
    }
}
