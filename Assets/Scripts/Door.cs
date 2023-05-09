using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum open_type_ENUM {rotation_to_open, move_to_open} //тип открывания (применимо для ящиков)
    public open_type_ENUM open_type;
    public enum door_axis_ENUM {x, y, z} //ось вращения или движения
    public door_axis_ENUM door_axis;

    public bool only_open;          //дверь можно только открыть и она не закрывается
    public bool can_be_opened_now; //можно ли открыть в данный момент или необходимы какие-то действия для того что бы ее открыть
    private bool is_open;           //тру, если уже открыта
    public float open_speed = 150f; //Скорость открытия двери
    public float open_angle = 140f; //Угол открытия двери
    private float start_position;    //начальная позиция двери

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
