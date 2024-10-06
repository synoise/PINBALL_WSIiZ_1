using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballGame : MonoBehaviour
{
    public float torqueForce;
    [SerializeField] private GameObject userInterface;
    [SerializeField] private Rigidbody2D leftFlipperRigid;
    [SerializeField] private Rigidbody2D rightFlipperRigid;
    public GameObject ballPrefab;
    public GameObject ballPoint;
    
    private List<GameObject> listBall = new List<GameObject>();

    // void Start() { }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseInput = Input.mousePosition;
            //Flipping right
            if (mouseInput.x >= Screen.width / 2f)
            {
                AddTorque(rightFlipperRigid, -torqueForce);
            }

            //Flipping left
            if (mouseInput.x < Screen.width / 2f)
            {
                AddTorque(leftFlipperRigid, torqueForce);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseHolding = Input.mousePosition;

            //Holding right
            if (mouseHolding.x >= Screen.width / 2f)
            {
                AddTorque(rightFlipperRigid, -torqueForce);
            }

            //Holdding left
            if (mouseHolding.x < Screen.width / 2f)
            {
                AddTorque(leftFlipperRigid, torqueForce);
            }
        }
        
    }
    
    void AddTorque(Rigidbody2D rigid, float force)
    {
        rigid.AddTorque(force);
    }
    
    public void HandlePlayButton()
    {
        userInterface.SetActive(false);
        CreateBall();
    }
    
    public void CreateBall()
    {
        GameObject ball = Instantiate(ballPrefab, ballPoint.transform.position, Quaternion.identity) as GameObject;
        listBall.Add(ball);
    }
    
}
