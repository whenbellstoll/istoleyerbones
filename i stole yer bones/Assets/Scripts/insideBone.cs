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
            if(!hasBone && collision.gameObject.tag == "outsideBone" && collision.gameObject.transform.parent == null)
            {
                Destroy(collision.gameObject);
                GetComponent<SpriteRenderer>().color = Color.white;
                hasBone = true;
            }
        }
    }
}
