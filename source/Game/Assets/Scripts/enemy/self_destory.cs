using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destory : MonoBehaviour
{
    public bool isNeedDestory;
    public bool isOutMap;


    void Update()
    {
        //未完成，判断是否离玩家太远而消失
        if (isOutMap)
        {
            isNeedDestory = true;
        }

        if (isNeedDestory)
        {
            Destroy(gameObject);
        }
    }
}
