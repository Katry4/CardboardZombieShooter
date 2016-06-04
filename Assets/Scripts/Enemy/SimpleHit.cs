using UnityEngine;
using System.Collections;

public class SimpleHit : MonoBehaviour {

    [SerializeField] private Enemy enemy;
	[SerializeField] private GameObject blood;

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
			Instantiate (blood, transform.position + (Vector3.forward / 5),	Quaternion.identity);
        }
        Destroy(other.gameObject);
    }
}
