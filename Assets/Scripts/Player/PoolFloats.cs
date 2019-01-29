using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolFloats : MonoBehaviour
{
    public float FloatHeightMin;
    public float FloatHeightMax;
    public float FloatUpForce;
    public float FloatSideForce;

    private Rigidbody rb;
    private float rnddir;

    private void Start()
    {
        StartCoroutine("RandomDirFloat");

        rb = GetComponent<Rigidbody>();

        
    }


    private void FixedUpdate()
    {
        if (transform.position.y <= Random.Range(-FloatHeightMin,-FloatHeightMax))
        {
            rb.AddForce(rnddir*FloatSideForce, FloatUpForce, 0, ForceMode.Impulse);
        }

        this.transform.localEulerAngles = new Vector3( 0,0,Mathf.Clamp(this.transform.localEulerAngles.z, 75, 105));
    }

    IEnumerator RandomDirFloat()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.5f);

            rnddir = Random.Range(-.5f, .5f);
        }
    }
}
