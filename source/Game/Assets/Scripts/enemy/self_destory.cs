using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destory : MonoBehaviour
{
    public bool isNeedDestory;
    public bool isOutMap;


    void Update()
    {
        //δ��ɣ��ж��Ƿ������̫Զ����ʧ
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
