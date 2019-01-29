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
    public bool running;

    public float TimeAllowed;

    private float timeRemaining;

    private void Start()
    {
        Bar = GetComponentInChildren<Slider>();

        running = false;

        Diving = false;

        timeRemaining = TimeAllowed;
    }

    private void LateUpdate()
    {
        if(Camera.main.transform.position.y <= -5 && !Diving && !running)
        {
            StartCoroutine("DiveTime");

            Diving = true;
        }
        if(Bar.value <= 0 && Diving && running)
        {
            OnDiveComplete?.Invoke();

            StopCoroutine("DiveTime");

            running = false;

            Diving = false;

            Bar.value = 1;

            TimeAllowed = Maneger.Instance.GD.DiveTime;

            timeRemaining = TimeAllowed;
        }
    }

    IEnumerator DiveTime()
    {
        Debug.Log("Started");

        TimeAllowed = Maneger.Instance.GD.DiveTime;

        running = true;

        while (true)
        {
            yield return new WaitForEndOfFrame();

            timeRemaining -= Time.deltaTime;

            Bar.value = timeRemaining / TimeAllowed;
        }
    }
}
