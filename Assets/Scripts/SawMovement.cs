using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения объекта
    public float moveSpeed = 1f; // Скорость перемещения объекта вперед-назад
    public float leftLimit = -2f; // Левая крайняя точка по оси Z
    public float rightLimit = 2f; // Правая крайняя точка по оси Z
    public float pauseDuration = 2f; // Длительность задержки в секундах

    private float currentSpeed; // Текущая скорость перемещения
    private float currentZ; // Текущая позиция по оси Z
    private bool isMovingRight = true; // Флаг, указывающий направление движения

    private void Start()
    {
        currentSpeed = moveSpeed; // Изначально установим текущую скорость перемещения
        currentZ = transform.position.z; // Запоминаем начальную позицию по оси Z
        rightLimit += currentZ;
        leftLimit += currentZ;
    }

    private void Update()
    {
        // Вращение объекта вокруг оси Z
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Перемещение объекта вперед-назад по оси Z с крайними точками и задержкой
        if (isMovingRight && currentZ < rightLimit)
        {
            currentZ += currentSpeed * Time.deltaTime;
            if (currentZ >= rightLimit)
            {
                currentZ = rightLimit;
                StartCoroutine(Pause());
            }
        }
        else if (!isMovingRight && currentZ > leftLimit)
        {
            currentZ -= currentSpeed * Time.deltaTime;
            if (currentZ <= leftLimit)
            {
                currentZ = leftLimit;
                StartCoroutine(Pause());
            }
        }

        // Обновляем позицию объекта
        transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);
    }

    private IEnumerator Pause()
    {
        // Переключаем направление движения
        isMovingRight = !isMovingRight;
        // Устанавливаем текущую скорость перемещения в 0
        currentSpeed = 0f;
        // Ждем указанное время
        yield return new WaitForSeconds(pauseDuration);
        // Восстанавливаем текущую скорость перемещения
        currentSpeed = moveSpeed;
    }
}
