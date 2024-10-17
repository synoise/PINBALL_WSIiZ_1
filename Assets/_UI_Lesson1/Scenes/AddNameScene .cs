using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using TMPro;

 // using UnityEngine;

// namespace Scenes.Scripts
// {
    public class AddNameScene : MonoBehaviour
    {
        #region Components
        public GameObject AprooveButton;
        public GameObject MaleAvatar;
        public GameObject FemaleAvatar;
        // public TMP_InputField  UserNameInput;
        public GameObject  UserNameInput;
        public Toggle FemaleToggle;
        public Toggle MaleToggle;

        #endregion Components

        private Regex regex = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ]{3,25}$");
        //private string message = "test message";
        public string PlayerName = "";
        public string Gender;
        public bool ClearPrefs;
        public Text female;
        public Text male;

        // #region Init

        void Start()
        {



            PlayerPrefs.DeleteAll(); // TODO remove it.

            PrepareView();
            
          
        }
        
//     
//
//         private void GetData()
//         {
//             PlayerName = LoadData(Prefs.PlayerName);
//             Gender = LoadData(Prefs.Gender);
//         }
//
         private void PrepareView()
         {
             ActiveButton(false);

             if (string.IsNullOrEmpty(Gender))
                 Gender = "female";

             if (Gender == "female")
                 FemaleToggle.isOn = true;
             else
                 MaleToggle.isOn = true;

             ToogleGender(Gender);

             // UserNameInput.text = PlayerName;
            UserNameInput.GetComponent<TMP_InputField>().text = PlayerName;
             Validation();
         }
        
        

        public void UserTextChanged()
        {
            PlayerName = UserNameInput.GetComponent<TMP_InputField>().text;
            Debug.Log(UserNameInput);
            Validation();
        }

        void Validation()
        {
            if (regex.IsMatch(PlayerName) && Gender != "")
                ActiveButton(true);
            else
                ActiveButton(false);
        }

        void ActiveButton(bool state)
        {
            Debug.Log(state);
             //AprooveButton.interactable = state;
             AprooveButton.gameObject.SetActive(state);
        }

        public void ToogleGender(string sex)
        {
            SetAvatar(sex);
            Gender = sex;
            
            if (Gender != "male")
            {
                male.fontStyle = FontStyle.Normal;
                female.fontStyle = FontStyle.Bold;
            }else            {
                male.fontStyle = FontStyle.Bold;
                female.fontStyle = FontStyle.Normal;
            }
        }

        void SetAvatar(string sex)
        {
            MaleAvatar.SetActive(sex == "male");
            FemaleAvatar.SetActive(sex == "female");
        }

        public void PlayGame()
        {
           // SaveData(Prefs.PlayerName, PlayerName);
           // SaveData(Prefs.Gender, Gender);
           // SaveData(Prefs.Progress, "0");
           PlayerPrefs.SetString("PlayerName", PlayerName);
           PlayerPrefs.SetString("PlayerGebder", Gender);
           PlayerPrefs.Save();
           
            SceneManager.LoadScene("MainMenu");


        }
    }
// }