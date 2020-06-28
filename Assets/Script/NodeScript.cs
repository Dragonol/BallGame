using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public float PushForce;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Rigidbody2D pRb2d = player.GetComponent<Rigidbody2D>();
            dir = (Vector2)(Quaternion.Euler(transform.rotation.eulerAngles) * Vector2.up);
            Debug.Log(dir);
            float altAngle = Vector2.Angle(dir, Vector2.right);
            //pRb2d.AddForce(new Vector2(PushForce * Mathf.Cos(altAngle), PushForce * Mathf.Sin(altAngle)));
            pRb2d.AddForce(dir.normalized * PushForce);
        }
    }
}
