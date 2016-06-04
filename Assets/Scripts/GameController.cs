using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameController : MonoBehaviour
{
	#region Variables

	[SerializeField] private Player _player;
	private AliveComponent _playerHealth;
	[SerializeField] private Image _healthImage;

	[SerializeField] private Text time;
	[SerializeField] private Text kills;

	[SerializeField] private Text timeBestText;
	[SerializeField] private Text bestScoreText;

	[SerializeField] private Canvas gameOverCanvas;
	[SerializeField] private GameObject head;
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private AudioMixerSnapshot[] snapshots;

	[SerializeField] private GameObject killsObject;
	[SerializeField] private GameObject timeObject;

	[SerializeField] private Text gameOverTime;
	[SerializeField] private Text gameOverKills;
	[SerializeField] private EnemyMove zombie1;
	[SerializeField] private EnemyMove zombie2;
	[SerializeField] private GameObject floorCanvas;
	[SerializeField] private GameObject downArrow;

	private int score = 0, healthPoint;
	private float timer;
	private string timeString;
	int bestScore;
	float timeBest;

	public int ammoCount = 10;
	public bool isShootActive = true;
	[SerializeField] private Text ammoText;

	#endregion

	void Start ()
	{
		zombie1._speed = 1f;
		zombie2._speed = 0.8f;
		Time.timeScale = 0.00001f;
		_playerHealth = _player.GetComponent<AliveComponent> ();
		AddKillPoint (score);
		timer = 0f;
        
	}

	// Update is called once per frame
	void Update ()
	{
		/*Color color = _healthImage.color;
        color.a = 1 - _playerHealth.HealthInPercent();
        _healthImage.color = color;*/

		timer += Time.deltaTime;
		timeString = String.Format ("{0:0}:{1:00}", Math.Floor (timer / 60), timer % 60);
		time.text = "" + timeString;

		if (timer > 30 && timer < 60) {
			zombie1._speed = 1.6f;
			zombie2._speed = 1.2f;
		}
		if (timer > 60) {
			zombie1._speed = 1.8f;
			zombie2._speed = 1.4f;
		}

		//Reload
		if (ammoCount == 0) {
			isShootActive = false;
			floorCanvas.SetActive (true);
			downArrow.SetActive (true);
		}
	}

	public void Realod ()
	{
		StartCoroutine (ReloadAmmo ());
		UnityEngine.Debug.Log ("Realod");
	}

	IEnumerator ReloadAmmo()
	{
		yield return new WaitForSeconds (1f);
		ammoCount = 10;
		ammoText.text = ammoCount.ToString ();
		isShootActive = true;
		floorCanvas.SetActive (false);
		downArrow.SetActive (false);
	}

	public void DegreaseAmmo ()
	{
		if (isShootActive) {
			ammoCount--;
			ammoText.text = ammoCount.ToString ();
		}
	}

	public void AddKillPoint (int newScore)
	{
		kills.text = "" + (score += newScore);
	}

	public void GameOver ()
	{
		ResetVolume ();
		SaveScores ();
		bestScore = PlayerPrefs.GetInt ("BestScoreKill", 0);
		timeBest = PlayerPrefs.GetFloat ("BestTime", 0);
		bestScoreText.text = "Best: " + bestScore.ToString ();
		timeBestText.text = "Best: " + String.Format ("{0:0}:{1:00}", Math.Floor (timeBest / 60), timeBest % 60);

		gameOverKills.text = "Your: " + score;
		gameOverTime.text = "Your: " + timeString;
		if (Cardboard.SDK.VRModeEnabled) {
			killsObject.SetActive (false);
			timeObject.SetActive (false);
			gameOverCanvas.transform.position = head.transform.position + head.transform.forward * 0.55f;
			gameOverCanvas.transform.rotation = head.transform.rotation;
			gameOverCanvas.gameObject.SetActive (true);
		}
	}

	public void Replay ()
	{
		SceneManager.LoadScene (1);
	}

	void SaveScores ()
	{
		bestScore = PlayerPrefs.GetInt ("BestScoreKill", 0);
		if (score >= bestScore)
			PlayerPrefs.SetInt ("BestScoreKill", score);

		timeBest = PlayerPrefs.GetFloat ("BestTime", 0);
		if (timer >= timeBest)
			PlayerPrefs.SetFloat ("BestTime", timer);
		PlayerPrefs.Save ();
	}

	#region Querries

	public Player Player {
		get { return _player; }
	}

	#endregion

	public IEnumerator SetVolume (float volume, float setVolume)
	{
		while (volume >= setVolume) {
			volume -= Time.deltaTime * 10f;
			audioMixer.SetFloat ("sfxVol", volume);
			audioMixer.SetFloat ("ostVol", volume);
			yield return null;
		}
	}

	public void SetVolume1 (float time)
	{
		snapshots [0].TransitionTo (time);
		EnemySoundManager.volume = 0.15f;
	}

	public void SetVolume2 (float time)
	{
		snapshots [1].TransitionTo (time);
		EnemySoundManager.volume = 0.07f;
	}

	public void ResetVolume ()
	{
		snapshots [2].TransitionTo (0.001f);
	}
}
