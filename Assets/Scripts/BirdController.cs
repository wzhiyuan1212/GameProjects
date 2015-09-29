using UnityEngine;
using System.Collections;

public delegate void BirdEvent();

public class BirdController : MonoBehaviour {

	private const float BIRD_MOVE_SPEED = 10f;
	private const float BIRD_DROP_SPEED = 1.5f;
	private const float BIRD_UP_SPEED = 35f;

	private const string LIVE_SPACE_GAME_OBJECT_NAME = "LiveSpace";

	public event BirdEvent BirdDie;
	public event BirdEvent BirdScoreAdd;

	private bool _birdDie = false;

	public Animator birdAnimator;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_birdDie) 
		{
			return;
		}

		AddBirdPositionX (-BIRD_DROP_SPEED);

		KeyBoardEventProcess ();

		return;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		GameObject colliderGO = collision.gameObject;
		Debug.Log (colliderGO.name);
		if (colliderGO.name != LIVE_SPACE_GAME_OBJECT_NAME) 
		{
			if (BirdDie != null)
			{
				_birdDie = true;
				BirdDie();
			}
		}

		return;
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		GameObject colliderGO = collision.gameObject;
		if (colliderGO.name == LIVE_SPACE_GAME_OBJECT_NAME) 
		{
			if (BirdScoreAdd != null)
			{
				BirdScoreAdd();
			}
		}

		return;
	}


	private void KeyBoardEventProcess()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			birdAnimator.SetTrigger("jump");
			AddBirdPositionX(BIRD_UP_SPEED);
		}

		return;
	}

	private void AddBirdPositionX(float deltaX)
	{
		Vector3 newPosition = transform.localPosition;
		newPosition.y += deltaX;
		transform.localPosition = newPosition;

		return;
	}

}
