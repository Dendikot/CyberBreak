using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public Vector3 PlayerPos;

    private void Start()
    {
        Destroy(gameObject, 12);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //so if it hits the player it calcualtes the distance between the palyer and the enemy 
        //at the moment of when the shot was taken
        //Then it passes this distance to the player data and it proceeds with calcualtion
        //At the end of the level all shots taken get summarised and % gets applied
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerData.CountShot(Vector3.Distance(collision.transform.position, PlayerPos));

            Destroy(gameObject, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 1);
    }
}
