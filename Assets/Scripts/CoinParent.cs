using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParent : MonoBehaviour
{
    private DynamicObjectPool objectPool;

    public float speed;
    private Vector3 startPos;
    private bool isOut = false, isTrigger = false;

    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;

        if (transform.position.x < -12f && isOut == false || isTrigger)
        {
            HideObject(objectPool);
        }
    }

    public void SetObjectPool(DynamicObjectPool objectPool)
    {
        startPos = transform.position;
        this.objectPool = objectPool;
    }

    public void InitVariables()
    {
        transform.position = startPos;
        isOut = false;
        isTrigger = false;
    }

    private void HideObject(DynamicObjectPool objectPool)
    {
        objectPool.SetObject(gameObject);
        gameObject.SetActive(false);
        isOut = true;
        isTrigger = false;
    }
}
