using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDog : MonoBehaviour
{
Camera cam;
Transform my;
Rigidbody body;

void Start()
{
    cam = Camera.main;
    my = GetComponent <Transform> ();
    body = GetComponent <Rigidbody> ();
}

void Update()
{
    // Distance from camera to object.  We need this to get the proper calculation.
    float camDis = cam.transform.position.y - my.position.y;

    // Get the mouse position in world space. Using camDis for the Z axis.
    Vector3 mouse = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));

    float AngleRad = Mathf.Atan2 (mouse.y - my.position.y, mouse.x - my.position.x);
    float angle = (180 / Mathf.PI) * AngleRad;
    
    transform.Rotate (new Vector3 (0, angle, 0) * 5*Time.deltaTime);
    
    
    // // body.rotation= angle - 90;
    // if (Input.GetKey("z")) 
    // {
    //     transform.Rotate(  0,3*Time.deltaTime, 0,Space.Self); 
    // } 
    //
    // if (Input.GetKey("x")) 
    // { 
    //     transform.Rotate( 0,4*Time.deltaTime, 0,Space.Self); 
    // }
}

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     Debug.Log("OnCollisionEnter2D " + col.collider.tag);
    //
    //     if (col.gameObject.CompareTag("Zombie"))
    //     {
    //         Destroy(gameObject);
    //     } 
    //         
    // }

}
