using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public PlaneController planeController;
    public AudioSource sound;
    public static GameManager instance;
    public bool isGamePlaying;
    private float currentTimeScale;
    public GameObject losePanel;
    public GameObject inGamePanel;
    private int money;
    private int score;
    public TMP_Text scoreBar;
    public TMP_Text bestScoreBar;
    public TMP_Text moneyBar;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            money = 0;
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.Save();
        }
        instance = this;
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        ShowMoney();
        //sound.Play();
    }
    public void StartGame()
    {
        planeController.isCanFly = true;
        isGamePlaying = true;
        CameraController.instance.ChangeCamRotate();
        LevelSpawner.instance.SpawnLevelPart();
        LevelSpawner.instance.SpawnLevelPart();
        LevelSpawner.instance.SpawnLevelPart();

    }
    public void AddMoney()
    {
        money += 1;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
    }
    public void ShowMoney()
    {
        moneyBar.text = PlayerPrefs.GetInt("Money").ToString();
    }
    public void ShowScore()
    {
        scoreBar.text = score.ToString();
    }
    public void ShowBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (score>PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        PlayerPrefs.Save();
        bestScoreBar.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
        isGamePlaying = false;
    }
    public void ContinueGame()
    {
        Time.timeScale = currentTimeScale;
        isGamePlaying = true;
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void EndGame()
    {
        isGamePlaying = false;
        StartCoroutine(ShowLosePanel());
        inGamePanel.SetActive(false);
        ShowBestScore();
    }
    public void SoundOn()
    {
        sound.Play();
    }
    public void SoundOff()
    {
        sound.Stop();
    }
    public void FixedUpdate()
    {
        if (isGamePlaying)
        {
            Time.timeScale += 0.001f;
            currentTimeScale = Time.timeScale;
            ShowScore();
            score++;
        }
    }
    private IEnumerator ShowLosePanel()
    {
        yield return new WaitForSeconds(1f);
        losePanel.SetActive(true);
    }
}
