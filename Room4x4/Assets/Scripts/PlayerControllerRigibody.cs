using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigibody : MonoBehaviour
{
	public PlaygroundSceneManager manager;
	
	Rigidbody rb;
	public float speed = 2f;
	float newRotY = 0;
	public float rotspeed = 30f;
	public float JumpPower = 2f;
	public GameObject prefabBullet;
	public GameObject gunposition;
	public float gunPower = 15f;
	public float gunCooldown = 1f;
	float gunCooldownCount = 0;
	public bool hasGun = false;
	public int bulletCount = 0;
	public int coinCount = 0;
	public AudioSource audioCoin;
	public AudioSource audioFire;
    // Start is called before the first frame update
    void Start()
    {
	    rb = GetComponent<Rigidbody>();
	    
	    if(manager == null)
	    {
	    	manager = FindObjectOfType<PlaygroundSceneManager>();
	    }
    }
    
    

    // Update is called once per frame
    void Update()
	{
		/*
	    if(Input.GetKey(KeyCode.UpArrow))
	    {
	    	rb.AddForce(new Vector3(0,0,-speed),ForceMode.VelocityChange); 
	    	newRotY = 180;
	    }
	    if(Input.GetKey(KeyCode.DownArrow))
	    {
	    	rb.AddForce(new Vector3(0,0,speed),ForceMode.VelocityChange); 
	    	newRotY = 0;
	    }
	    if(Input.GetKey(KeyCode.LeftArrow))
	    {
	    	rb.AddForce(new Vector3(-speed,0,0),ForceMode.VelocityChange);
	    	newRotY = -90;
	    }
	    if(Input.GetKey(KeyCode.RightArrow))
	    {
	    	rb.AddForce(new Vector3(speed,0,0),ForceMode.VelocityChange); 
	    	newRotY = 90;
	    }
	    if(Input.GetButtonDown("Jump"))
	    {
	    	rb.AddForce(0,JumpPower,0,ForceMode.Impulse);
	    }
	    */
	    float horizontal = Input.GetAxis("Horizontal");
	    float vertical = Input.GetAxis("Vertical");
		rb.AddForce(horizontal,0,vertical,ForceMode.VelocityChange ); 
		if(horizontal > 0)
		{
			newRotY = 90;
		}else if(horizontal < 0)
		{
			newRotY = -90;
		}
		if(vertical  > 0)
		{
			newRotY = 0;
		}else if(vertical  < 0)
		{
			newRotY = 180;
		}
	    
		if(Input.GetButtonDown("Fire1") && 
		(bulletCount > 0) && 
		(gunCooldownCount >= gunCooldown ))
	    {
	    	gunCooldownCount = 0; 
			bulletCount--;
			manager.SetTextBullet(bulletCount); //บอก manager ให้แสดงจำนวนกระสุน
	    	GameObject bullet = Instantiate(prefabBullet,gunposition.transform.position,gunposition.transform.rotation);
		    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower, ForceMode.Impulse);    
			Destroy(bullet, 3f ); 
			manager.SetTextBullet(bulletCount);
			audioFire.Play();
		    //Rigidbody bRb = bullet.GetComponent<Rigidbody>(); 
	    	//bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse); 
	    }
	    gunCooldownCount += Time.fixedDeltaTime; 
	    
	    transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,newRotY,0),
		    transform.rotation,Time.deltaTime * rotspeed);  
    }
	
	private void OnTriggerEnter(Collider other)
	{
		print(other.gameObject.name);
		if(other.gameObject.tag == "Collectable")
		{
			Destroy(other.gameObject);
			coinCount++; 
			manager.SetTextCoin(coinCount);
			audioCoin.Play();
		}
		
		if(other.gameObject.name == "Gun Trigger")
		{
			hasGun = true;
			bulletCount += 10;
			Destroy(other.gameObject); 
			
		}
	}
}


