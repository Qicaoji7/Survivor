using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class exp_pickup : MonoBehaviour
{
    public int expValueFromExpToGive;
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
            experience_level_controller.Instance.GetExp(expValueFromExpToGive);
            Destroy(gameObject);
        }
    }
}
