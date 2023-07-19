using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel01()
    {
        PlayerController.isGameOver = false;
        SceneManager.LoadScene("Level01");
    }

    public void LoadLevel02()
    {
        PlayerController.isGameOver = false;
        SceneManager.LoadScene("Level02");
    }

    public void LoadLevel03()
    {
        PlayerController.isGameOver = false;
        SceneManager.LoadScene("Level03");
    }
}
