using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData 
{
    //public static Vector2 playerWeaponGraph;
    public static float xVal = 0;


    private static float closeShots = 0, farShots = 0;

    public static int AmountOfEnemies = 0;

    public static void CountShot(float Distance)
    {

        
        if (Distance > 200)
        {
            farShots++;
        }
        else
        {
            closeShots++;
        }

    }

    public static float CalculateBehaviour()
    {
        float totalShots = farShots + closeShots;

        xVal = (farShots / totalShots);

        return xVal;
    }
}
