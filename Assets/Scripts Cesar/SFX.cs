using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    private AudioSource jump;
    private AudioSource walk;

    void Start()
    {
        jump = GameObject.Find("Jump").GetComponent<AudioSource>();
        walk = GameObject.Find("Walk").GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        jump.Play();
    }
    public void PlayWalk()
    {
        walk.Play();
    }
    public void StopWalk()
    {
        walk.Stop();
    }
}
