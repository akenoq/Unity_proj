using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVision : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY; // Объявляем общедоступную переменную, которая появится в редакторе Unity.
	
	public float sensitivityHor = 9.0f; // Объявление общедоступной переменной для скорости вращения.
	public float sensitivityVert = 9.0f;
	
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;
	
	private float _rotationX = 0;

	void Start()
	{
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
		{
			body.freezeRotation = true;
		}
	}
	
	void Update() {
		if (axes == RotationAxes.MouseX)
		{
			// это поворот в горизонтальной плоскости
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
			// transform.Rotate(0, sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			// это поворот в вертикальной плоскости
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // фиксируем минимум и максимум поворота
			float rotationY = transform.localEulerAngles.y; // Сохраняем одинаковый угол поворота вокруг оси Y
															// (т. е. вращение в горизонтальной плоскости отсутствует)
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // Создаем новый вектор из сохраненных значений поворота
		}
		else {
			// это комбинированный поворот Сюда поместим код для комбинированного вращения
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // фиксируем минимум и максимум поворота
			float delta = Input.GetAxis("Mouse X") * sensitivityHor; // Приращение угла поворота через значение delta
			float rotationY = transform.localEulerAngles.y + delta; // Значение delta — это величина изменения угла поворота
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}
