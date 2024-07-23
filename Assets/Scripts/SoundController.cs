using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void PlayThisSound(string clipname,float volumnMultiplier)
    {
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.volume *= volumnMultiplier;
        source.PlayOneShot((AudioClip)Resources.Load("Sounds/" + clipname,typeof(AudioClip)));
    }
}
