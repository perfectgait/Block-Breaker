using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breakableCount++;
			Debug.Log(breakableCount);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
	}
	
	void OnCollisionExit2D (Collision2D collision) {
		if (isBreakable) {
			timesHit++;
			int maxHits = hitSprites.Length + 1;
			
			if (timesHit >= maxHits) {
				breakableCount--;
				Debug.Log(breakableCount);
				levelManager.BrickDestroyed();
				Destroy(gameObject);
			} else {
				LoadSprites();
			}
		}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO Remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
