using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DeapthGauge : MonoBehaviour
{
    private Text Depth;
    public Text Max;

    private float StartPos;

    private float CurrentPos;
    private int curDepth;

    private void Start()
    {
        Depth = GetComponent<Text>();

        StartPos = Camera.main.transform.position.y;

        CurrentPos = StartPos;

        Max.text = "Record: " + Maneger.Instance.GD.MaxDepth;

        StartCoroutine("Counter");
    }

    private void FixedUpdate()
    {
        curDepth = Mathf.Abs(Mathf.RoundToInt(CurrentPos - StartPos));
        Depth.text = "Depth: " + curDepth;
    }

    IEnumerator Counter()
    {
        while(true)
        {
            yield return new WaitForSeconds(.5f);

            CurrentPos = Camera.main.transform.position.y;
        }
    }

    public void OnDiveComplete()
    {
        if (Maneger.Instance.GD.MaxDepth <= curDepth)
        {
            Maneger.Instance.GD.MaxDepth = curDepth;

            Max.text = "Record: " + Maneger.Instance.GD.MaxDepth;
        }
    }


}
