using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Basic Movement Variables
	private float moveSpeed = 5;
	private float maxSpeed = 30;
    private float moveVelocity;
	public float dashForce;
	public bool isMoving;
    public float jumpHeight;

    //Checking for Ground
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //Check if double jump boolean
    private bool doubleJumped;

    //Animator
    private Animator anim;

    //Shuriken Fire Variables
    public Transform firePoint;
    public GameObject shuriKen;

    //Shuriken FireRate Variables
    public float shotDelay;
    private float shotDelayCounter;

    public float knockBack;
    public float knockBackLength;
    public float knockBackCount;
    public bool knockFromRight;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

	}

    //Check If Player is grounded
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update () {

        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
            doubleJumped = true;
        }

			//Movement
	        moveVelocity = 0f;

			if (isMoving == false) {
				moveSpeed = 5;
			}
			isMoving = false;

			//Move Right
			if (Input.GetKey ("right")) {
				moveVelocity = moveSpeed;
				isMoving = true;
				if (moveSpeed < maxSpeed && isMoving == true) {
					moveSpeed += Time.deltaTime;
				}
			}

			//Move Left
			if (Input.GetKey ("left")) {
				moveVelocity = -moveSpeed;
				isMoving = true;
				if (moveSpeed < maxSpeed && isMoving == true) {
					moveSpeed += Time.deltaTime;
				}
			}


        if(knockBackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        } else {
            if(knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockBack, 2.5f);
            if(!knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockBack, 2.5f);
            knockBackCount -= Time.deltaTime;
        }
        //GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        //Shooting Input
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(shuriKen, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }

        //Shooting Delay
        if (Input.GetKey(KeyCode.X))
        {
            shotDelayCounter -= Time.deltaTime;

            if(shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(shuriKen, firePoint.position, firePoint.rotation);
            }
        }

        //Sword Animation
        if (anim.GetBool("Sword"))
            anim.SetBool("Sword", false);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Sword", true);
        }
    }

    //Jump Mechanic
    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
    }
}
