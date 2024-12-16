using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_repel_controller : MonoBehaviour
{
    public float repelAmount;
    private Vector3 position;
    public static enemy_repel_controller Instance;

    private void Start()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        position = transform.position;
        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<enemy_range_normal_states_controller>().TakeRepel(repelAmount, position);
        }
    }
}
