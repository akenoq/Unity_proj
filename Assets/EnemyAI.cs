using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	
	private bool _aliveFlag = true;
	
	void Start() {
		_aliveFlag = true; // Инициализация этой переменной.
	}
	
	void Update() {
		if (_aliveFlag)
		{
			transform.Translate(0, 0, speed * Time.deltaTime);
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit)) {
				// проверка препятствий в радиусе
				if (hit.distance < obstacleRange) {
					float angle = Random.Range(-110, 110);
					transform.Rotate(0, angle, 0);
				}
			}
		}
	}
	
	public void SetAlive(bool alive) { // Открытый метод, позволяющий внешнему коду воздействовать на «живое» состояние
		_aliveFlag = alive;
	}
}
