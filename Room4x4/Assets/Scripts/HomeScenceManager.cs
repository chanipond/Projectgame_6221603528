using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class HomeScenceManager : MonoBehaviour
{

	public void GoToPlayGround()
    {
	    SceneManager.LoadScene("Playground");  
    }
    
	public void ExitGame()
	{
		Application.Quit();  
	}

}
