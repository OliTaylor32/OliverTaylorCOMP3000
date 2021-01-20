using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    //Controller for what type of controls the game is using.
    public int controlType = 0; // 0 = Run / 1 = sidestep / 2 = combat / 3 = Free-Roam / 4 = scripted
    public Scoring score;
    private Animator anim;
    public GameObject playerModel;

    //General Variables
    public int life = 3;
    public float speed;
    public float maxSpeed = 50f;
    private GameObject camera;
    private Rigidbody rigidbody;
    public IsGrounded isGrounded;
    private CharacterController controller;
    private float maxJump = 13f;
    private float jumpSpeed = 0.5f;
    private float gravity = 20f;
    private bool canTrick;
    private bool invincible;

    //Boosting Variables
    public  int boost = 0;
    private int boostSpeed = 100;
    public int maxBoost = 200;
    public bool boosting;

    //Running Variables
    private float acceleration = 0f;
    private float sideMovement;
    public bool jumping;
    public Quaternion targetRotation;
    private bool stomping;
    private bool drifting;

    //Hub amd Combat Variables
    public GameObject attackRange;
    private bool attacking;
    private int power;

    //Sidestep Variables
    private bool xStep = true;
    private int lane = 1;
    private float stepDistance;
    private bool canStep = true;

    //Input Variables
    float horizontalAxis;
    float verticalAxis;
    float horizontalAxis2;
    float verticalAxis2;

    // Start is called before the first frame update
    void Start()
    {
        canTrick = false;
        jumping = false;
        stomping = false;
        invincible = false;
        drifting = false;
        attacking = false;
        power = 1;

        camera = GameObject.Find("Main Camera");
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis2 = Input.GetAxis("Horizontal2");
        verticalAxis2 = Input.GetAxis("Vertical2");

        if (controlType == 0)
        {
            camera.transform.parent = transform;
            camera.transform.localPosition = new Vector3(35, 10, 1);
            camera.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);

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

            if (horizontalAxis >= 0.1)
            {
                sideMovement = 0.4f;
                if (drifting == true)
                {
                    sideMovement = 1f;
                }
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (sideMovement * 2), transform.rotation.eulerAngles.z);
            }

            if (horizontalAxis <= -0.1)
            {
                sideMovement = -0.4f;
                if (drifting == true)
                {
                    sideMovement = -1f;
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
            if (Input.GetButton("Boost") && isGrounded.isGrounded() == true && boost > 0)
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

            if (Input.GetButton("Attack"))
            {
                attackRange.GetComponent<AttackRange>().Attack(power, false);
                attacking = true;
            }

            Vector3 movement = new Vector3(sideMovement, 0, speed);
            movement = camera.transform.rotation * movement;
            player.GetComponent<CharacterController>().Move(movement * Time.deltaTime);


        }









        if (controlType == 1)
        {
            camera.transform.parent = transform;
            camera.transform.localPosition = new Vector3(35, 10, 1);
            camera.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);

            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
            acceleration = 0f;
            sideMovement = 0f;

            if (horizontalAxis >= 0.01 && lane != 2 && canStep == true)
            {
                canStep = false;
                lane++;
                if (xStep == true)
                {
                    transform.position = new Vector3(transform.position.x + stepDistance, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + stepDistance);
                }

                print("Right");
            }

            if (horizontalAxis <= -0.01 && lane != 0 && canStep == true)
            {
                canStep = false;
                lane--;
                if (xStep == true)
                {
                    transform.position = new Vector3(transform.position.x - stepDistance, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - stepDistance);
                }

                print("Left");
            }

            if (horizontalAxis < 0.01 && horizontalAxis > -0.01)
            {
                canStep = true;
            }

            speed = speed + acceleration;
            speed = Mathf.Clamp(speed, 0, maxSpeed);

            if (Input.GetButton("Boost") && isGrounded.isGrounded() == true && boost > 0)
            {
                speed = boostSpeed;
                boost--;
                boosting = true;
            }
            else
            {
                boosting = false;
            }

            if (Input.GetButton("Attack"))
            {
                attackRange.GetComponent<AttackRange>().Attack(power, false);
                attacking = true;
            }

            Vector3 movement = new Vector3(0, 0, speed);
            movement = camera.transform.rotation * movement;
            player.GetComponent<CharacterController>().Move(movement * Time.deltaTime);

            movement = new Vector3(sideMovement, 0, 0);
            movement = camera.transform.rotation * movement;
            player.GetComponent<CharacterController>().Move(movement);

        }













        Vector3 dir;
        Vector3 oldPos;
        if (controlType == 2)
        {
            Vector3 prevPos = transform.position;
            float fixX = transform.rotation.x;
            float fixZ = transform.rotation.z;
            //Camera is in fixed position, points towards player
            //Movement dependant on camera
            //Speed max speed is halfed. 
            //No boosting
            camera.transform.parent = null;
            camera.transform.LookAt(gameObject.transform);
            Vector3 move = camera.transform.forward * verticalAxis + camera.transform.right * horizontalAxis;
            controller.Move((maxSpeed / 4) * Time.deltaTime * move);
            if (verticalAxis == 0 && horizontalAxis == 0)
            {
                speed = 0;
            }
            else
            {
                speed = 1;
                if (verticalAxis < 0)
                {
                    transform.right = (prevPos - transform.position).normalized;
                    //transform.right = new Vector3(fixX, transform.rotation.y, fixZ).normalized;
                }
                else
                    transform.right = (transform.position - prevPos).normalized * -1f;
                //playerModel.transform.Rotate(0, 90, 0);
            }

            if (Input.GetButton("Attack"))
            {
                attackRange.GetComponent<AttackRange>().Attack(power, false);
                attacking = true;
                //Start a courintine in which it checks if the player starts a combo (Only if this attack actually hits anything.)
                //This method should give the player 1 sec to perform a valid follow up move
                //During that one secound it should note whether the player stoped pressing the buton
                //After which, a new button press would be valid. After a new valid combo attack, the timer is reset and it repeats.
                //If the player doesn't press a button, holds the button down, or performs an invalid attack, the method breaks.
                //If an invalid combo move was inputed, it will count as a normal attack, but not the start of a combo. 
                //If a combo is fully completed with no follow-ups avaliable, the method breaks. 
                //If an attack doesn't connect with an enemy, the method breaks.
                //If the player loses health, the method breaks. 
            }

            if (Input.GetButton("Boost"))
            {
                attackRange.GetComponent<AttackRange>().Attack((power*2), true);
                attacking = true;
            }
        }









        if (controlType == 3)
        {
            oldPos = transform.position;
            transform.Rotate(0, horizontalAxis2 * 2, 0);
            camera.transform.Rotate(-verticalAxis2, 0, 0);

            Vector3 move = transform.forward * horizontalAxis + transform.right * -verticalAxis;
            controller.Move((maxSpeed / 4) * Time.deltaTime * move);
            if (verticalAxis == 0 && horizontalAxis == 0)
            {
                speed = 0;
            }
            else
            {
                speed = 1;
                playerModel.transform.LookAt(transform.forward);
                //playerModel.transform.Rotate(0, 90, 0);
            }

            if (Input.GetAxisRaw("Attack") == 1)
            {
                controlType = 4;
                print("Button pressed");
                //if the Attackrange has an object in its collision, get the character to display the text, set control type to 4
                if (attackRange.GetComponent<AttackRange>().interactable != null)
                {
                    attackRange.GetComponent<AttackRange>().Interact();
                    print("Interact called");
                    anim.SetBool("Idle", true);
                    anim.SetBool("Run", false);
                }
                else
                {
                    controlType = 3;
                }
            }
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
            if (Input.GetButton("Jump") && jumping == false && isGrounded.isGrounded() == true)
            {
                jumping = true;
                print("Jump");
                StartCoroutine(Jump());

            }

            /////////////
            ///Gravity///
            /////////////
            if (isGrounded.isGrounded() == true)
            {
                jumping = false;
                canTrick = false;
            }

            if (isGrounded.isGrounded() == false && jumping == false)
            {
                Vector3 grav = new Vector3(0, gravity, 0);
                player.GetComponent<CharacterController>().Move(-(grav * Time.deltaTime));
            }

            //////////////
            ///Drifting///
            //////////////
            if (Input.GetButton("Drift") && isGrounded.isGrounded() == true)
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
    private IEnumerator Jump()
    {
        float height = 0;
        float i = 1;
        while(Input.GetButton("Jump") && height < maxJump)
        {
            jumping = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + (jumpSpeed * i), transform.position.z);
            if (i > 0.1f)
            {
                i = i - 0.05f;
            }
            yield return new WaitForSeconds(0.01f);
            height = height + jumpSpeed;
        }
        jumping = false;

    }

    public void SkillRamp(float height)
    {
        print("Skill ramp script start");
        acceleration = maxSpeed;
        jumping = true;
        StartCoroutine(SkillRampStart(height));
    }

    private IEnumerator SkillRampStart(float height)
    {
        controlType = 1;
        float i = 0;
        while (i < height)
        {
            canTrick = true;
            acceleration = maxSpeed;
            speed = maxSpeed / 2;
            transform.position = new Vector3(transform.position.x, transform.position.y + (0.5f), transform.position.z);
            yield return new WaitForSeconds(0.01f);
            i = i + 0.5f;
        }

        jumping = false;
        controlType = 0;
    }

    public void StrafeStart(float rotation, float x, float z, float distance)
    {
        controlType = 1;
        stepDistance = distance;
        speed = maxSpeed;
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, rotation, player.transform.rotation.eulerAngles.z);
        player.transform.position = new Vector3(x, player.transform.position.y, z);
        lane = 1;
        if (rotation == 0)
        {
            xStep = false;
        }
        if (rotation == 90)
        {
            xStep = true;
        }
        if (rotation == 180)
        {
            xStep = false;
            stepDistance = -distance;
        }
        if (rotation == -90)
        {
            xStep = true;
            stepDistance = -distance;
        }
    }

    public void RunStart(float rotation)
    {
        controlType = 0;
        speed = maxSpeed;
        player.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    public void CombatStart(Vector3 newCameraPos)
    {
        Vector3 movement = new Vector3(0, 0, maxSpeed);
        for (int i = 0; i < 3; i++)
        {
            player.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        }
        camera.transform.parent = null;
        camera.transform.LookAt(gameObject.transform);

        camera.transform.position = newCameraPos;
        controlType = 2;
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
        else if (hit.gameObject.GetComponent<EnemyHealth>() != null)
        {
            if (boosting == true)
            {
                hit.gameObject.GetComponent<EnemyHealth>().Attacked(power, false);
            }
            else
            {
                Damaged();
            }
        }

        if (hit.gameObject.GetComponent<Spikes>() != null)
        {
            if (hit.gameObject.GetComponent<Spikes>().active == true)
            {
                Damaged();
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

    public IEnumerator EndInteraction()
    {
        yield return new WaitForSeconds(0.2f);
        controlType = 3;
    }

    public void Damaged()
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
