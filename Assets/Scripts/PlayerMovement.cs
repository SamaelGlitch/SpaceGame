using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Sensibilidad
    public float xySpeed = 18;

    void Start()
    {
        // Inicialización opcional
    }

    void Update()
    {   
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        LocalMove(h, v, xySpeed);
        ClampPosition();
    }

    private void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    private void ClampPosition()
    {
        float marginX = 0.05f;
        float marginY = 0.05f;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, marginX, 1 - marginX);
        pos.y = Mathf.Clamp(pos.y, marginY, 1 - marginY);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}