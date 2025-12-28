using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -20f;
    CharacterController cc;
    float yVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(h, 0, 0);
        move *= moveSpeed;

        if (cc.isGrounded)
        {
            if (yVelocity < 0)
            {
                yVelocity = -2f;
            }
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpForce;
            }
        }
        yVelocity += gravity * Time.deltaTime;
        move.y=yVelocity;
        cc.Move(move*Time.deltaTime);
    }
}
