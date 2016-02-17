using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	[SerializeField] private AliveComponent _playerHealth;
	[SerializeField] private Image _healthImage;

	// Update is called once per frame
	void Update()
	{
		Color color = _healthImage.color;
		color.a = 1 - _playerHealth.HealthInPercent();
		_healthImage.color = color;
	}
}
