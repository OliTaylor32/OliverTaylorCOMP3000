using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    //Controller for what type of controls the game is using.
    private int controlType = 0; // 0 = Run / 1 = sidestep / 2 = combat / 3 = Scripted
    public Scoring score;
    private Animator anim;

    //General Variables
    public int life = 3;
    public float speed;
    public float maxSpeed = 50f;
    private GameObject camera;
    private Rigidbody rigidbody;
    private CharacterController controller;
    private float maxJump = 6f;
    private float jumpSpeed = 0.4f;
    private float gravity = 20f;
    private bool canTrick;
    private bool invincible;

    //Boosting Variables
    public  int boost = 0;
    private int boostSpeed = 100;
    public int maxBoost = 500;
    public bool boosting;

    //Running Variables
    private float acceleration = 0f;
    private float sideMovement;
    public bool jumping;
    public Quaternion targetRotation;
    private bool stomping;
    private bool drifting;

    //Input Variables
    float horizontalAxis;
    float verticalAxis;

    // Start is called before the first frame update
    void Start()
    {
        canTrick = false;
        jumping = false;
        stomping = false;
        invincible = false;
        drifting = false;

        camera = GameObject.Find("Main Camera");
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if (controlType == 0)
        {
            if (verticalAxis >= 0.01)
            {
                acceleration = 0.5f;
            }

            if (verticalAxis <= -0.01)
            {
                acceleration = -1f;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, camera.transform.rotation, acceleration * Time.deltaTime);
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
            }

            if (verticalAxis < 0.01 && verticalAxis > -0.01)
            {
                acceleration = -0.5f;
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
            }

            if (horizontalAxis >= 0.01)
            {
                sideMovement = 0.2f;
                if (drifting == true)
                {
                    sideMovement = 0.5f;
                }
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (sideMovement * 2), transform.rotation.eulerAngles.z);
            }

            if (horizontalAxis <= -0.01)
            {
                sideMovement = -0.2f;
                if (drifting == true)
                {
                    sideMovement = -0.5f;
                }
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (sideMovement * 2), transform.rotation.eulerAngles.z);
            }

            if (horizontalAxis < 0.01 && horizontalAxis > -0.01)
            {
                sideMovement = 0f;
            }

            speed = speed + acceleration;
            speed = Mathf.Clamp(speed, 0, maxSpeed);

            ////////////
            //Boosting//
            ////////////
            if (Input.GetButton("Boost") && controller.isGrounded && boost > 0)
            {
                speed = boostSpeed;
                boost--;
                boosting = true;
            }
            else
            {
                boosting = false;
            }
            ////////////
            //STOMPING//
            ////////////
            if (Input.GetButton("Stomp") && controller.isGrounded == false)
            {
                stomping = true;
            }

            if (stomping == true && controller.isGrounded == false)
            {
                Vector3 stomp = new Vector3(0, (gravity * 2), 0);
                player.GetComponent<CharacterController>().Move(-(stomp * Time.deltaTime));
            }

            if (stomping == true && controller.isGrounded == true)
            {
                stomping = false;
            }

            Vector3 movement = new Vector3(sideMovement, 0, speed);
            movement = camera.transform.rotation * movement;
            player.GetComponent<CharacterController>().Move(movement * Time.deltaTime);

            ///////////////
            ///Animation///
            ///////////////
            if (stomping == true)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Jump", false);
                anim.SetBool("DriftL", false);
                anim.SetBool("DriftR", false);
                anim.SetBool("Stomp", true);
            }
            if (jumping == true)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Jump", true);
                anim.SetBool("DriftL", false);
                anim.SetBool("DriftR", false);
                anim.SetBool("Stomp", false);
            }
            //else if (controller.isGrounded == false)
            //{
            //    anim.SetBool("Run", false);
            //    anim.SetBool("Idle", false);
            //    anim.SetBool("Jump", false);
            //    anim.SetBool("DriftL", false);
            //    anim.SetBool("DriftR", false);
            //    anim.SetBool("Stomp", false);
            //}
            else if (speed <= 0.5f)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);
                anim.SetBool("Jump", false);
                anim.SetBool("DriftL", false);
                anim.SetBool("DriftR", false);
                anim.SetBool("Stomp", false);
            }
            else if (speed > 0.5f)
            {
                if (drifting == true)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        anim.SetBool("Run", false);
                        anim.SetBool("Idle", false);
                        anim.SetBool("Jump", false);
                        anim.SetBool("DriftL", false);
                        anim.SetBool("DriftR", true);
                        anim.SetBool("Stomp", false);
                    }

                    if (Input.GetAxis("Horizontal") == 0)
                    {
                        anim.SetBool("Run", true);
                        anim.SetBool("Idle", false);
                        anim.SetBool("Jump", false);
                        anim.SetBool("DriftL", false);
                        anim.SetBool("DriftR", false);
                        anim.SetBool("Stomp", false);
                    }

                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        anim.SetBool("Run", false);
                        anim.SetBool("Idle", false);
                        anim.SetBool("Jump", false);
                        anim.SetBool("DriftL", true);
                        anim.SetBool("DriftR", false);
                        anim.SetBool("Stomp", false);
                    }
                }
                else
                {
                    anim.SetBool("Run", true);
                    anim.SetBool("Idle", false);
                    anim.SetBool("Jump", false);
                    anim.SetBool("DriftL", false);
                    anim.SetBool("DriftR", false);
                    anim.SetBool("Stomp", false);

                }

                if (boosting == true)
                {
                    anim.speed = 2;
                }
                else
                {
                    anim.speed = 1;
                }
            }
        }

        if (controlType == 1)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
            acceleration = 0f;

            if (horizontalAxis >= 0.01)
            {
                sideMovement = 0.5f;
                print("Right");
            }

            if (horizontalAxis <= -0.01)
            {
                sideMovement = -0.5f;
                print("Left");
            }

            if (horizontalAxis < 0.01 && horizontalAxis > -0.01)
            {
                sideMovement = 0f;
            }

            speed = speed + acceleration;
            speed = Mathf.Clamp(speed, 0, maxSpeed);

            if (Input.GetButton("Boost") && controller.isGrounded && boost > 0)
            {
                speed = boostSpeed;
                boost--;
                boosting = true;
            }
            else
            {
                boosting = false;
            }

            Vector3 movement = new Vector3(0, 0, speed);
            movement = camera.transform.rotation * movement;
            player.GetComponent<CharacterController>().Move(movement * Time.deltaTime);

            movement = new Vector3(sideMovement, 0, 0);
            movement = camera.transform.rotation * movement;
            player.GetComponent<CharacterController>().Move(movement);

        }

        if (speed == boostSpeed)
        {
            if (camera.GetComponent<Camera>().fieldOfView != 80)
            {
                camera.GetComponent<Camera>().fieldOfView = camera.GetComponent<Camera>().fieldOfView + 1;
            }
        }
        else
        {
            if (camera.GetComponent<Camera>().fieldOfView != 60)
            {
                camera.GetComponent<Camera>().fieldOfView = camera.GetComponent<Camera>().fieldOfView - 1;
            }
        }
        //////////
        //Tricks//
        //////////
        if (Input.GetButtonDown("Trick") == true && canTrick == true)
        {
            boost = boost + 10;
            score.AddScore(10);
            print("Trick");
        }


        //player.transform.localPosition = new Vector3(player.transform.localPosition.x + sideMovement, player.transform.localPosition.y, player.transform.localPosition.z);

        /////////////
        ///Jumping///
        /////////////
        if (Input.GetButton("Jump") && jumping == false && controller.isGrounded == true)
        {
            jumping = true;
            print("Jump");
            StartCoroutine(Jump());

        }

        /////////////
        ///Gravity///
        /////////////
        if (controller.isGrounded)
        {
            jumping = false;
            canTrick = false;
        }

        if (controller.isGrounded == false && jumping == false)
        {
            Vector3 grav = new Vector3(0, gravity, 0);
            player.GetComponent<CharacterController>().Move(-(grav * Time.deltaTime));
        }

        //////////////
        ///Drifting///
        //////////////
        if (Input.GetButton("Drift") && controller.isGrounded == true)
        {
            drifting = true;
        }
        else
        {
            drifting = false;
        }

        //Ensure Player doesn't exceed boost limit
        boost = Mathf.Clamp(boost, 0, maxBoost);

        //Death
        if (life <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private IEnumerator Jump()
    {
        float height = 0;

        while(Input.GetButton("Jump") && height < maxJump)
        {
            jumping = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpSpeed, transform.position.z);
            yield return new WaitForSeconds(0.01f);
            height = height + jumpSpeed;
        }
        jumping = false;

    }

    public void SkillRamp()
    {
        print("Skill ramp script start");
        acceleration = maxSpeed;
        jumping = true;
        StartCoroutine(SkillRampStart());
    }

    private IEnumerator SkillRampStart()
    {
        float i = 0;
        while (i < 25f)
        {
            canTrick = true;
            acceleration = maxSpeed;
            speed = maxSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y + (1.2f), transform.position.z);
            yield return new WaitForSeconds(0.01f);
            i = i + 1.2f;
        }

        jumping = false;
    }

    public void StrafeStart(float rotation, float x, float z)
    {
        controlType = 1;
        speed = maxSpeed;
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, rotation, player.transform.rotation.eulerAngles.z);
        player.transform.position = new Vector3(x, player.transform.position.y, z);
    }

    public void RunStart(float rotation)
    {
        controlType = 0;
        speed = maxSpeed;
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, rotation, player.transform.rotation.eulerAngles.z);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<WoodCrate>() != null)
        {
            if (boosting == true)
            {
                hit.gameObject.GetComponent<WoodCrate>().Contact();
                score.AddScore(20);
                boost = boost + 20;
            }
            else
            {
                speed = 0;
                acceleration = 0.5f;
            }
            
        }

        if (hit.gameObject.GetComponent<Spikes>() != null)
        {
            if (hit.gameObject.GetComponent<Spikes>().active == true)
            {
                if (controlType == 0 && invincible == false)
                {
                    acceleration = 0;
                    speed = 0;
                    Vector3 movement = new Vector3(0, 0, -6);
                    movement = camera.transform.rotation * movement;
                    player.GetComponent<CharacterController>().Move(movement);
                }
                if (controlType == 1)
                {
                    Vector3 movement = new Vector3(0, 0, 3);
                    movement = camera.transform.rotation * movement;
                    player.GetComponent<CharacterController>().Move(movement);
                }

                if (invincible == false)
                {
                    life = life - 1;
                    StartCoroutine(invincibility());
                }
            }
        }

        if (hit.gameObject.name == "DeathBarrier")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private IEnumerator invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(1);
        invincible = false;
    }
}
