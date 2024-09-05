using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //personaje
    Transform tr;
    Rigidbody rb;

    public float walkSpeed = 200;

    public float jumpForce = 25;

    public bool OnGround;
    public bool Jumping;

    public GameObject triggerJump;

    //Camara
    public Transform cameraShoulder;
    public Transform cameraHolder;
    private Transform cam;

    private float rotY = 0;

    public float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    //animaciones
    Animator anim;

    private Vector2 animSpeed;

    void Start()
    {
        tr = this.transform;

        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();

        cam = Camera.main.transform;
    }

    void Update()
    {
        MoveControl();

        ActionsControl();

        CameraControl();

        AnimControl();
    }

    public void MoveControl()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;

        animSpeed= new Vector2(deltaX, deltaZ);


        Vector3 side = walkSpeed * deltaX * deltaT * tr.right;
        Vector3 forward = walkSpeed * deltaZ * deltaT * tr.forward;

        Vector3 direction = side + forward;

        direction.y = rb.linearVelocity.y;

        rb.linearVelocity = direction;

    }

    public void ActionsControl()
    {
        Jumping = Input.GetKey(KeyCode.Space);

        if(OnGround)
        {
            if(Jumping)
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }

    public void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * rotationSpeed * deltaT;

        float rotX = mouseX * rotationSpeed * deltaT;

        tr.Rotate(0, rotX, 0);

        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
    }

    public void AnimControl()
    {
        anim.SetBool("ground", OnGround);

        anim.SetFloat("X", animSpeed.x);
        anim.SetFloat("Y", animSpeed.y);

    }
}
