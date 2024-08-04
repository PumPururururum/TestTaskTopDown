using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public BoxCollider2D cameraBound;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private float halfCamHeight;
    private float halfCamWidth;
    // Start is called before the first frame update
    void Start()
    {
        minBounds = cameraBound.bounds.min;
        maxBounds = cameraBound.bounds.max;
        halfCamHeight = Camera.main.orthographicSize;
        halfCamWidth = halfCamHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfCamWidth, maxBounds.x - halfCamWidth);
        float clampedY = Mathf.Clamp(transform.position.y , minBounds.y + halfCamHeight, maxBounds.y - halfCamHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
