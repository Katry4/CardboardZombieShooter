using UnityEngine;
using System.Collections;

public class EnemySoundManager : MonoBehaviour
{

    #region Variables
    public AudioSource[] audioSources;
    [SerializeField] private AudioClip Dead;
    public static float volume = 0.3f;
    #endregion

    // Use this for initialization
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AliveComponent.isDead == true)
        {
            StopSounds();
        }
    }

    public void isSpawn()
    {
        audioSources[0].Play();
    }

    public void isWalking()
    {
        audioSources[1].Play();
    }

    public void isHitting()
    {
        audioSources[2].Play();
    }

    public void isDead()
    {
        AudioSource.PlayClipAtPoint(Dead, gameObject.transform.position, volume);
    }

    public void StopSounds()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
                audioSources[i].Stop();
        }
    }
}
