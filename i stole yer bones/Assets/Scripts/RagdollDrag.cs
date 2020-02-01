﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDrag : MonoBehaviour
{
    Rigidbody2D rb = null;
    bool isHeld = false; //is the mouse holding this objct?

    insideBone bone;

    Vector3 mousePosition;
    //Vector3 previousMousePosition;
    //Vector3 mouseDisplacement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bone = GetComponentInChildren<insideBone>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!Input.GetButton("Fire1")) isHeld = false;

        if (isHeld && CheckForBone())
        {
            rb.AddForce(mousePosition - transform.position, ForceMode2D.Impulse);
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

    private bool CheckForBone()
    {
        return bone != null && bone.hasBone;
    }
}
