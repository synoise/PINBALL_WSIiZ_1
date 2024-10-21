using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControlls : MonoBehaviour
{
    public float movePower = 10f;
    // Update is called once per frame
    void Update()
    {
        Run();
    }
    
    void Run()
    {
        Vector3 moveVelocity = Vector3.zero;
            
        Debug.Log("asd");
            
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if ( Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity = Vector3.forward;
            transform.localScale = new Vector3(1, 1, 1); 
        
        }
        if ( Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity = Vector3.back;
            transform.localScale = new Vector3(1, 1, 1); 
        
        }
            
        transform.position += moveVelocity * (movePower * Time.deltaTime);
    }
}
