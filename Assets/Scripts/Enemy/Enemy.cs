using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField] Player player;
    [SerializeField] private float deathTime;
    [SerializeField] private int _damage = 3, score;
    [SerializeField] private float _recharge = 2f;
    [SerializeField] private GameController gc;
    private float timeSinceLastHit = 100;
    [SerializeField] public float healthPoint;
    [SerializeField] private EnemySoundManager enemySounds;
    [SerializeField] private EnemyMove enemyMove;
    private float angle;
    public float amplitude = 0.1f;
    public float duration = 0.5f;
    public bool isAlive = true;
    public bool isMove;
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
        isMove = true;
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

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0)
        {
            isAlive = false;
            enemySounds.isDead();
            gc.AddKillPoint(score);
            enemyMove.enabled = false;
            GetComponent<Animator>().SetBool("Dead", true);
            StartCoroutine(Death());
        }
        else
        {
            GetComponent<Animator>().SetTrigger("isHitting");
        }
    }

    IEnumerator Death()
    {
        enemySounds.audioSources[1].Stop();
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
            CameraShake.Instance.Shake(amplitude, duration);
            player.Hit(_damage, gameObject);
            enemySounds.isHitting();
            timeSinceLastHit = 0;
        }
    }

    internal void StopMove()
    {
        isMove = false;
    }

    internal void PlayMove()
    {
        isMove = true;
    }

    internal void isMoving()
    {
        enemySounds.audioSources[1].Play();
    }
}
