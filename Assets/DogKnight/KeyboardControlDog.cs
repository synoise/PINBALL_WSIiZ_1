using UnityEngine;



public class KeyboardControlDog : MonoBehaviour
{
        private Rigidbody rb;
        Vector3 movement;
        private int direction = 1;
        
        public GameObject bullet;
        public float launchVelocity = 700f;
        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            
                // Hurt();
                Attack();
                Run();

        }


        void Run()
        {
           
            // Debug.Log(anim);
    _animator.SetBool("isRunning", false);
    
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //transform.Rotate (new Vector3 (0, 20, 0) * 5*Time.deltaTime);
                rb.AddForce(new Vector3(0.05f,0,0),ForceMode.Impulse);
                _animator.SetBool("isRunning", true);
            }else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //transform.Rotate (new Vector3 (0, -20, 0) * 5*Time.deltaTime);
                rb.AddForce(new Vector3(-0.05f,0,0),ForceMode.Impulse);
                _animator.SetBool("isRunning", true);
            }
        
     
            // if ((Input.GetKeyDown("Jump") || Input.GetAxisRaw("Vertical") > 0))
            // {
            //     Debug.Log("--Vertical");
            //     // movePlayer(1, 1, -1);
            // }
            
            if (Input.GetKey("up"))
            {
                rb.AddForce(new Vector3(0,0,0.05f),ForceMode.Impulse);
                _animator.SetBool("isRunning", true);
            }else if (Input.GetKey("down"))
            {
                rb.AddForce(new Vector3(0,0, -0.05f), ForceMode.Impulse);
                _animator.SetBool("isRunning", true);
            }
           

        }
        
        void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _animator.SetBool("Attack", true);
                GameObject ball = (GameObject)Instantiate(bullet, transform.position,  
                    transform.rotation);
 
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 550,1500));
                
                //         ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.001f), ForceMode2D.Impulse);
            }
            else
            {
                _animator.SetBool("Attack", false);
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
 
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode.Impulse);
            }
        }
    }