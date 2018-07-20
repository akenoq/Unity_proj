using UnityEngine;
using System.Collections;
public class RayBullet : MonoBehaviour {
	private Camera _camera;
	void Start() {
		_camera = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked; // Скрываем указатель мыши
		Cursor.visible = false; // в центре экрана.
	}
	
	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.color = Color.green;
		GUI.Label(new Rect(posX, posY, size, size), "*"); // Команда GUI.Label() отображает на экране символ.
	}
		
	void Update() { // Эта функция по большей части содержит знакомый нам код бросания луча из листинга 3.1.
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(
				_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				StartCoroutine(SphereIndicator(hit.point)); // Запуск сопрограммы в ответ на попадание.
			}
		}
	}
	private IEnumerator SphereIndicator(Vector3 pos) { // Сопрограммы пользуются функциями IEnumerator.
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;
		yield return new WaitForSeconds(1); // Ключевое слово yield указывает сопрограмме, когда следует остановиться.
			Destroy(sphere); // Удаляем этот GameObject и очищаем память.
	}
}