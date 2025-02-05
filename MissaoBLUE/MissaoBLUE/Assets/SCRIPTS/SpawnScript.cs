﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
	public GameObject[] easyTrees;
	public GameObject[] hardTrees;
	public GameObject santuario;
	public Transform playerPosi;
	public float arraySize;
	public int xPos;
	public int yPos;
	public bool canSpawn;
	public static bool vitoria;
	public int minAraras;
	public bool scenario;
	public bool canStartCoroutine;
	public GameObject victoryPanel;

	public float difzPosition;
   

    Vector3 lastPosi;
    Vector3 nextPosi; 

    // Start is called before the first frame update
    void Start()
	{  // StartCoroutine(TempoDeVitoria());
		canSpawn = true;
		vitoria = false;
		
		if(scenario == true)
		{
           lastPosi = new Vector3(xPos, yPos, playerPosi.position.z - 30.0f);
		}

		else if(scenario == false)
		{
            lastPosi = new Vector3(xPos, yPos, playerPosi.position.z + 20.0f);
		}

		
        //lastPosi = new Vector3(xPos, yPos, playerPosi.position.z + 30.0f);
        nextPosi = new Vector3(xPos, yPos, 0);
		canStartCoroutine = true;

		for (int i = 0; i < 3; i++)
		{
			SpawnTrees(nextPosi, lastPosi);
		}

		//prefab.transform.position.x += 3;
		//Instantiate (prefab[0], lastPosi, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
		if(playerPosi.position.z >= lastPosi.z - 30 && Score.scoreValue < NumAraras.minAraras) // playerPosi.position.z < 280 //Input.GetButtonDown("Fire1") playerPosi.position.z >= lastPosi.z + 5
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnTrees(nextPosi, lastPosi);
                }
        
               	//Instantiate (prefab, new Vector3(30, 0, 0), Quaternion.identity);
        }

		else if(Score.scoreValue >= NumAraras.minAraras && scenario == false && canStartCoroutine == true) //playerPosi.position.z > 410
		{
			StartCoroutine(TempoDeVitoria());
			canStartCoroutine = false;
			//SceneManager.LoadScene("Vitoria");
		}
	//	else if (canSpawn == false)
	//	{
	//		Debug.Log("parabens vc ganhou");
	//	}
    }

    void SpawnTrees(Vector3 nextPosiii, Vector3 lastPosiii)
    {
        float randomNum = (Random.Range (0.0f, arraySize));
		//Debug.Log(Mathf.RoundToInt(randomNum));
        nextPosiii = new Vector3 (xPos, yPos, lastPosiii.z + 67);
        lastPosi = nextPosiii;
		Debug.Log(lastPosi.z);

    if(playerPosi.position.z < difzPosition){

		Instantiate (easyTrees[Mathf.RoundToInt(randomNum)], nextPosiii, Quaternion.identity);
	}

	else if(playerPosi.position.z > difzPosition)

		  Instantiate (hardTrees[Mathf.RoundToInt(randomNum)], nextPosiii, Quaternion.identity);
    }



	IEnumerator TempoDeVitoria()
	{
		//Debug.Log("santuarios");
		//Debug.Log(Score.scoreValue);

		//Instantiate (santuario, lastPosi, Quaternion.identity);

		//canSpawn = false;
		//vitoria = true;
        AraraCounter.totalAraras += AraraMovement.araraScore;
		NumAraras.canAdd = true;
		Debug.Log("pode adicionar");
		SceneManager.LoadScene("Vitoria");
		yield return new WaitForSeconds(1);
		//victoryPanel.SetActive(true);

	}
       
    
}
