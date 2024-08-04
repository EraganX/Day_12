using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject overPanel;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }



    public void GameRestart()
    {
        SceneManager.LoadScene("Gameplay");
        overPanel.SetActive(false);
    }

    public void GameOverPanelActive()
    {
        overPanel.SetActive(true);
    }
}
