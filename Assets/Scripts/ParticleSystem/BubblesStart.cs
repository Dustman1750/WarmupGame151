using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesStart : MonoBehaviour
{
    ParticleSystem bubs;

    private void Start()
    {
        bubs = GetComponentInChildren<ParticleSystem>();

        if(bubs.isPlaying)
        {
            bubs.Pause();
        }
    }

    private void Update()
    {
        if (transform.position.y <= -11)
        {
            bubs.Play();
        }
        else
        {

            bubs.Pause();
        }
    }
}
