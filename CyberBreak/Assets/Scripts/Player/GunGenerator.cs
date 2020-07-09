using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_GunBase;

    //Simply make three arrays for three weapons
    //with ranges you can assign them step by step
    public Mesh[] m_RiflePieces;

    private void GenerateGun(Vector2 values, int segmentInt)
    {
        m_GunBase[segmentInt].GetComponent<MeshFilter>().mesh = m_RiflePieces[0];
    }
}