using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int X { get { return x; } set { x = value; } }
    public int Z { get { return z; } set { z = value; } }
    private int x, z;

    public GameObject CellGO { get { return m_cellGO; } set { m_cellGO = value; } }
    private GameObject m_cellGO;

    public void GenerateHeight(float lowBorder, float highBorder, float Width = 1)
    {
        transform.localScale =
                     new Vector3(Width, Random.Range(lowBorder, highBorder), Width);
    }
}