using UnityEngine;
using System.Collections;

public class Tube : MonoBehaviour {
	public Transform TubeUp;
	public Transform TubeDown;
	public Transform LiveSpace;

	private const float TUBE_MOVE_SPEED = 1f;

	private PanelTubeManager _tubeManager;

	private bool _gameOver = false;

	// Use this for initialization
	void Start () {
		if (_tubeManager == null) 
		{
			_tubeManager = GameObject.Find("BackGrondPanel").transform.GetComponent<PanelTubeManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_gameOver) 
		{
			return;
		}

		Vector3 position = transform.localPosition;
		position.x -= TUBE_MOVE_SPEED;
		transform.localPosition = position;

		if (transform.localPosition.x < -20f) 
		{
			_tubeManager.GenerateTube();
			GameObject.Destroy(gameObject);

			return;
		}

		return;
	}

	public void Init(PanelTubeManager tubeManager)
	{
		_tubeManager = tubeManager;
		BirdController birdController = GameObject.Find ("Bird").transform.GetComponent<BirdController> ();
		birdController.BirdDie += OnGameOverMessage;

		return;
	}

	private void OnGameOverMessage()
	{
		_gameOver = true;
		BirdController birdController = GameObject.Find ("Bird").transform.GetComponent<BirdController> ();
		birdController.BirdDie -= OnGameOverMessage;
		return;
	}
}
