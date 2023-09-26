using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPool : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject objPref;
    public float spawnTime;
    private float startTime = 0;

    private void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= spawnTime)
        {
            GetObject();

            startTime = 0f;
        }
    }

    private Vector3 RandomPosition()
    {
        float rnd = Random.Range(-4f, 4f);
        Vector3 currentPos = transform.position;
        currentPos.y = rnd;
        return currentPos;
    }

    public void GetObject()
    {
        GameObject tmp;
        if (objectPool.Count > 0)
        {
            tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<CoinParent>().InitVariables();
        }
        else
        {
            tmp = Instantiate(objPref, transform.position, transform.rotation);
            tmp.GetComponent<CoinParent>().SetObjectPool(this);
            tmp.GetComponent<CoinParent>().InitVariables();
            objectPool.Add(tmp);

            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
        }
    }

    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
    }
}
