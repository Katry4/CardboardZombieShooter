using UnityEngine;
using System.Collections;

public class SimpleHitZombie2 : MonoBehaviour {

    [SerializeField] private Enemy enemy;

    // Use this for initialization
    void Start () {
        enemy = GetComponentInParent<Enemy>();   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && enemy.isAlive)
        {
            enemy.TakeDamage(3);
        }
        Destroy(other.gameObject);
    }
}
