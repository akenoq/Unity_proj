using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
    public float speed = 3.0f; // Объявление общедоступной переменной для скорости вращения.
    void Update()
    {
        transform.Rotate(0, speed, 0); // Поместите сюда команду Rotate, чтобы она запускалась в каждом кадре.
    }
}