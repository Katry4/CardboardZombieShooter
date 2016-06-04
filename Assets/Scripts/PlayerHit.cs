using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {

	[SerializeField] private Player _player;
	[SerializeField] private int _damage;

	// Use this for initialization
	void Awake()
	{
		_player = FindObjectOfType<GameController>().Player;
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyHand") {
			_player.Hit (_damage, other.gameObject);
			Destroy (other.gameObject);
		}
	}
}
