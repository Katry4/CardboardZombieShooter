using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Player player;
    [SerializeField]
    private float deathTime;
    [SerializeField]
    private int _damage = 3, score;
    [SerializeField]
    private float _recharge = 2f;
    [SerializeField]
    private GameController gc;
    private float timeSinceLastHit = 100;
    [SerializeField]
    private float healthPoint;
    [SerializeField]
    private EnemySoundManager enemySounds;
    [SerializeField]
    private EnemyMove enemyMove;
    private float angle;
    #endregion

    void Awake()
    {
        player = FindObjectOfType<GameController>().Player;
        gc = FindObjectOfType<GameController>();
        enemySounds = GetComponent<EnemySoundManager>();
        enemyMove = GetComponent<EnemyMove>();
    }

    void Start()
    {
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
        if (other.tag == "Bullet")
        {
            TakeDamage(3);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if (healthPoint < 0)
        {
            enemySounds.isDead();
            gc.AddKillPoint(score);
            GetComponent<Animator>().SetBool("Dead", true);
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        GetComponent<Collider>().enabled = false;
        enemySounds.audioSources[1].Stop();
        enemyMove._speed = 0f;
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

    internal void IsHit()
    {
        GetComponent<Animator>().SetTrigger("Hit");
    }

    internal void HitPlayer()
    {
        if (timeSinceLastHit > _recharge)
        {
            player.Hit(_damage, gameObject.transform);
            enemySounds.isHitting();
            timeSinceLastHit = 0;
        }
    }
}
