using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    public float FloatingForce;

    public float SwimStrokeForce;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetAxis("Vertical") <= 0)
        {
            Stroke();
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            Swim(Input.GetAxis("Horizontal"));
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, FloatingForce, 0, ForceMode.Impulse);
    }

    private void Stroke()
    {
        rb.AddForce(0, SwimStrokeForce, 0, ForceMode.Impulse);
    }

    private void Swim(float dir)
    {
        rb.AddForce(dir*SwimStrokeForce, 0, 0, ForceMode.Impulse);
    }

    public void OnDiveOver()
    {

    }
}
