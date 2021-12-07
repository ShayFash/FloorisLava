using UnityEngine;

public static class LavaAccess
{
    private static Lava lava;
    public static Lava getInstance()
    {
        if (lava == null)
            lava = GameObject.FindGameObjectWithTag("Lava").GetComponent<Lava>();

        return lava;
    }
}