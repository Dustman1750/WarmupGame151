using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DiveTimer : MonoBehaviour
{
    public UnityEvent OnDiveComplete;

    private Slider Bar;

    public float TimeAllowed;

    private float timeRemaining;

    private void Start()
    {
        Bar = GetComponentInChildren<Slider>();

        timeRemaining = TimeAllowed;

        StartCoroutine("DiveTime");
    }

    private void LateUpdate()
    {
        if(Bar.value <= 0)
        {
            OnDiveComplete?.Invoke();
        }
    }

    IEnumerator DiveTime()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();

            timeRemaining -= Time.deltaTime;

            Bar.value = timeRemaining / TimeAllowed;
        }
    }
}
