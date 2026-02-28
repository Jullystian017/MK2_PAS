using UnityEngine;

public class background : MonoBehaviour
{
    public float parallaxEffect = 0.3f;

    private float startPosX;
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
        startPosX = transform.position.x;
    }

    void Update()
    {
        float dist = cam.position.x * parallaxEffect;
        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);
    }
}
