using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_state_controller : MonoBehaviour
{
    public float lifeTime;
    public string targetTag;
    public static explosion_state_controller Instance;
    public float weaponRange;
    public CircleCollider2D circleCollider;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        circleCollider.radius = weaponRange;
    }

    //���±�ը��Χ��������ʱ�䵽�˺���ʧ
    private void Update()
    {
        circleCollider.radius = weaponRange;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }

    }
}
