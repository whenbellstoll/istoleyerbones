using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insideBone : MonoBehaviour
{
    public bool hasBone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Input.GetButton("Fire1"))
        {
            if(collision.gameObject.tag == "outsideBone" && collision.gameObject.transform.parent == null)
            {
                collision.gameObject.transform.parent = gameObject.transform;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                collision.gameObject.transform.position = gameObject.transform.position;
                collision.gameObject.transform.rotation = gameObject.transform.rotation;
                hasBone = true;
            }
        }
    }
}
