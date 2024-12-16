using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup : MonoBehaviour
{
    public int healthValue;
    private bool isMovingToPlayer;
    public float moveSpeed;

    private void Update()
    {
        if (player_movement_controller.Instance != null)
        {
            if (Vector3.Distance(transform.position, player_movement_controller.Instance.transform.position) > player_statecontroller.instance.pickupRange)
            {
                isMovingToPlayer = false;
            }
            if (isMovingToPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, player_movement_controller.Instance.transform.position, moveSpeed * Time.deltaTime);
            }
            else if (Vector3.Distance(transform.position, player_movement_controller.Instance.transform.position) <= player_statecontroller.instance.pickupRange)
            {
                isMovingToPlayer = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_statecontroller.instance.currentHealth += healthValue;
            Destroy(gameObject);
        }
    }
}
