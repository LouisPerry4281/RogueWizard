using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing;
    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 targetPos = Vector3.Lerp(transform.position, player.position + offset, smoothing);
            transform.position = targetPos;
        }
    }
}
