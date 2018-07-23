using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab; // переменная для хранения шаблона
	private GameObject[] _enemyArr = new GameObject[] {null, null, null, null, null}; // Закрытая переменная для слежения за экземпляром врага в сцене.
	void Update() { // Порождаем нового врага, только если враги в сцене отсутствуют.
		for (int i = 0; i < 5; i++)
		{
			if (_enemyArr[i] == null) {
				_enemyArr[i] = Instantiate(enemyPrefab) as GameObject; // Метод, копирующий объект-шаблон.
				_enemyArr[i].transform.position = new Vector3(i * 3, 1, i + 0);
				float angle = Random.Range(0, 360);
				_enemyArr[i].transform.Rotate(0, angle, 0);
			}
		}
	}
}