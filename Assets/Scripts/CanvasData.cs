using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasData : MonoBehaviour
{
    [SerializeField] private int distance = 0;
    [SerializeField] private int coin = 0;

    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private TMP_Text coinText;

    private float startTime = 0f;



    private void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= 0.1f)
        {
            distance++;
            startTime = 0f;
        }

        ShowDistance();
    }

    void ShowDistance()
    {
        if (distance < 10f)
        {
            distanceText.text = "000" + distance.ToString() + "M";
        }
        else if (distance < 100f)
        {
            distanceText.text = "00" + distance.ToString() + "M";
        }
        else if (distance < 1000f)
        {
            distanceText.text = "0" + distance.ToString() + "M";
        }
        else
        {
            distanceText.text = distance.ToString() + "M";
        }
    }
}
