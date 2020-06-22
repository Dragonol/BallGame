using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public float PushForce;
    public Vector2 Direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hello");
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Rigidbody2D pRb2d = player.GetComponent<Rigidbody2D>();
            //Vector2 currDir = pRb2d.velocity;
            //Vector2 contactNormal = pRb2d.transform.position - transform.position;
            //Debug.Log("Normal: x: " + contactNormal.x + " y: " + contactNormal.y);
            //Debug.Log("Velocity: x: " + currDir.x + " y: " + currDir.y);
            //Vector2 newDir = Vector2.Reflect(currDir, contactNormal);
            //Debug.Log("New Dir: x: " + newDir.x + " y: " + newDir.y);
            //pRb2d.AddForce(newDir.normalized * PushForce);
            pRb2d.AddForce(Direction * PushForce);
        }
    }
}
