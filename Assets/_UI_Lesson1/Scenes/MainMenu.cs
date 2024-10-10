using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject UserName;

    // Start is called before the first frame update
    void Start()
    {
        
        UserName.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("PlayerName");
    }

}
