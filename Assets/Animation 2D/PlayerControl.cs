using System.Transactions;
using ClearSky;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5
        
        public WizJohny animation;

        private Rigidbody2D rb;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;


        // Start is called before the first frame update
        void Start()
        {
            Restart();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            
            Debug.Log(isJumping);
            Restart();
            if (alive)
            {
                // Hurt();
                // Die();
                // Attack();
                Jump();
                Run();
                // Idle();

            }
        }
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //
        // }
        
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                // anim.SetTrigger("isIdle");
                alive = true;
            }
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(direction, 1, 1);
                if (isJumping == false)
                {
                    animation.RunJohny();
                }
                // anim.SetTrigger("isRun");


            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(direction, 1, 1);
                if (isJumping == false)
                {
                    animation.RunJohny();
                }
            }
            transform.position += moveVelocity * (movePower * Time.deltaTime);
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            {
                isJumping = true;
                animation.JumpJohny();
        
            }
            if (!isJumping)
            {
                animation.IdleJohny();
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        /*
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
       
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
 
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                alive = false;
            }
        }*/

    }