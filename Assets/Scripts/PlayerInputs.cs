using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private Rigidbody2D rb;
    private bool isUp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Sube");
                isUp = true;
                
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Baja");
                isUp = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isUp)
        {
            rb.AddForce(Vector2.up * playerData.speed);
        }
    }
}
