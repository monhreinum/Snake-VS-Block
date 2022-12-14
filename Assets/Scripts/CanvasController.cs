using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public bool IsGameActive { get; private set; }

    [SerializeField]
    private GameObject GameMainScreen;
    [SerializeField]
    private GameObject LoseScreen;
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private Button startGameButton;
    [SerializeField]
    private Button restartGameButton;
    [SerializeField]
    private Button nextGameButton;
    [SerializeField]
    private Text levelCounter;
    [SerializeField]
    private Text completedLevelCounter;

    private SceneController sceneController;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGame);
        restartGameButton.onClick.AddListener(RestartGame);
        nextGameButton.onClick.AddListener(NextGame);

        sceneController = FindObjectOfType(typeof(SceneController)) as SceneController;
        levelCounter.text = $"Level : {SceneManager.GetActiveScene().buildIndex + 1}";
        completedLevelCounter.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1} Completed!";
    }

    public void LoseGame()
    {
        Progress.SnakeLength = -1;
        IsGameActive = false;
        LoseScreen.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        IsGameActive = false;
        WinScreen.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        IsGameActive = true;
        GameMainScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Progress.SnakeLength = -1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextGame()
    {
        sceneController.LoadNextScene();
    }
}
