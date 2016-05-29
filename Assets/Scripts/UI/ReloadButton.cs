using UnityEngine;
using System.Collections;

public class ReloadButton : MonoBehaviour {

	[SerializeField] private GameObject downArrow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<MeshRenderer> ().isVisible)
			downArrow.SetActive (false);
		else
			downArrow.SetActive (true);
	}
}
