using UnityEngine;
using System.Collections;

public class EnemySoundManager : MonoBehaviour
{

    #region Variables
    public AudioSource[] audioSources;
    [SerializeField]
    private AudioClip Dead;

    /*public bool isWalking = false,
        isHiting = false, isDead = false, isSpawn = false;*/
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
        AudioSource.PlayClipAtPoint(Dead, gameObject.transform.position, 0.3f);
    }

    public void StopSounds()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            //audioSources[i].enabled = false;
            if (audioSources[i].isPlaying)
                audioSources[i].Stop();
        }
    }
}
