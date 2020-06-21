using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakThingScript : MonoBehaviour
{
    public float Duration;
    private float currDuration;
    // Start is called before the first frame update
    void Start()
    {
        currDuration = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            float impulse = 0F;

            foreach (ContactPoint2D point in collision.contacts)
            {
                impulse += point.normalImpulse;
            }
            float currentForce = impulse / Time.fixedDeltaTime;
            if (currDuration <= currentForce)
            {
                Object.Destroy(gameObject);
            }
            else
            {
                currDuration -= currentForce;
                transform.GetChild(0).transform.localScale = new Vector3(currDuration / Duration, currDuration / Duration, 1);
            }
        }
    }
}
