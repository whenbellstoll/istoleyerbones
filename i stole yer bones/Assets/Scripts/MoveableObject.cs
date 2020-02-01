using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseOver()
    {
        if (Input.GetButton("Fire1"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(rb.bodyType != RigidbodyType2D.Dynamic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
