using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesStart : MonoBehaviour
{
    ParticleSystem bubs;

    public GameObject Sub;

    private void Start()
    {
        bubs = GetComponentInChildren<ParticleSystem>();

        if(Sub.activeInHierarchy)
        {
            Sub.SetActive(false);
        }

        if(bubs.isPlaying)
        {
            bubs.Pause();
            bubs.Clear();
        }
    }

    private void Update()
    {
        if (Camera.main.transform.position.y < -8 && !bubs.isPlaying)
        {
            bubs.Play();
        }
        else if(Camera.main.transform.position.y >= -8 && bubs.isPlaying)
        {
            Sub.SetActive(false);

            bubs.Pause();
            bubs.Clear();
        }
    }
    
}
