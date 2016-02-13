using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	[SerializeField] private int _damage = 3;
	public void OnTriggerStay(Collider other)
	{
		Debug.Log(other.name + " "+ other.gameObject.tag);
		if (other.tag == "Bullet")
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
		} else if (other. tag == "Player")
		{
			other.GetComponent<Player>().Hit(_damage);
		}
	}
}
