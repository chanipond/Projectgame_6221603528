using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpController : MonoBehaviour
{
	public string sceneName;
	public AudioSource warpSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Invoke("LoadNextScene",1);
			if(warpSound != null)
				warpSound.Play();
		}
	}
	
	void LoadNextScene()
	{
		SceneManager.LoadScene(sceneName);
	}
}
