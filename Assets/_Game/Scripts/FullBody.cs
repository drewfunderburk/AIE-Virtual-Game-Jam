using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBody : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D collide;
    Collider2D child;
    public GameObject connect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
        child = connect.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(connect.GetComponent<PlayerStat>().gold)
        {
            if(collide.IsTouching(child))
            {
                connect.GetComponent<Collider2D>().enabled = false;
                connect.GetComponent<Rigidbody2D>().isKinematic = true;
                connect.GetComponent<PlayerMovement>().enabled = false;

                connect.transform.SetParent(transform);
                connect.transform.position = new Vector3(transform.position.x, transform.position.y + 1,transform.position.z);

            }
        }
    }
}