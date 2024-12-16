using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_loop : MonoBehaviour
{
    public Transform mainCameraTransform;
    private float mapWidth = 100;
    private float mapHeight = 80;
    private float widthBlock = 3;
    private float heightBlock = 3;
    private float totalWidth;
    private float totalHeight;
    private Vector3 mapPosition;

    private void Start()
    {
        totalWidth = mapWidth * widthBlock;
        totalHeight = mapHeight * heightBlock;
    }

    private void Update()
    {
        mapPosition = transform.position;
        if (mainCameraTransform.position.x > transform.position.x + totalWidth / 2)
        {
            mapPosition.x += totalWidth;
            transform.position = mapPosition;
        }
        else if (mainCameraTransform.position.x < transform.position.x - totalWidth / 2)
        {
            mapPosition.x -= totalWidth;
            transform.position = mapPosition;
        }

        if (mainCameraTransform.position.y > transform.position.y + totalHeight / 2)
        {
            mapPosition.y += totalHeight;
            transform.position = mapPosition;
        }
        else if (mainCameraTransform.position.y < transform.position.y - totalWidth / 2)
        {
            mapPosition.y -= totalHeight;
            transform.position = mapPosition;
        }
    }

}
