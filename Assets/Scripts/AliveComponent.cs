using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AliveComponent : MonoBehaviour
{

    #region Variables
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Canvas gameOverCanvas;
    private int _health;
    private int targetHealth;

    [SerializeField] private GameController gc;
    [SerializeField] private Text health;
    [SerializeField] private EnemySoundManager enemySounds;
    #endregion

    void Start()
    {
        targetHealth = _health = _maxHealth;
        Time.timeScale = 1f;
        gc = FindObjectOfType<GameController>();
    }

    public void RemHeath(int damage)
    {
        if (targetHealth <= 0)
        {
            Die();
        }
        else
        {
            targetHealth -= damage;
            health.text = "" + targetHealth;
        }
    }

    void Update()
    {
        if (targetHealth < _health)
        {
            _health--;
        }
    }

    private void Die()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("GAME OVER!");
            //SceneManager.LoadScene("GameScene");
            gc.GameOver();
            Time.timeScale = 0.000000001f;
        }
    }

    public float HealthInPercent()
    {
        return (float)_health / _maxHealth;
    }
}
