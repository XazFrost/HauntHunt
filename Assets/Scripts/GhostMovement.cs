using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 3f; // скорость перемещения приведения
    public float changeDirectionTime = 2f; // время через которое приведение сменит направление

    public Transform plane_down; // объект, ниже которого приведение не должно улетать
    public Transform plane_up; // объект, выше которого приведение не должно улетать

    public Transform plane_left; // объект, левее которого приведение не должно улетать
    public Transform plane_right; // объект, правее которого приведение не должно улетать

    public Transform plane_forward; // объект, левее которого приведение не должно улетать
    public Transform plane_back; // объект, правее которого приведение не должно улетать

    private Vector2 direction; // направление движения приведения
    private float elapsedTime; // прошедшее время

    void Start()
    {
        // задаем случайное направление
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize(); // нормализуем вектор направления
    }

    void Update()
    {
        // перемещаем приведение в заданном направлении со скоростью speed
        transform.Translate(direction * speed * Time.deltaTime);

        // увеличиваем прошедшее время
        elapsedTime += Time.deltaTime;

        // если прошло достаточно времени, меняем направление
        if (elapsedTime >= changeDirectionTime)
        {
            // задаем случайное направление
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            direction.Normalize(); // нормализуем вектор направления

            // сбрасываем прошедшее время
            elapsedTime = 0f;
        }

        // ограничиваем координаты приведения, чтобы оно не улетало ниже и выше Plane
        float y = Mathf.Clamp(transform.position.y, plane_down.position.y, plane_up.position.y);
        float z = Mathf.Clamp(transform.position.z, plane_back.position.z, plane_forward.position.z);
        float x = Mathf.Clamp(transform.position.x, plane_left.position.x, plane_right.position.x);
        transform.position = new Vector3(x, y, z);

    }
}
