
using UnityEngine;

public static class RewardSystemAccess
{
    private static RewardSystem rewardSystem;
    public static RewardSystem getInstance()
    {
        if (rewardSystem == null)
        {
            rewardSystem=GameObject.FindGameObjectWithTag("RewardSystem").GetComponent<RewardSystem>();
        }

        return rewardSystem;
    }

  
}
