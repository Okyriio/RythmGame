using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(2);
    }
    
    public void GoToEasy()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToHard()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
