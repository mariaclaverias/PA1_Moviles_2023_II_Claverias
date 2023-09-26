using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectPool : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject objPref;
    public int maxQuantity;
    public float spawnTime;
    private float startTime;

    void Start()
    {
        InstantiateObject();
    }

    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= spawnTime)
        {
            GetObject();

            startTime = 0f;
        }
    }

    public void InstantiateObject()
    {
        GameObject tmp;
        for(int i = 0; i < maxQuantity; ++i)
        {
            tmp = Instantiate(objPref, transform.position, transform.rotation);
            tmp.GetComponent<Obstacle>().SetObjectPool(this);
            objectPool.Add(tmp);

            tmp.transform.SetParent(this.transform);
            objectPool[i].SetActive(false);
        }
    }

    public void GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<Obstacle>().InitVariables();
        }
        else
        {
            print("No hay más objectos en el pool");
        }
    }

    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
    }
}
