using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerPos;

    public float Smoothing = 0.125f;

    public Vector3 Offset;

    private void FixedUpdate()
    {
        var desiredPos = PlayerPos.position + Offset;

        desiredPos.x = 0;

        var smoothedPos = Vector3.Lerp(transform.position, desiredPos, Smoothing);

        transform.position = smoothedPos;

       // transform.LookAt(PlayerPos);
    }
}
