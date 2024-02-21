using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activeWristUI = true;
    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

    public void PauseMenuPressed(InputAction.CallbackContext context){
        if(context.performed)
        DisplayWristUI();
    }

    public void DisplayWristUI(){
        if(activeWristUI){
            wristUI.SetActive(false);
            activeWristUI=false;
        }
        else if (!activeWristUI){
            wristUI.SetActive(true);
            activeWristUI=true;
        }
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

     public void ExitGame(){
        Application.Quit();
    }


    
}
