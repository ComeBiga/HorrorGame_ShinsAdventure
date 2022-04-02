using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    CharacterController cc;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        cc.Move(Vector3.forward * h * speed * Time.deltaTime);
        cc.Move(Vector3.left * v * speed * Time.deltaTime);
    }
}
