using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum open_type_ENUM {rotation_to_open, move_to_open} //��� ���������� (��������� ��� ������)
    public open_type_ENUM open_type;
    public enum door_axis_ENUM {x, y, z} //��� �������� ��� ��������
    public door_axis_ENUM door_axis;

    public bool only_open;          //����� ����� ������ ������� � ��� �� �����������
    public bool can_be_opened_now; //����� �� ������� � ������ ������ ��� ���������� �����-�� �������� ��� ���� ��� �� �� �������
    private bool is_open;           //���, ���� ��� �������
    public float open_speed = 150f; //�������� �������� �����
    public float open_angle = 140f; //���� �������� �����
    private float start_position;    //��������� ������� �����

    public AudioSource open_sound;
    public AudioSource not_openning_sound;

    private bool open_close_ON;

    public GameObject interaction_image;

    private void Start()
    {
        if(open_type ==  open_type_ENUM.move_to_open)
        {
            if (door_axis == door_axis_ENUM.x) start_position = transform.localPosition.x;
            else if(door_axis == door_axis_ENUM.y) start_position = transform.localPosition.y;
            else if(door_axis == door_axis_ENUM.z) start_position = transform.localPosition.z;
        }
        else
        {
            if (door_axis == door_axis_ENUM.x) start_position = transform.localEulerAngles.x;
            else if (door_axis == door_axis_ENUM.y) start_position = transform.localEulerAngles.y;
            else if (door_axis == door_axis_ENUM.z) start_position = transform.localEulerAngles.z;
        }
        
    }
}
