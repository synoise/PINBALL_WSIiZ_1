using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    

        
    public Transform player;  // Referencja do obiektu gracza
    public float moveSpeed = 1f;  // Prędkość ruchu przeciwnika
    public float rotationSpeed = 5f;  // Szybkość obracania przeciwnika

    void Update()
    {
        // Oblicz kierunek od przeciwnika do gracza
        Vector3 direction = player.position - transform.position;

        // Ustawienie y na 0, aby ograniczyć obrót tylko do osi Y
        direction.y = 0;

        // Oblicz docelowy obrót przeciwnika w stronę gracza
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Obracaj przeciwnika w stronę gracza za pomocą interpolacji Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Przesuwaj przeciwnika w kierunku gracza
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter2D " + col.collider.tag);

        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        } 
        
    }
}