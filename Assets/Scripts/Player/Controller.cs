using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    public float FloatingForce;

    public float SwimStrokeForce;

    public float Smoothing;

    public GameObject DiveBlocker;

    private Rigidbody rb;
    private bool Done;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Done = false;
    }

    private void Update()
    {
        if(Input.GetAxis("Vertical") <= 0 && !Done)
        {
            Stroke(Input.GetAxis("Vertical"));
        }

        if(Input.GetAxis("Horizontal") != 0 && !Done)
        {
            Swim(Input.GetAxis("Horizontal"));
        }
        if(Input.GetKeyDown(KeyCode.Space) && DiveBlocker.activeInHierarchy && !Done)
        {
            DiveBlocker.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -3 && !Done)
        {
            rb.AddForce(0, FloatingForce, 0, ForceMode.Impulse);
        }

        if (Done)
        {
            var desiredPos = new Vector3(0,-1.5f,-.6f);

            var smoothedPos = Vector3.Lerp(transform.position, desiredPos, Smoothing);

            transform.position = smoothedPos;

            if(transform.position.y >= DiveBlocker.GetComponentInParent<Transform>().transform.position.y)
            {
                Done = false;

                DiveBlocker.SetActive(true);
            }
        }
    }

    private void Stroke(float dir)
    {
        rb.AddForce(0, dir*SwimStrokeForce, 0, ForceMode.Impulse);
    }

    private void Swim(float dir)
    {
        rb.AddForce(dir*SwimStrokeForce, 0, 0, ForceMode.Impulse);
    }

    public void OnDiveOver()
    {
        Debug.Log("OnDiveOver");

        Done = true;
    }
}
