using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireworkSound : MonoBehaviour {
    //public AudioClip fireSound;
    private AudioSource source;
    public ParticleSystem Firework;

    public AudioClip OnBirthSound;
    public AudioClip OnDeathSound;

 public int numParticles = 0;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Firework.isEmitting == true)
        //{
        //    fire.PlayOneShot(fireSound);
        //}

       
        if (!OnBirthSound && !OnDeathSound) { return; }
        int count = Firework.particleCount;
        if (count < numParticles) { source.PlayOneShot(OnDeathSound); }
        else if (count > numParticles) { source.PlayOneShot(OnBirthSound); }

        numParticles = count;
    }
        
    }
