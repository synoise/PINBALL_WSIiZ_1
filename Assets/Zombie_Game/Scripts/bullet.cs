using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asesino_Zombie
{
    public class bullet : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(destroyBullet), 2f);
        }


        void destroyBullet()
        {
            Destroy(gameObject);
        }
    }
}