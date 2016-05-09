using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AliveComponent : MonoBehaviour
{

    #region Variables
    public static bool isDead;

    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private Canvas gameOverCanvas;
    private int _health;
    private int targetHealth;

    [SerializeField]
    private GameController gc;
    [SerializeField]
    private Text health;
    #endregion

    void Start()
    {
        targetHealth = _health = _maxHealth;
        Time.timeScale = 1f;
        gc = FindObjectOfType<GameController>();
        isDead = false;
        gc.ResetVolume();
    }

    public void RemHeath(int damage)
    {
        if (_health <= 3)
        {
            Die();
            _health = 0;
            health.text = "" + _health;
        }
        else
        {
            _health -= damage;
            health.text = "" + _health;
        }
    }

    void Update()
    {
        if (_health <= 50 && _health > 25)
            gc.SetVolume1(1f);
        if (_health <= 25)
            gc.SetVolume2(1f);
    }

    private void Die()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            isDead = true;
            gc.GameOver();
            Gun.isPlaying = false;
            Time.timeScale = 0.000000001f;
        }
    }

    public float HealthInPercent()
    {
        return (float)_health / _maxHealth;
    }
}
