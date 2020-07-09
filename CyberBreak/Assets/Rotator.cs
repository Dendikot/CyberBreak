using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;

    void Update()
    {
        transform.Rotate(Vector3.up * m_Speed * Time.deltaTime);
    }
}
