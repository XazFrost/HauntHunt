using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 3f; // �������� ����������� ����������
    public float changeDirectionTime = 2f; // ����� ����� ������� ���������� ������ �����������

    public Transform plane_down; // ������, ���� �������� ���������� �� ������ �������
    public Transform plane_up; // ������, ���� �������� ���������� �� ������ �������

    public Transform plane_left; // ������, ����� �������� ���������� �� ������ �������
    public Transform plane_right; // ������, ������ �������� ���������� �� ������ �������

    public Transform plane_forward; // ������, ����� �������� ���������� �� ������ �������
    public Transform plane_back; // ������, ������ �������� ���������� �� ������ �������

    private Vector3 direction; // ����������� �������� ����������
    private float elapsedTime; // ��������� �����

    void Start()
    {
        // ������ ��������� �����������
        direction = RandomVector3();
    }

    void Update()
    {
        // ���������� ���������� � �������� ����������� �� ��������� speed
        transform.Translate(direction * speed * Time.deltaTime);

        // ����������� ��������� �����
        elapsedTime += Time.deltaTime;

        // ���� ������ ���������� �������, ������ �����������
        if (elapsedTime >= changeDirectionTime)
        {
            // ������ ��������� �����������
            direction = RandomVector3();

            // ���������� ��������� �����
            elapsedTime = 0f;
        }

        // ������������ ���������� ����������, ����� ��� �� ������� ���� � ���� Plane
        float y = Mathf.Clamp(transform.position.y, plane_down.position.y, plane_up.position.y);
        float z = Mathf.Clamp(transform.position.z, plane_back.position.z, plane_forward.position.z);
        float x = Mathf.Clamp(transform.position.x, plane_left.position.x, plane_right.position.x);
        transform.position = new Vector3(x, y, z);

    }

    private Vector3 RandomVector3()
    {
        Vector3 direction;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        return direction;
    }
}
