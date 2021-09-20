
using UnityEngine;

public class Sausage : MonoBehaviour
{
	[SerializeField] Rigidbody rb;
	[SerializeField] SphereCollider col;
	public GameObject player;

	[HideInInspector] public Vector3 pos { get { return transform.position; } }


	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<SphereCollider>();
	}

	public void Push(Vector2 force)
	{
		rb.AddForce(force, ForceMode.Impulse);
	}
    void Update()
    {
		
    }

    public void ActivateRb()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;
	}
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "FailCube")
		{
			player.gameObject.SetActive(false);

			FindObjectOfType<GameManager>().GameOver();

		}
		if (collision.gameObject.tag == "FinishPlatform")
		{
			player.gameObject.SetActive(false);

			FindObjectOfType<GameManager>().Finish();

		}

		

	}
  
}
	
