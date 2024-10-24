using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    
    public float offset;
        
    public Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private Rigidbody2D Body;
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }
        
    void LateUpdate()
    {
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        
        Body.AddForce(new Vector2(targetPos.x, targetPos.y) * Time.deltaTime * 2.5f);
        // Body.AddRelativeForce(new Vector3(1, 0,0));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D " + col.collider.tag);

        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        } 
        
    }
}