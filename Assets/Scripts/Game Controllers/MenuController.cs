using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

	public static MenuController instance;

	[SerializeField]
	private GameObject[] birds;

	private bool isGreenBirdUnlocked, isRedBirdUnlocked;

	void Awake ()
	{
		MakeInstance ();
	}

	// Use this for initialization
	void Start ()
	{
		birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		CheckIfBirdsAreUnlocked ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		} 
	}

	void CheckIfBirdsAreUnlocked ()
	{
		
		isGreenBirdUnlocked = GameController.instance.IsGreenBirdUnlocked ();
		isRedBirdUnlocked = GameController.instance.IsRedBirdUnlocked ();
	}

	public void ChangeBird ()
	{
		if (GameController.instance.GetSelectedBird () == 0) {
			if (isGreenBirdUnlocked) {
				birds [0].SetActive (false);
				GameController.instance.SetSelectedBird (1);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			}
		} else if (GameController.instance.GetSelectedBird () == 1) {
			if (isRedBirdUnlocked) {
				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (2);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			} else {
				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (0);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			}
		} else if (GameController.instance.GetSelectedBird () == 2) {
			birds [2].SetActive (false);
			GameController.instance.SetSelectedBird (0);
			birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		}		
	}

}
