using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : ApllicationLoader
{
    [SerializeField]
    protected Text m_TimeDisplay;

    [SerializeField]
    protected float m_LevelTime = 60;

    [SerializeField]
    private GameObject m_DeathScreen;

    [SerializeField]
    private GameObject m_MenuScreen;

    private bool pause = false;

    public SpawnManagerScriptableObject sp;

    private void OnApplicationQuit()
    {
        sp.xVal = 0;
    }

    private void Start()
    {
        GameSetBack();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            m_LevelTime -= Time.deltaTime;

            m_TimeDisplay.text = m_LevelTime.ToString();

            if (m_LevelTime <= 0)
            {
                DeathScreen();
            }
        }

        GamePause();
    }

    public void GameSetBack()
    {
        
        pause = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_MenuScreen.SetActive(false);
    }

    private void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            m_MenuScreen.SetActive(true);
            Time.timeScale = 0;
            pause = true;
        }
    }

    public void Win()
    {
        int sceneInd = SceneManager.GetActiveScene().buildIndex;

        string sceneName = "Level_" + sceneInd;

        LoadLevel(sceneName);
    }

    protected void DeathScreen()
    {
        m_DeathScreen.SetActive(true);
    }
}
