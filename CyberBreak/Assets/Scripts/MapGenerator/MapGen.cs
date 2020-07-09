using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public Room[,] RoomMap { get { return m_RoomMap; } }
    private Room[,] m_RoomMap;

    public int Size {set { m_Size = value; } }

    [SerializeField]
    private int m_Size = 10;

    public float Buffer { get { return m_Buffer; } set { m_Buffer = value; } }
    [SerializeField]
    private float m_Buffer = 1;
    
    public float Chance { set { m_Chance = value; } }
    [SerializeField]
    private float m_Chance = 0.5f;

    public GameObject Prefab { set { m_Prefab = value; } }
    [SerializeField]
    private GameObject m_Prefab;

    public float LHigh { set { m_LHigh = value; } }
    public float HHigh { get { return m_HHigh; } set { m_HHigh = value; } }

    /// <summary>
    /// Lower high and top high for the object scales
    /// </summary>
    [SerializeField]
    private float m_LHigh, m_HHigh = 1;

    private void Awake()
    {
        m_RoomMap = new Room[m_Size, m_Size];
    }

    private void Start()
    {
        FillMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_Chance = 1;
            m_HHigh = 45;
            m_LHigh = 45;
            FillMap();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            m_Chance = 0.8f;
            m_HHigh = 35;
            m_LHigh = 55;
            FillMap();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            m_Chance = 0.5f;
            m_HHigh = 25;
            m_LHigh = 75;
            FillMap();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            m_Chance = 0.3f;
            m_HHigh = 25;
            m_LHigh = 95;
            FillMap();
        }
    }

    private void CleanMap()
    {
        for (int nIndex = 0; nIndex < m_RoomMap.GetLength(0); nIndex++)
        {
            for (int nIndex2 = 0; nIndex2 < m_RoomMap.GetLength(1); nIndex2++)
            {
                if (m_RoomMap[nIndex, nIndex2] != null)
                {
                    Destroy(m_RoomMap[nIndex, nIndex2].CellGO);
                }
            }
        }
    }    

    public void FillMap()
    {
        CleanMap();

        for (int nIndex = 0; nIndex < m_RoomMap.GetLength(0); nIndex++)
        {
            for (int nIndex2 = 0; nIndex2 < m_RoomMap.GetLength(1); nIndex2++)
            {
                bool Pass = PassFail(m_Chance);
                if (Pass)
                {
                    m_RoomMap[nIndex, nIndex2] = InstantiateCube(nIndex, nIndex2);
                }
                else
                {
                    continue;
                }
            }
        }

        MakePath();
    }

    private void MakePath()
    {
        int x = 0;
        int z = 0;

        //probably because of or
        while (true)
        {
            if (x == m_RoomMap.GetLength(0)|| z == m_RoomMap.GetLength(1))
            {
                break;
            }

            if (!m_RoomMap[x,  z])
            {
                m_RoomMap[x, z] = InstantiateCube(x, z);
            }

            if (PassFail(0.5f))
            {
                x++;
            }
            else
            {
                z++;
            }
        }
    }

    private Room InstantiateCube(int x, int z)
    {
        GameObject g = Instantiate(m_Prefab, transform);
        Room room = g.GetComponent<Room>();

        g.transform.position = new Vector3(x * m_Buffer, 0 ,z * m_Buffer);
        room.CellGO = g;

        room.X = x;
        room.Z = z;

        room.GenerateHeight(m_LHigh, m_HHigh, m_Buffer);

        return room;
    }

    private bool PassFail(float chanceOfSuccess)
    {
        if (GameManager.JumpFactor < 0.3f)
        {
            chanceOfSuccess -= GameManager.JumpFactor;
        }
        else
        {
            chanceOfSuccess = 0.2f;
        }

        return Random.value < chanceOfSuccess;
    }
}