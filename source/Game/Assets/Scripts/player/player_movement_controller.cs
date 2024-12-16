using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class player_movement_controller : MonoBehaviour
{
    private float dashCooldownCounter = 1f;
    public static player_movement_controller Instance;
    public player_statecontroller player_state;
    bool isDashCooldown;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isDashCooldown = false;
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        dash(moveInput);

        transform.position += moveInput * player_state.speed * Time.deltaTime;
    }

    public void dash(Vector3 vector3)
    {
        Vector3 direct = vector3;
        dashCooldownCounter -= Time.deltaTime;
        if (dashCooldownCounter <= 0)
        {
            isDashCooldown = true;
        }
        if (isDashCooldown && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += direct * 4;
            isDashCooldown = false;
            dashCooldownCounter = player_state.dashCoolDown;
        }
    } 
}
