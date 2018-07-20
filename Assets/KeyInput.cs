using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Key Input (WSAD)")] // добавляем скрипт в меню компонентов при добаулении
public class KeyInput : MonoBehaviour
{
	public float speed = 1.0f;
	public float gravity = -9.8f;

	private CharacterController _charController; // Переменная для ссылки на компонент CharacterController
	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController>(); // Доступ к другим компонентам, присоединенным к этому же объекту
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(0, speed, 0); // перемещение по оси Y
		float deltaX = Input.GetAxis("Horizontal") * speed; // "Horizontal" и "Vertical" — это дополнительные имена для сопоставления с клавиатурой
		float deltaZ = Input.GetAxis("Vertical") * speed;
		// transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed); // Ограничим движение по диагонали той же скоростью,
															// что и движение параллельно осям
		
		movement.y = gravity; // Используем значение переменной gravity вместо нуля
		
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement); // Вектор движения от локальных к глобальным координатам
		_charController.Move(movement); // Заставим этот вектор перемещать компонент CharacterController
	}
}
