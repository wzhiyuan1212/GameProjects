using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections;

public delegate void EventHandler(object sender);

public class PanelTubeManager : MonoBehaviour {
	public Transform TubePanel;

	private const string TUBE_PREFABE_PATH_PREFIX = "Tube/Tube_";
	private const float TUBE_INIT_POSITION = 825f;

	void Start()
	{
		GameObject.Find ("Bird").GetComponent<BirdController> ().BirdDie += OnGameOver;

		GenerateTube (TUBE_INIT_POSITION);
		GenerateTube (400f);
		GenerateTube (-200f);

		return;
	}


	private void GenerateTube(float initPosition)
	{
		int tubeIndex = Random.Range (1, 5);
		GameObject tubeGO = GameObject.Instantiate<GameObject> (Resources.Load<GameObject>(TUBE_PREFABE_PATH_PREFIX + tubeIndex.ToString()));
		tubeGO.transform.SetParent (TubePanel, false);
		tubeGO.transform.GetComponent<Tube> ().Init (this);
		Vector3 tubePosition = tubeGO.transform.position;
		tubePosition.x = initPosition;
		tubeGO.transform.position = tubePosition;

		//Debug.Log (tubeGO.transform.position);
		//Debug.Break ();

		return;
	}

	public void GenerateTube()
	{
		GenerateTube (TUBE_INIT_POSITION);

		return;
	}

	private void OnGameOver()
	{
		GameObject.Find ("Bird").GetComponent<BirdController> ().BirdDie -= OnGameOver;
		GameObject gameOverDialogGO = GameObject.Instantiate<GameObject> (Resources.Load<GameObject>("GameOverDialog"));
		gameOverDialogGO.transform.SetParent (transform, false);

		return;
	}

}
