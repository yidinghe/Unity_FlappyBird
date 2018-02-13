﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{

	private GameObject[] pipeHolders;
	private float distance = 3.5f;
	private float lastPipesX;
	private float pipeMin = -1.5f;
	private float pipeMax = 2.4f;


	// Use this for initialization
	void Awake ()
	{
		pipeHolders = GameObject.FindGameObjectsWithTag ("PipeHolder");

		for (int i = 0; i < pipeHolders.Length; i++) {
			Vector3 temp = pipeHolders [i].transform.position;
			temp.y = Random.Range (pipeMin, pipeMax);
			pipeHolders [i].transform.position = temp;
		}

		lastPipesX = pipeHolders [0].transform.transform.position.x;

		for (int i = 1; i < pipeHolders.Length; i++) {
			if (lastPipesX < pipeHolders [i].transform.position.x) {
				lastPipesX = pipeHolders [i].transform.position.x;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "PipeHolder") {
			Vector3 temp = target.transform.position;
			temp.y = Random.Range (pipeMin, pipeMax);
			temp.x = lastPipesX + distance;
			target.transform.position = temp;
			lastPipesX = temp.x;
		}
	}
}
