using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurboSpeed : MonoBehaviour {

	void Start () {
		// делаю данный объект триггером
		gameObject.GetComponent<SphereCollider>().isTrigger = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		// other - объект, с которым произошло столкновение
		// пытаюсь получить компонент (скрипт) объекта
		KeyInput s = other.GetComponent<KeyInput>();
		// если у данного объекта есть компонент "yyy"
		if (s != null)
		{
			// вывод сообщения в консоль
			Debug.Log("HIT WITH BALL");
			// берем у игрока скрипт управления перемещением
			KeyInput keyInputPlayer = other.GetComponent<KeyInput>();
			keyInputPlayer.ReactOnTurboSpeed();
			Destroy(gameObject);
		}
	}
}