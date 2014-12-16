using UnityEngine;
using System.Collections;

public class BarrierController : MonoBehaviour {
  public GameObject[] rotateMeArr;
  private float angle = 0.0f;
  public float minAngle = 0.0f;
  public float maxAngle = 90.0f;
  public float speed = 25f;
  public bool open = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(open){
			angle += Time.deltaTime * speed;
		} else {
			angle -= Time.deltaTime * speed;
		}
		angle = angle >= maxAngle ? maxAngle : angle <= minAngle ? minAngle : angle;
		Vector3 rot = rotateMeArr[0].transform.localEulerAngles;
		rot.x = angle;
		rotateMeArr[0].transform.localEulerAngles = rot;
	}
}