using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] SpriteRenderer fill = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "outsideBone")
        {
            fill.size = new Vector2(fill.size.x, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "outsideBone")
        {
            Debug.Log(collision);
            if(collision.gameObject.GetComponent<RagdollDrag>()) collision.gameObject.GetComponent<RagdollDrag>().StickTo(transform);
            

            Vector2 size = fill.size;
            size.y += 0.1f;
            if (size.y < 4.5f) size.y = 4.5f;
            fill.size = size;
        }
    }
}
