using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float PanSpeed;

    public int BackgroundSize;
    
    public bool Scrolling;

    public int topIndex;
    public int bottomIndex;

    public float viewZone;

    private Transform camTrans;

    public Transform[] backgrounds;

    private Vector3 bgVector;

    private void Start()
    {
        camTrans = Camera.main.transform;

        backgrounds = new Transform[transform.childCount];

        for (int i = 0; i< transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        topIndex = 0;

        bottomIndex = backgrounds.Length - 1;

        bgVector = new Vector3(-2.6f, 1, 0);

        Scrolling = false;
    }

    private void Update()
    {
        if(camTrans.position.y < backgrounds[bottomIndex].position.y - viewZone + 1.5f && Scrolling)
        {
            ScrollDown();
        }
        if (camTrans.position.y > backgrounds[topIndex].position.y + (viewZone + 1.5f) && camTrans.position.y < -4 && Scrolling)
        
        {
            ScrollUp(); 
        }

        if(camTrans.position.y <= -5)
        {
            Scrolling = true;
        }
        else
        {
            Scrolling = false;
        }
    }

    private void LateUpdate()
    {

    }


    private void ScrollUp()
    {
        var lastBottom = bottomIndex;

        var newVector = new Vector3(bgVector.x, bgVector.y * (backgrounds[topIndex].position.y + BackgroundSize), bgVector.z);

        backgrounds[bottomIndex].position = newVector;

        topIndex = bottomIndex;

        bottomIndex--;

        if(bottomIndex < 0)
        {
            bottomIndex = backgrounds.Length - 1;
        }
    }

    private void ScrollDown()
    {
        var lastTop = topIndex;

        var newVector = new Vector3(bgVector.x, bgVector.y * (backgrounds[topIndex].position.y - BackgroundSize), bgVector.z);

        backgrounds[topIndex].position = newVector;

        bottomIndex = topIndex;

        topIndex++;

        if(topIndex >= backgrounds.Length)
        {
            topIndex = 0;
        }
    }
}
