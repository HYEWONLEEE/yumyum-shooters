using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;
    private float minX = -50, maxX = 50f, minY = -50f, maxY = 50f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        minX = -50f;
        maxX = 50f;
        minY = -50f;
        maxY = 50f;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float targetX = Mathf.Clamp(player.position.x, minX + camWidth, maxX - camWidth);
        float targetY = Mathf.Clamp(player.position.y, minY + camHeight, maxY - camHeight);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
