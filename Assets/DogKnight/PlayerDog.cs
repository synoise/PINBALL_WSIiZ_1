using UnityEngine;

public class PlayerDog : MonoBehaviour
{
    
    private Camera cam;
    private Transform my;
    private Rigidbody body;
    private Vector3 _input;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;

    void Start()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Look();
    }
    private void Look()
    {
        // Pobierz pozycję kursora w przestrzeni świata z uwzględnieniem dystansu kamery do gracza
        float camDis = cam.transform.position.y - my.position.y;
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        // Oblicz kierunek od gracza do kursora
        Vector3 direction = mousePos - my.position;

        // Ustawienie y na 0, aby ograniczyć obrót tylko do osi poziomej
        direction.y = 0;

        // Oblicz docelowy obrót (kierunek w pełnym 360 stopni)
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Ustaw obrót za pomocą interpolacji Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }
    

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter2D " + col.collider.tag);

        if (col.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }
}