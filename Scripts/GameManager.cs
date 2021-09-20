
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Singleton class: GameManager

	public static GameManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	Camera cam;

	public Sausage sausage;

	public Trajectory trajectory;
	[SerializeField] float pushForce = 4f;
	public GameObject gameOverUI;
	public GameObject finishUI;
	public GameObject FailCube;
	public GameObject player;
	bool isDragging = false;
	
	
	

	public Transform playerTranform1;
	public Transform playerTranform2;
	public Transform playerTranform3;
	public Transform playerTranform4;
	public Transform playerTranform5;
	public Transform respawnPoint1;
	public Transform respawnPoint2;
	public Transform respawnPoint3;
	public Transform respawnPoint4;
	public Transform respawnPoint5;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

	//---------------------------------------
	void Start ()
	{
		cam = Camera.main;
		gameOverUI.SetActive(false);
		playerTranform1.transform.position = respawnPoint1.position;
		finishUI.SetActive(false);


	}

	void Update ()
	{
		
		
		if (Input.GetMouseButtonDown(0))
		{

			isDragging = true;
			OnDragStart();
		}

		
		if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			OnDragEnd ();
		}

		if (isDragging) {
			OnDrag ();
		}
		
		
	}
	
	public void Finish()
    {

		finishUI.SetActive(true);
	}

	public void GameOver()
    {

		gameOverUI.SetActive(true);
	}
	public void Respawn()
    {
		playerTranform1.transform.position = respawnPoint1.position;
		playerTranform2.transform.position = respawnPoint2.position;
		playerTranform3.transform.position = respawnPoint3.position;
		playerTranform4.transform.position = respawnPoint4.position;
		playerTranform5.transform.position = respawnPoint5.position;
		player.SetActive(true);
		
		gameOverUI.SetActive(false);
	}

    //-Drag--------------------------------------
    void OnDragStart ()
	{
		sausage.DesactivateRb();
		startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

		trajectory.Show ();
	}

	void OnDrag ()
	{
		endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
		distance = Vector2.Distance (startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine (startPoint, endPoint);


		trajectory.UpdateDots (sausage.pos, force);
	}

	void OnDragEnd ()
	{
		//push the ball
		sausage.ActivateRb ();

		sausage.Push (force*5);

		trajectory.Hide ();
	}

}
