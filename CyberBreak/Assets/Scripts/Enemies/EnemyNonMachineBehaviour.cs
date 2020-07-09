using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNonMachineBehaviour : MonoBehaviour
{
    private bool Killed = false;
    // Start is called before the first frame update

    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }

    private void OnCollisionEnter(Collision collision)
    {

        //it somehow triggers three times when dies 
        //therefore the bool was introduced
        //fix this
        if (collision.gameObject.tag == "Projectile" && !Killed)
        {
            PlayerData.AmountOfEnemies--;
            Killed = true;
            Destroy(gameObject);
        }
    }
}
