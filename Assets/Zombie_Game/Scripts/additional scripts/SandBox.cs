using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class SandBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject clonedFloor;
    [SerializeField] private Transform Parent;
    [SerializeField] private Transform Player;
    
    void Start()
    {
        AddFlor( 1, -1);
        AddFlor( 1, 0);
        AddFlor( 1, 1);
        
        AddFlor( 0, 1);
        AddFlor( 0, -1);
        
        AddFlor( -1, -1);
        AddFlor( -1, 0);
        AddFlor( -1, 1);
    }
    private void AddFlor(int x, int z)
    {
        Vector3 pos =  new Vector3(clonedFloor.transform.position.x + x* 100.0f,.0f,clonedFloor.transform.position.z + z* 100.0f);
        // GameObject _bullet = 
            Instantiate(clonedFloor, pos,  clonedFloor.transform.rotation, Parent);
            
    }
    
    float x =0.0f;
    float z =0.0f;
    void Update()
    {
        // Debug.Log(Parent.position.x +" | "+ Player.position.x +" | "+   Mathf.Round(Player.position.x /100));
        
        x =  100 * Mathf.Round(Player.position.x / 100) ;
        z =  100 * Mathf.Round(Player.position.z / 100) ;
        Parent.position = new Vector3(x,.0f,z);
    }
}
