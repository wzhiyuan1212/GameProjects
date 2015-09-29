using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreController : MonoBehaviour {

	private int _score = 0;

	// Use this for initialization
	void Start () {
		GameObject.Find ("Bird").GetComponent<BirdController> ().BirdScoreAdd += ScoreAdd;

		return;
	}
	
	private void ScoreAdd()
	{
		++_score;
		transform.GetComponent<Text> ().text = _score.ToString ();

		return;
	}


}
