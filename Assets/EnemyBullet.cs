using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;
	
	void Start () {
		// делаю данный объект триггером
		gameObject.GetComponent<SphereCollider>().isTrigger = true;
	}
	
	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) { // Проверяем, является ли этот другой объект объектом PlayerCharacter.
			player.Hurt(damage); // отнимаем у играка жизни
			Debug.Log("Player hit");
		}
		Destroy(this.gameObject);
	}
}
