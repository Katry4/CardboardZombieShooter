using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField] Player player;
    [SerializeField] private int _damage = 3, score;
    [SerializeField] private float _recharge = 2f;
    [SerializeField] private GameController gc;
    private float timeSinceLastHit = 100;
    [SerializeField] private float healthPoint;
    [SerializeField] private EnemySoundManager enemySounds;
    #endregion

    void Awake()
    {
        player = FindObjectOfType<GameController>().Player;
        gc = FindObjectOfType<GameController>();
        enemySounds = GetComponent<EnemySoundManager>();
    }

    void Start()
    {
        //enemySounds.isSpawn = true;
        enemySounds.isSpawn();
    }

    internal void Go()
    {
        GetComponent<EnemyMove>().SetTarget(player.transform);
        enemySounds.isWalking();
    }

    void Update()
    {
        timeSinceLastHit += Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " " + other.gameObject.tag);
        if (other.tag == "Bullet")
        {
            TakeDamage(3);
            Destroy(other.gameObject);
        }

        //TakeDamage(damage);

        /*else if (other.tag == "Player")
        {
            //other.GetComponent<Player>().Hit(_damage);
        }*/
    }

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0)
        {
            enemySounds.isDead();
            gc.AddKillPoint(score);
            /*enemySounds.isSpawn = false;
            enemySounds.isWalking = false;
            enemySounds.isHiting = false;
            enemySounds.isDead = true;*/
            Destroy(gameObject);
        }
    }

    internal void HitPlayer()
    {
        if (timeSinceLastHit > _recharge)
        {
            player.Hit(_damage);
            enemySounds.isHitting();
            timeSinceLastHit = 0;
        }
    }
}
