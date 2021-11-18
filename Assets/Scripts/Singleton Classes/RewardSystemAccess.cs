using UnityEngine;

public static class RewwardSystemAccess
{
    private static RewardSystem _rewardSystem;
    public static RewardSystem getInstance()
    {
        if (_rewardSystem == null)
            _rewardSystem = GameObject.FindGameObjectWithTag("RewardSytem").GetComponent<RewardSystem>();

        return _rewardSystem;
    }
}