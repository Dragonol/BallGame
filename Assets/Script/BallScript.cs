using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float Speed;
    public float StablizePoint;
    public float FrictionPoint;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 acelebration;
        float alt = Mathf.Abs(Input.acceleration.x) + Mathf.Abs(Input.acceleration.y);
        if (alt > 1)
        {
            acelebration = new Vector2(Input.acceleration.x / alt,
                                       Input.acceleration.y / alt);
        }
        else
        {
            acelebration = Input.acceleration;
        }
        Vector2 filtedAccelebration = new Vector2(
            Mathf.Abs(acelebration.x) < StablizePoint ? 0 : acelebration.x,
            Mathf.Abs(acelebration.y) < StablizePoint ? 0 : acelebration.y);
        rb2d.velocity += Speed * filtedAccelebration * Time.deltaTime;
        Vector2 updateVelocity;
        if (rb2d.velocity.x < 0)
        {
            updateVelocity.x = Mathf.Min(0, rb2d.velocity.x + FrictionPoint * Time.deltaTime);
        }
        else
        {
            updateVelocity.x = Mathf.Max(0, rb2d.velocity.x - FrictionPoint * Time.deltaTime);
        }

        if (rb2d.velocity.y < 0)
        {
            updateVelocity.y = Mathf.Min(0, rb2d.velocity.y + FrictionPoint * Time.deltaTime);
        }
        else
        {
            updateVelocity.y = Mathf.Max(0, rb2d.velocity.y - FrictionPoint * Time.deltaTime);
        }
        rb2d.velocity = updateVelocity;
    }
}
