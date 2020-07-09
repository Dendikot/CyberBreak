using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApllicationLoader : MonoBehaviour
{
    public void LoadLevel(string LevelName)
    {
        switch (LevelName)
        {
            case "Exit":
                Application.Quit();
                break;
            case "Menu":
                SceneManager.LoadScene("GameScene");
                break;
            case "Level_1":
                SceneManager.LoadScene("Level_1");
                break;
            case "Level_2":
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_3":
                SceneManager.LoadScene("Level_3");
                break;
            default:
                Debug.Log("Non existing case");
                break;
        }
    }
}
