using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public float PushForce;
    private bool isCharge = true;
    private Vector2 dir;
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
        if (collision.gameObject.tag == "Player" && isCharge)
        {
            GameObject player = collision.gameObject;
            Rigidbody2D pRb2d = player.GetComponent<Rigidbody2D>();
            dir = (Vector2)(Quaternion.Euler(transform.rotation.eulerAngles) * Vector2.up);
            Debug.Log(dir);
            pRb2d.AddForce(dir * PushForce);
            isCharge = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCharge = true;
    }
}
