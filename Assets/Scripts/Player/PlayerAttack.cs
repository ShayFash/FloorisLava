using System;
public abstract class PlayerAttack
{
    public static bool ATTACK_LOCK = false;


    public static void lockAttacks()
    {
        ATTACK_LOCK = true;
    }

    public static void unlockAttacks()
    {
        ATTACK_LOCK = false;
    }

    public static bool canAttack()
    {
        return ATTACK_LOCK == false;
    }
}
