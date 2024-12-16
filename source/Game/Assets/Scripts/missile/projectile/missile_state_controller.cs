using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missile_state_controller : MonoBehaviour
{
    public int penetratingCounter = 0;
    public int penetratingPower;
    public float lifeTime;
    public bool destoryOnContact;
    public string targetTag;
    public static missile_state_controller Instance;

    private void Start()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            penetratingCounter++;
            if (destoryOnContact && penetratingCounter >= penetratingPower)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }

    }
}
