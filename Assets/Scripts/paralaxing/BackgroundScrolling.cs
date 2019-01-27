using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float PanSpeed;

    public int BackgroundSize;
    
    public bool Scrolling , Parallax;

    public int topIndex;
    public int bottomIndex;

    public float viewZone;

    public float lastCamY;

    private Transform camTrans;

    public Transform[] backgrounds;

    private Vector3 bgVector;

    private void Start()
    {        
        camTrans = Camera.main.transform;

        lastCamY = camTrans.position.y;

        backgrounds = new Transform[transform.childCount];

        for (int i = 0; i< transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        topIndex = 0;

        bottomIndex = backgrounds.Length - 1;

        bgVector = new Vector3(0, 1, .5f);

        Scrolling = false;
        Parallax = false;
    }

    private void Update()
    {
        if (Scrolling)
        {
            if (camTrans.position.y < backgrounds[bottomIndex].position.y + viewZone)
            {
                ScrollDown();
            }
            if (camTrans.position.y > backgrounds[topIndex].position.y - viewZone)

            {
                ScrollUp();
            }
        }

        if(camTrans.position.y <= -18)
        {
            Scrolling = true;
            Parallax = true;
        }
        else
        {
            Scrolling = false;
            Parallax = false;
        }
    }

    private void LateUpdate()
    {
        if (Parallax)
        {
            var deltaY = camTrans.position.y - lastCamY;

            transform.position += Vector3.up * (deltaY * PanSpeed);
        }

        lastCamY = camTrans.position.y;
    }


    private void ScrollUp()
    {
        var lastBottom = bottomIndex;

        var newVector = new Vector3(bgVector.x,(backgrounds[topIndex].position.y + BackgroundSize), bgVector.z);

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

        var newVector = new Vector3(bgVector.x,(backgrounds[bottomIndex].position.y - BackgroundSize), bgVector.z);

        backgrounds[topIndex].position = newVector;

        bottomIndex = topIndex;

        topIndex++;

        if(topIndex >= backgrounds.Length)
        {
            topIndex = 0;
        }
    }
}
