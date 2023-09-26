using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    private StaticObjectPool objectPool;
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

    public void SetObjectPool(StaticObjectPool objectPool)
    {
        startPos = transform.position;
        this.objectPool = objectPool;
    }

    public void InitVariables()
    {
        transform.position = startPos;
        isOut = false;
    }

    private void HideObject(StaticObjectPool objectPool)
    {
        objectPool.SetObject(gameObject);
        gameObject.SetActive(false);
        isOut = true;
    }

}
