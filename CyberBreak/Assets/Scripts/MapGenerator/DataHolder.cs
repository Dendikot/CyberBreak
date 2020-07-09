using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    //Singletone refs---------------------------------------------------------------
    private static DataHolder _instance;
    public static DataHolder Instance { get { return _instance; } }
    //------------------------------------------------------------------------------

    public Vector2 m_mainValue = new Vector2(0f, 0f);

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


}
