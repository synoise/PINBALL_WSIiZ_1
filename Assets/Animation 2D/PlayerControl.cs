using System.Transactions;
using ClearSky;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5
        public GameObject running; 
        public GameObject standing1;
        public GameObject jump1;
             //Set Gravity Scale in Rigidbody2D Component to 5

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
            // Debug.Log(anim);
   
    
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(direction, 1, 1);
                running.SetActive(true);
                standing1.SetActive(false);
                jump1.SetActive(false);
                // anim.SetTrigger("isRun");


            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(direction, 1, 1);
                running.SetActive(true);
                standing1.SetActive(false);
                jump1.SetActive(false);
                // anim.SetTrigger("isRun");
            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
      
            {
                isJumping = true;
                // anim.SetTrigger("isJump");
                running.SetActive(false); //Set Gravity Scale in Rigidbody2D Component to 5
                standing1.SetActive(false);
                jump1.SetActive(true);
        
            }
            if (!isJumping)
            {
                // anim.SetTrigger("isIdle");
                running.SetActive(false); //Set Gravity Scale in Rigidbody2D Component to 5
                standing1.SetActive(true);
                jump1.SetActive(false);
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