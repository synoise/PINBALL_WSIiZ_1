using System;
using UnityEngine;
using Random = System.Random;

namespace theGame
{
    public class Pacman : MonoBehaviour
    {
        public GameObject player;

        public int calculate(int a, int b)
        {
            var c = a * b;//+ power(a+1);
            return c;
        }

        private int power(int a)
        {
            return a * a;
        }
        
        protected internal Array makeArrayRandom(int a)
        {
            Random random = new Random();
            
            int[] randomNumbers = new int[a];
            
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(1, 101); 
            }

            return randomNumbers;
        }
        
    }
    
}