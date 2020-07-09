using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Speed { get { return speed; } set { speed = value; } }

    public GameObject BulletPrefab { get { return prefab; } set { prefab = value; } }

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float speed = 40;

    public bool Auto = false;
    private void Update()
    {
        if (Input.GetMouseButton(0) & Auto)
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot ()
    {
        GameObject proj = Instantiate(prefab);
        proj.transform.position = 
                             transform.position + Camera.main.transform.forward * 2;

        proj.transform.rotation = transform.rotation;

        proj.GetComponent<Projectile>().PlayerPos = transform.position;

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * speed;    
    }
}
