using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_range_normal_states_controller : MonoBehaviour
{
    public float attack;
    public float currentHealth;
    public float maxHealth;
    public float speed;
    public float extraSpeed;
    public float extraAttack;
    public float oriAttack;
    public float oriSpeed;
    public int expToGive;
    public bool canBeRepel;
    public static enemy_range_normal_states_controller Instance;
    public Transform enemyTransform;
    private Vector3 healthVec = new Vector3(1, 1, 1);

    [Header("hurt_flash")]
    public SpriteRenderer sp;
    public float flashTime;
    private float flashCounter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        oriAttack = attack;
        oriSpeed = speed;
    }

    private void Update()
    {
        attack = oriAttack + extraAttack;
        speed = oriSpeed + extraSpeed;

        if(flashCounter <= 0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
        }
        else
        {
            flashCounter -= Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(damage >= 15) {
            HurtShader();
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            exp_spawn_controller.Instance.SpawnExp(transform.position, expToGive);
            health_spawn_controller.Instance.SpawnHealth(transform.position - healthVec);
        }
    }

    public void TakeRepel(float repelAmount, Vector3 attackPosition)
    {
        if (canBeRepel)
        {
            Vector3 direct = (enemyTransform.position - attackPosition).normalized;
            enemyTransform.position += direct * repelAmount;
        }
    }

    private void HurtShader() 
    {
        sp.material.SetFloat("_FlashAmount", 1);
        flashCounter = flashTime;
    }
}

