using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {

	[SerializeField] private Player _player;
	[SerializeField] private int _damage;
    public float amplitude = 0.1f;
    public float duration = 0.5f;

    // Use this for initialization
    void Awake()
	{
		_player = FindObjectOfType<GameController>().Player;
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyHand") {
            CameraShake.Instance.Shake(amplitude, duration);
            _player.Hit (_damage, other.gameObject);
			Destroy (other.gameObject);
		}
	}
}
