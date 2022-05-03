using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    private int counter;
    public void setCounter(int n) { counter = n; }

    public AudioClip fist;
    public AudioClip brassknuckles;
    public AudioClip sword;
    public AudioClip morningstar;
    public AudioClip axe;

    private AudioSource a;

    void Start()
    {
        a = GetComponent<AudioSource>();
        counter = 1;
    }

    public void play()
    {
        switch (counter)
        {
            case 1:
                a.PlayOneShot(fist, 1.0f);
                break;
            case 2:
                a.PlayOneShot(brassknuckles, 1.0f);
                break;
            case 3:
                a.PlayOneShot(sword, 1.0f);
                break;
            case 4:
                a.PlayOneShot(morningstar, 1.0f);
                break;
            case 5:
                a.PlayOneShot(axe, 1.0f);
                break;
            default:
                break;
        }

    }
}
