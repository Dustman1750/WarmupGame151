using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DiveTimer : MonoBehaviour
{
    public UnityEvent OnDiveComplete;

    private Slider Bar;

    public bool Diving;
    public bool Running;
    public bool AtTop;

    public float TimeAllowed;

    private float timeRemaining;

    private void Start()
    {
        Bar = GetComponentInChildren<Slider>();

        Running = false;

        Diving = false;
        if(Maneger.Instance.GD.DiveTime <= 0 )
        {
            TimeAllowed = 5;
        }
        else
        {
            TimeAllowed = Maneger.Instance.GD.DiveTime;
        }
        
        timeRemaining = TimeAllowed;
    }

    private void LateUpdate()
    {
        if(Camera.main.transform.position.y <= -7 && !Diving && !Running && AtTop)
        {
            StartCoroutine("DiveTime");

            Diving = true;

            AtTop = false;
        }
       
        if(Bar.value <= 0 && Diving && Running)
        {
            OnDiveComplete?.Invoke();

            StopCoroutine("DiveTime");

            Running = false;

            Diving = false;

            Bar.value = 1;

            TimeAllowed = Maneger.Instance.GD.DiveTime;

            timeRemaining = TimeAllowed;
        }

        if(Camera.main.transform.position.y >= -4)
        {
            AtTop = true;
        }
    }

    IEnumerator DiveTime()
    {
        Debug.Log("Started");

        Running = true;

        while (true)
        {
            yield return new WaitForEndOfFrame();

             timeRemaining -= Time.deltaTime;

            Bar.value = timeRemaining / TimeAllowed;
        }
    }
}
