using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_effect : MonoBehaviour
{
    public Transform closeBackground;
    public Transform middleBackground;
    public Transform farBackground;
    public Vector3 originClosePosition;
    public Vector3 originMiddlePosition;
    public Vector3 originFarPosition;

    private void Start()
    {
        originClosePosition = closeBackground.position;
        originMiddlePosition = middleBackground.position;
        originFarPosition = farBackground.position;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x = Input.mousePosition.x - 960;
        mousePos.y = Input.mousePosition.y - 540;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        closeBackground.position = originClosePosition - worldPos / 100;
        middleBackground.position = originMiddlePosition - worldPos / 400;
        farBackground.position = originFarPosition + worldPos / 200;

    }
}
