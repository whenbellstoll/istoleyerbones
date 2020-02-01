using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDrag : MonoBehaviour
{
    GameObject mouse;
    Rigidbody2D rb = null;
    bool isHeld = false; //is the mouse holding this objct?

    Vector3 mousePosition;
    //Vector3 previousMousePosition;
    //Vector3 mouseDisplacement;

    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.Find("mouse");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!Input.GetButton("Fire1")) isHeld = false;

        if (isHeld)
        {
            rb.AddForce(mousePosition - transform.position, ForceMode2D.Impulse);
        }
        else if (rb.bodyType != RigidbodyType2D.Dynamic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;

            //oh gee howdy do I love throwin' bones with some M A G I C N U M B E R S
            //rb.AddForce((mouse.transform.position - previousMousePosition) * 25.0f, ForceMode2D.Impulse);
        }

        if(mouse.transform.childCount > 0)
        {
            //FEED ME
            rb.AddForce((mouse.transform.GetChild(0).transform.position - transform.position) * 0.1f, ForceMode2D.Impulse) ;
        }

        //previousMousePosition = mousePosition;
    }

    private void OnMouseOver()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isHeld)
            {
                isHeld = true;
                //mouseDisplacement = mouseDisplacement - transform.position;
            }
        }
    }
}
