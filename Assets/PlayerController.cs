using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    CharacterController cc;
    float yVel;

    void Start() 
    {
        cc = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        if (cc.isGrounded && yVel < 0) yVel = -2f;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
            yVel = Mathf.Sqrt(jumpHeight * -2f * gravity);

        yVel += gravity * Time.deltaTime;

        cc.Move((move * speed + Vector3.up * yVel) * Time.deltaTime);
    }
}