using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField] GameObject mouse;

    Rigidbody2D rb = null;
    bool isHeld = false; //is the mouse holding this objct?

    Vector3 previousMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Fire1")) isHeld = false;
        if (!isHeld)
        {
            mouse.transform.eulerAngles = Vector3.zero;
            transform.parent = null;
        }


        if (isHeld)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            mouse.transform.eulerAngles = new Vector3 (0, 0, EasingFunction.EaseInElastic( mouse.transform.eulerAngles.z, 90.01f, 0.39f ) );
        }
        else if(rb.bodyType != RigidbodyType2D.Dynamic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;

            //oh gee howdy do I love throwin' bones with some M A G I C N U M B E R S
            rb.AddForce((mouse.transform.position - previousMousePosition) * 25.0f, ForceMode2D.Impulse) ;
        }

        previousMousePosition = mouse.transform.position;
    }


    private void OnMouseOver()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isHeld)
            {
                isHeld = true;
                transform.parent = mouse.transform;
            }
        }
    }
}
