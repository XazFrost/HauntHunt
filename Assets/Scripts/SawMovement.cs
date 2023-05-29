using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float rotationSpeed = 100f; // �������� �������� �������
    public float moveSpeed = 1f; // �������� ����������� ������� ������-�����
    public float leftLimit = -2f; // ����� ������� ����� �� ��� Z
    public float rightLimit = 2f; // ������ ������� ����� �� ��� Z
    public float pauseDuration = 2f; // ������������ �������� � ��������

    private float currentSpeed; // ������� �������� �����������
    private float currentZ; // ������� ������� �� ��� Z
    private bool isMovingRight = true; // ����, ����������� ����������� ��������

    private void Start()
    {
        currentSpeed = moveSpeed; // ���������� ��������� ������� �������� �����������
        currentZ = transform.position.z; // ���������� ��������� ������� �� ��� Z
        rightLimit += currentZ;
        leftLimit += currentZ;
    }

    private void Update()
    {
        // �������� ������� ������ ��� Z
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // ����������� ������� ������-����� �� ��� Z � �������� ������� � ���������
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

        // ��������� ������� �������
        transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);
    }

    private IEnumerator Pause()
    {
        // ����������� ����������� ��������
        isMovingRight = !isMovingRight;
        // ������������� ������� �������� ����������� � 0
        currentSpeed = 0f;
        // ���� ��������� �����
        yield return new WaitForSeconds(pauseDuration);
        // ��������������� ������� �������� �����������
        currentSpeed = moveSpeed;
    }
}
