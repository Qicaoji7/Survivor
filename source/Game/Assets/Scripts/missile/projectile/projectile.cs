using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
