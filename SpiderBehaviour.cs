using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    public Notificator notificator;
    public AudioClip spiderSound;
    public AudioClip eggSound;
    private AudioSource audioSourceSpider;
    private AudioSource audioSourceEgg;

    void Start()
    {
        notificator.OnSpiderCollision += OnSpiderCollision;
        notificator.OnEggCollision += OnEggCollision;
        audioSourceSpider = gameObject.AddComponent<AudioSource>();
        audioSourceSpider.clip = spiderSound;
        audioSourceEgg = gameObject.AddComponent<AudioSource>();
        audioSourceEgg.clip = eggSound;
    }

    void OnSpiderCollision()
    {
        audioSourceSpider.Play();
    }

    void OnEggCollision()
    {
        audioSourceEgg.Play();
    }

    void OnDestroy()
    {
        notificator.OnSpiderCollision -= OnSpiderCollision;
        notificator.OnEggCollision -= OnEggCollision;
    }
}
