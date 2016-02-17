using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	[SerializeField] private Player _player;
	private AliveComponent _playerHealth;
	[SerializeField] private Image _healthImage;

	void Start()
	{
		_playerHealth = _player.GetComponent<AliveComponent>();
	}

	// Update is called once per frame
	void Update()
	{
		Color color = _healthImage.color;
		color.a = 1 - _playerHealth.HealthInPercent();
		_healthImage.color = color;
	}

	#region Querries
	public Player Player
	{
		get { return _player; }
	}
	#endregion
}
