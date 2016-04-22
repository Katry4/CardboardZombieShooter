using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Player _player;
    private AliveComponent _playerHealth;
    [SerializeField]
    private Image _healthImage;

    [SerializeField]
    private Text time;
    [SerializeField]
    private Text kills;

    [SerializeField]
    private Text timeBestText;
    [SerializeField]
    private Text bestScoreText;

    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private GameObject head;

    private int score = 0, healthPoint;
    private float timer;
    private string timeString;
    int bestScore;
    float timeBest;
    #endregion

    void Start()
    {
        Time.timeScale = 0.00001f;
        _playerHealth = _player.GetComponent<AliveComponent>();
        AddKillPoint(score);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*Color color = _healthImage.color;
        color.a = 1 - _playerHealth.HealthInPercent();
        _healthImage.color = color;*/

        timer += Time.deltaTime;
        timeString = String.Format("{0:0}:{1:00}", Math.Floor(timer / 60), timer % 60);
        time.text = "" + timeString;
    }

    public void AddKillPoint(int newScore)
    {
        kills.text = "" + (score += newScore);
    }

    public void GameOver()
    {
        SaveScores();
        bestScore = PlayerPrefs.GetInt("BestScoreKill", 0);
        timeBest = PlayerPrefs.GetFloat("BestTime", 0);
        bestScoreText.text = bestScore.ToString();
        timeBestText.text = String.Format("{0:0}:{1:00}", Math.Floor(timeBest / 60), timeBest % 60);
        if (Cardboard.SDK.VRModeEnabled)
        {
            gameOverCanvas.transform.position = head.transform.position + head.transform.forward * 2f;
            gameOverCanvas.transform.rotation = head.transform.rotation;
            gameOverCanvas.gameObject.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    void SaveScores()
    {
        bestScore = PlayerPrefs.GetInt("BestScoreKill", 0);
        if (score >= bestScore)
            PlayerPrefs.SetInt("BestScoreKill", score);

        timeBest = PlayerPrefs.GetFloat("BestTime", 0);
        if (timer >= timeBest)
            PlayerPrefs.SetFloat("BestTime", timer);
        PlayerPrefs.Save();
    }

    #region Querries
    public Player Player
    {
        get { return _player; }
    }
    #endregion
}
