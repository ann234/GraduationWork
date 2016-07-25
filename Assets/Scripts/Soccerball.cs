﻿using UnityEngine;
using System.Collections;

public class Soccerball : MchObject {

    public AudioSource bounceSnd;
    public float initVolume;

    // Use this for initialization
    public override void Start () {
        base.Start();
        bounceSnd = GetComponent<AudioSource>();
        initVolume = bounceSnd.volume;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
    }

    public void OnCollisionEnter(Collision cols)
    {
        float force = rb.velocity.magnitude;
        if (force > 0.5)
        {
            float volume = force * 0.1f;
            bounceSnd.volume = volume;
            bounceSnd.Play();
        }
    }
}
