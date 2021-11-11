using System;
using UnityEngine;

public class Attack
{
    public float SecondsPerAttack { get; set; }
    public float AttackHitTime { get; set; }


    public float Power { get; set; }

    public PlayerActionType Type { get; set; }


    public String Animation { get; set; }


    public Attack(float secondsPerAttack, float attackHitTime, float power,String animation,PlayerActionType type)
    {
        SecondsPerAttack = secondsPerAttack;
        AttackHitTime = attackHitTime;
        Animation = animation;
        Power = power;
        Type = type;
    }
}

