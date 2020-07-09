using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDeath : MonoBehaviour
{
    public LevelManager lM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            lM.LoadLevel("Level_1");
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Seeker_3>().ResetAgent();
        }
    }
}
