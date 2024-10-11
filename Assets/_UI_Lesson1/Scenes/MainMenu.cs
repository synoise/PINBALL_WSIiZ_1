using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject UserName;
    
    [SerializeField] private GameObject MaleAvatar;
    public GameObject FemaleAvatar;

    private string Gender;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        UserName.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("PlayerName");
        Gender = PlayerPrefs.GetString("PlayerGebder");
        Debug.Log("test"+ Gender);
        SetAvatar(Gender);
    }
    
    void SetAvatar(string sex)
    {
        Debug.Log("test"+ sex);
        MaleAvatar.SetActive(sex == "male");
        FemaleAvatar.SetActive(sex == "female");
    }

}
