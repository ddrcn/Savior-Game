using UnityEngine;
using System.Collections;

/// <summary>
/// Управление камерой персонадажа
/// </summary>
public class CameraControl : MonoBehaviour
{
	//Инверсия по X
	public enum InversionX { Disabled = 0, Enabled = 1 };

	//Инверсия по Y
	public enum InversionY { Disabled = 0, Enabled = 1 };

	//Размытие
	public enum Smooth { Disabled = 0, Enabled = 1 };

	[Header("General")]
	public float sensitivity = 1; // чувствительность поворотов
	public float distance = 5; // расстояние между камерой и игроком
	public float height = 2.3f; // высота

	[Header("Over The Shoulder")]
	public float offsetPosition; // смещение камеры вправо или влево, 0 = центр

	[Header("Clamp Angle")]
	public float minY = 15f; // ограничение углов при наклоне
	public float maxY = 15f;

	[Header("Invert")] // инверсия осей
	public InversionX inversionX = InversionX.Disabled;
	public InversionY inversionY = InversionY.Disabled;

	[Header("Smooth Movement")]
	public Smooth smooth = Smooth.Enabled;
	public float speed = 8; // скорость сглаживания

	
	private float rotationY; // вращение по Y
	private int inversY, inversX;  // инверсия по осям

	private Transform player; //Ссылка на игрока

	/// <summary>
	/// Выполняется при первом обращении к скрипту, инициализирует ссылку на персонажа и устанавливает камере тег, 
	/// по которому к ней легко обращаться 
	/// </summary>
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		gameObject.tag = "MainCamera";
	}

	// проверяем, если есть на пути луча, от игрока до камеры, какое-либо препятствие (коллайдер)
	Vector3 PositionCorrection(Vector3 target, Vector3 position)
	{
		RaycastHit hit;
		Debug.DrawLine(target, position, Color.blue);
		if (Physics.Linecast(target, position, out hit))
		{
			float tempDistance = Vector3.Distance(target, hit.point);
			Vector3 pos = target - (transform.rotation * Vector3.forward * tempDistance);
			position = new Vector3(pos.x, position.y, pos.z); // сдвиг позиции в точку контакта
		}
		return position;
	}

	/// <summary>
	/// Отслеживание координат персонажа
	/// </summary>
	void LateUpdate()
	{
		player = CurrentPlayer.currentPlayer.transform;

		if (player)
		{
			if (inversionX == InversionX.Disabled) inversX = 1; else inversX = -1;
			if (inversionY == InversionY.Disabled) inversY = -1; else inversY = 1;

			// определяем точку на указанной дистанции от игрока
			Vector3 position = player.position - (transform.rotation * Vector3.forward * distance);
			position = position + (transform.rotation * Vector3.right * offsetPosition); // сдвиг по горизонтали
			position = new Vector3(position.x, player.position.y + height, position.z); // корректировка высоты
			position = PositionCorrection(player.position, position); // находим текущую позицию, относительно игрока

			// поворот камеры по оси Х
			rotationY = Mathf.Clamp(rotationY, -Mathf.Abs(minY), Mathf.Abs(maxY));
			transform.localEulerAngles = new Vector3(rotationY * inversY, transform.localEulerAngles.y, 0);

			// применяем сглаживаемость
			if (smooth == Smooth.Disabled) transform.position = position;
			else transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
		}

	}


	/// <summary>
	/// Поворот камеры пользователем
	/// </summary>
	/// <param name="axisX">по оси X</param>
	/// <param name="axisY">по оси Y</param>
	public void DoCam(float axisX, float axisY)
	{

		if (inversionX == InversionX.Disabled) inversX = 1; else inversX = -1;
		if (inversionY == InversionY.Disabled) inversY = -1; else inversY = 1;

		// вращение камеры вокруг игрока
		transform.RotateAround(player.position, Vector3.up, axisX * sensitivity * inversX);

		// определяем точку на указанной дистанции от игрока
		Vector3 position = player.position - (transform.rotation * Vector3.forward * distance);
		position = position + (transform.rotation * Vector3.right * offsetPosition); // сдвиг по горизонтали
		position = new Vector3(position.x, player.position.y + height, position.z); // корректировка высоты
		position = PositionCorrection(player.position, position); // находим текущую позицию, относительно игрока

		// поворот камеры по оси Х
		rotationY += axisY * sensitivity;
		rotationY = Mathf.Clamp(rotationY, -Mathf.Abs(minY), Mathf.Abs(maxY));
		transform.localEulerAngles = new Vector3(rotationY * inversY, transform.localEulerAngles.y, 0);

		if (smooth == Smooth.Disabled) transform.position = position;
		else transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);

	}
}