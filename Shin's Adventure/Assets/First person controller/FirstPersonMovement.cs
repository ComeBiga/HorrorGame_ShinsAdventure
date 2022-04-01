using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    CharacterController cc;

    public float speed = 5;
    Vector2 velocity;

    Rigidbody rb;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(velocity.x, 0, velocity.y);

        rb.velocity = velocity;

        //cc.Move(transform.right * velocity.x);
        //cc.Move(transform.forward * velocity.y);
    }
}
