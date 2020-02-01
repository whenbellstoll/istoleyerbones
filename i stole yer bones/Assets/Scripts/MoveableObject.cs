using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    Rigidbody2D rb = null;
    bool isHeld = false; //is the mouse holding this objct?
    Vector3 mouseDisplacement; //how far from the center of the object the mouse is holding it

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDisplacement;
        }
        else if(rb.bodyType != RigidbodyType2D.Dynamic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isHeld)
            {
                isHeld = true;
                mouseDisplacement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            }
        }
        else
        {
            isHeld = false;
        }
    }
}
