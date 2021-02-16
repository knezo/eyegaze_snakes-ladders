using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSetup : MonoBehaviour
{
    
    public static int numberOfPlayers = 0;

    public GameObject ExitCanvas, RestartCanvas;


    // Start is called before the first frame update
    void Start(){

        try
        {
            ExitCanvas = GameObject.Find("ExitCanvas");
            RestartCanvas = GameObject.Find("RestartCanvas");

            ExitCanvas.gameObject.SetActive(false);
            RestartCanvas.gameObject.SetActive(false);
        }
        catch (System.Exception)
        {

        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // game restart
    public void RestartPressed(){
        RestartCanvas.gameObject.SetActive(true);
    }

    public void RestartNoPressed(){
        RestartCanvas.gameObject.SetActive(false);
    }

    public void Restart(){
            SceneManager.LoadScene(0);
        }

    // game exit
    public void ExitPressed(){
        ExitCanvas.gameObject.SetActive(true);
    }

    public void ExitNoPressed(){
        ExitCanvas.gameObject.SetActive(false);
    }

    public void Exit(){
        Application.Quit();
    }

    

    public void Button1Pressed(){
        numberOfPlayers = 1;
        SceneManager.LoadScene(1);
    }

    public void Button2Pressed(){
        numberOfPlayers = 2;
        SceneManager.LoadScene(1);
    }

    public void Button3Pressed(){
        numberOfPlayers = 3;
        SceneManager.LoadScene(1);
    }

    public void Button4Pressed(){
        numberOfPlayers = 4;
        SceneManager.LoadScene(1);
    }
}
