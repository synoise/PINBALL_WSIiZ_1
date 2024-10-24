using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyboardControl : MonoBehaviour
{
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5
        // public GameObject running; //Set Gravity Scale in Rigidbody2D Component to 5
        // public GameObject standing1;
        // public GameObject jump1;
             //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        Vector3 movement;
        private int direction = 1;
        

        public GameObject projectile;
        public float launchVelocity = 700f;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            
                Hurt();
                Attack();
                Run();

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
     
        }



        void Run()
        {
           
            // Debug.Log(anim);
   
    
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
            
                rb.AddForce(new Vector2(-0.1f, 0), ForceMode2D.Impulse);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.AddForce(new Vector2(0.1f, 0), ForceMode2D.Impulse);
            }
            // if ((Input.GetKeyDown("Jump") || Input.GetAxisRaw("Vertical") > 0))
            // {
            //     Debug.Log("Vertical");
            //     // movePlayer(-1, -1, 1);
            // }
            // if ((Input.GetKeyDown("Jump") || Input.GetAxisRaw("Vertical") > 0))
            // {
            //     Debug.Log("--Vertical");
            //     // movePlayer(1, 1, -1);
            // }
            
            if (Input.GetKey("up"))
            {
                rb.AddForce(new Vector2(0, 0.1f), ForceMode2D.Impulse);
            }

            if (Input.GetKey("down"))
            {
           
                rb.AddForce(new Vector2(0, -0.1f), ForceMode2D.Impulse);
            }
            
     
           
        }

        // private void movePlayer(int direction1, int y, int z)
        // { 
        //     Vector3 moveVelocity = Vector3.zero;
        //     direction = 1;
        //     moveVelocity = Vector3.right;
        //     transform.localScale = new Vector3(direction1, y, z);
        //     transform.position += moveVelocity * movePower * Time.deltaTime;
        // }
     
        void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject ball = (GameObject)Instantiate(projectile, transform.position,  
                    transform.rotation);
 
                ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3 
                    (0, 1500,0));
                
                //         ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.001f), ForceMode2D.Impulse);
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


    }