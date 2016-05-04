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
        gc.ResetVolume();
    }

    public void RemHeath(int damage)
    {
        if (_health <= 0)
        {
            Die();
            targetHealth = 0;
            health.text = "" + targetHealth;
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
        if (_health <= 50 && _health > 25)
        {
            gc.SetOSTVolume(-10f);
            gc.SetSFXSoundVolume(-10f);
        }
        else if (_health <= 25)
        {
            gc.SetOSTVolume(-20f);
            gc.SetSFXSoundVolume(-20f);
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
            isDead = true;
            gc.GameOver();
            Time.timeScale = 0.000000001f;
        }
    }

    public float HealthInPercent()
    {
        return (float)_health / _maxHealth;
    }
}
