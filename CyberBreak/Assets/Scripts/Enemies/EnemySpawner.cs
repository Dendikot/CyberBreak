using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Enemies = new GameObject[6];

    [SerializeField]
    private MapGen m_MapGen;

    [SerializeField]
    private LevelManager m_LevelManager;

    [Range(1, 4)]
    [SerializeField]
    private int m_NextLevelInd = 1;

    private Vector2[] m_MapEnemyValues;

    [SerializeField]
    private int m_EnemiesCount = 0;

    private int m_LowCount = 2;

    public SpawnManagerScriptableObject Sobj;
    private void Awake()
    {
        m_MapEnemyValues = new Vector2[m_EnemiesCount];
    }

    private void Start()
    {
        PlayerData.AmountOfEnemies = m_EnemiesCount;

        Spawn(Sobj.EnemyType, m_EnemiesCount);
    }

    private void Update()
    {
        if (PlayerData.AmountOfEnemies == 0) 
        {
            Debug.Log("killed all of them" + PlayerData.CalculateBehaviour());
            Sobj.xVal = PlayerData.CalculateBehaviour();

            m_LevelManager.LoadLevel("Level_" + m_NextLevelInd);
        }
    }

    public void Spawn(int enemyInd, int enemyAmount)
    {
        for (int nInd = 0; nInd < enemyAmount; nInd++)
        {
            int x = Random.Range(m_LowCount, m_MapGen.RoomMap.GetLength(0));
            int y = Random.Range(m_LowCount, m_MapGen.RoomMap.GetLength(1));

            for (int mIndTaken = 0; mIndTaken < m_MapEnemyValues.Length; mIndTaken++)
            {
                while (
                    m_MapEnemyValues[mIndTaken].x == x || 
                    m_MapEnemyValues[mIndTaken].y == y ) 
                {
                    x = Random.Range(m_LowCount, m_MapGen.RoomMap.GetLength(0));
                    y = Random.Range(m_LowCount, m_MapGen.RoomMap.GetLength(1));
                }
                
            }

            m_MapEnemyValues[nInd].x = x;
            m_MapEnemyValues[nInd].y = y;

            Vector3 position = new Vector3(x * m_MapGen.Buffer, 0, y * m_MapGen.Buffer);

            position.y = m_MapGen.HHigh + 5;

            Instantiate(m_Enemies[enemyInd], position, Quaternion.identity);
        }
    }
}
