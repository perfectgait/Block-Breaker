using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	
	private Ball ball;
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse() {
		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePosition = new Vector3 (Mathf.Clamp (mousePositionInBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);
		this.transform.position = paddlePosition;
	}
	
	void AutoPlay() {
		//		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 ballPostition = ball.transform.position;
		Vector3 paddlePosition = new Vector3 (Mathf.Clamp (ballPostition.x, 0.5f, 15.5f), this.transform.position.y, 0f);
		this.transform.position = paddlePosition;
	}
}
