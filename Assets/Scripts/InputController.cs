using UnityEngine;

public class InputController : MonoBehaviour
{
    Transform cam;

    public Joystick joystickMove;
    public Joystick joystickGiro;

    public Rigidbody rb;
    
    float rotateV;
    float rotateH;

    public float speed = 10f;
    public float speedGiro = 0.2f;

    private void start()
    {
        cam = Camera.main.transform;
    }

    void move()
    {
        rb.linearVelocity = new Vector3(joystickMove.Horizontal * speed + Input.GetAxis("Horizontal"), rb.linearVelocity.y, joystickMove.Vertical * speed + Input.GetAxis("Vertical"));
    }

     public void JumpBt()
    {
        rb.linearVelocity += Vector3.up * speed;
    }
    /*
    void Rotate()
    {
        rotateH = joystickGiro.Horizontal * speedGiro;
        rotateV = joystickMove.Vertical * speedGiro;
        cam.Rotate(rotateV, rotateH, 0);
    }
    */
    private void Update()
    {
        move();
       // Rotate();
    }
}
