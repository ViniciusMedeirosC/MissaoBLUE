﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AraraMovement : MonoBehaviour
{ 
	public int araraScore;
	public float speed;
	private Rigidbody rb;
	public GameObject gameOver;
	public static int life;
	public GameObject[] lifes;
	//public GameObject vitoria;

	
    // Start is called before the first frame update
    void Start()
    {
		
		life = 3;
		araraScore = 0;
		//gameOver.SetActive(false);
		//vitoria.SetActive(false);
		rb = GetComponent<Rigidbody>();
		
		//rb.velocity = Camera.main.transform.forward + new Vector3(0,0,40);
    }

    // Update is called once per frame
    void Update()
    {

		//transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
	
		//rb.MovePosition(transform.position + (transform.position + (Camera.main.transform.forward * Time.deltaTime)));
       // Debug.Log(rb.velocity);
		//rb.velocity = Camera.main.transform.forward * speed * Time.deltaTime;
		// if (life == 3) {
		// 	lifes[0].SetActive(true);
		// 	lifes[1].SetActive(false);
		// 	lifes[2].SetActive(false);
		// 	lifes[3].SetActive(false);
		// }

		// else if (life == 2) {
		// 	lifes[0].SetActive(false);
		// 	lifes[1].SetActive(true);
		// 	lifes[2].SetActive(false);
		// 	lifes[3].SetActive(false);
		// }

		// else if (life == 1) {
		// 	lifes[0].SetActive(false);
		// 	lifes[1].SetActive(false);
		// 	lifes[2].SetActive(true);
		// 	lifes[3].SetActive(false);
		// }

		// else if (life == 0) {
		// 	lifes[0].SetActive(false);
		// 	lifes[1].SetActive(false);
		// 	lifes[2].SetActive(false);
		// 	lifes[3].SetActive(true);
		// }

		//if (SpawnScript.vitoria) {
		//	vitoria.SetActive(true);
		//}
    }

	void FixedUpdate()
	{
		rb.MovePosition(transform.position + Camera.main.transform.forward * speed * Time.deltaTime);
		//rb.MovePosition(transform.position + (transform.position + (Camera.main.transform.forward * Time.deltaTime)));
	}

    void OnCollisionEnter (Collision col)
	{

         Debug.Log(col.gameObject.name);

		if (col.gameObject.CompareTag("Obstacle")) {
			rb.useGravity = true;
			speed = 0;
		    SceneManager.LoadScene("Derrota");
		}

		else if (col.gameObject.CompareTag("Fire Tree")) {
			Debug.Log("morreuuu");
			rb.useGravity = true;
			speed = 0;
			SceneManager.LoadScene("Derrota");
		}
			

		else if (col.gameObject.CompareTag("Normal Tree")) {
			life = life - 1;
			Debug.Log(life);

			if (life == 0) {
				Debug.Log("morreuuu");
				rb.useGravity = true;
				speed = 0;
				SceneManager.LoadScene("Derrota");
			}
		}

		else if (col.gameObject.CompareTag("Fire")) {
			rb.useGravity = true;
			speed = 0;
			SceneManager.LoadScene("Derrota");
		}

		else if (col.gameObject.CompareTag ("Baby")){

			Score.scoreValue += 1;
			col.gameObject.SetActive(false);
		}

		//else if (life == 0) {
		//	Debug.Log("morreuuu");
		//	rb.useGravity = true;
		//	speed = 0;
		//	SceneManager.LoadScene("Derrota");
		//}
	}
}
