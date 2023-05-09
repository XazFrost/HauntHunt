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
    public float open_speed = 150f; //Скорость открытия двери/ящика
    public float open_dist = 140f; //Угол открытия или расстрояния двери/ящика
    private float start_position;    //начальная позиция двери/ящика

    public AudioSource open_sound;
    public AudioSource close_sound;
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

    private void Update()
    {
        if(open_close_ON)
        {
            if(is_open)         //открываем дверь
            {
                if(open_type == open_type_ENUM.move_to_open)        //движение
                {
                    if(door_axis == door_axis_ENUM.x)
                    {
                        float posX = Mathf.MoveTowards(transform.localPosition.x, start_position + open_dist, open_speed + Time.deltaTime);
                        transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
                        if (transform.localPosition.x == start_position + open_dist) Stop_Open_Close();
                    }
                    else if(door_axis == door_axis_ENUM.y)
                    {
                        float posY = Mathf.MoveTowards(transform.localPosition.y, start_position + open_dist, open_speed + Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
                        if (transform.localPosition.y == start_position + open_dist) Stop_Open_Close();
                    }
                    else if(door_axis == door_axis_ENUM.z)
                    {
                        float posZ = Mathf.MoveTowards(transform.localPosition.z, start_position + open_dist, open_speed + Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.z, posZ);
                        if (transform.localPosition.z == start_position + open_dist) Stop_Open_Close();
                    }
                } 
                else    //вращение
                {
                    if (door_axis == door_axis_ENUM.x)
                    {
                        float angleX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, start_position + open_dist, open_speed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(angleX, 0, 0);
                        if (transform.localEulerAngles.x == start_position + open_dist) Stop_Open_Close();
                    }
                    else if (door_axis == door_axis_ENUM.y)
                    {
                        float angleY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, start_position + open_dist, open_speed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(0, angleY, 0);
                        if (transform.localEulerAngles.y == start_position + open_dist) Stop_Open_Close();
                    }
                    else if (door_axis == door_axis_ENUM.z)
                    {
                        float angleZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, start_position + open_dist, open_speed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(0, 0, angleZ);
                        if (transform.localEulerAngles.z == start_position + open_dist) Stop_Open_Close();
                    }
                }  
            }
            else   //закрываем дверь
            {
                if(open_type == open_type_ENUM.move_to_open)
                {
                    if(door_axis == door_axis_ENUM.x)
                    {
                        float posX = Mathf.MoveTowards(transform.localPosition.x, start_position, open_speed + Time.deltaTime);
                        transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
                        if (transform.localPosition.x == start_position + open_dist) Stop_Open_Close();
                    }
                    else if (door_axis == door_axis_ENUM.y)
                    {
                        float posY = Mathf.MoveTowards(transform.localPosition.y, start_position, open_speed + Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
                        if (transform.localPosition.y == start_position + open_dist) Stop_Open_Close();
                    }
                    else if (door_axis == door_axis_ENUM.z)
                    {
                        float posZ = Mathf.MoveTowards(transform.localPosition.z, start_position, open_speed + Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.z, posZ);
                        if (transform.localPosition.z == start_position + open_dist) Stop_Open_Close();
                    }
                }
                else
                {
                    if (door_axis == door_axis_ENUM.x)
                    {
                        float angleX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, start_position, open_speed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(angleX, 0, 0);
                        if (transform.localEulerAngles.x == start_position + open_dist) Stop_Open_Close();
                    }
                    else if (door_axis == door_axis_ENUM.y)
                    {
                        float angleY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, start_position, open_speed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(0, angleY, 0);
                        if (transform.localEulerAngles.y == start_position + open_dist) Stop_Open_Close();
                    }
                    else if (door_axis == door_axis_ENUM.z)
                    {
                        float angleZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, start_position, open_speed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(0, 0, angleZ);
                        if (transform.localEulerAngles.z == start_position + open_dist) Stop_Open_Close();
                    }
                }
            }    
        }
    }

    public void Open_Close()
    {
        if(can_be_opened_now)
        {
            open_close_ON = true;       //Идет процесс открытия двери
            if (is_open) is_open = false;
            else
            {
                is_open = true;
                if (open_sound) open_sound.Play();
            }

        }
        else
        {
            if (not_openning_sound) not_openning_sound.Play();
            print("ЗАКРЫТО");
        }
    }

    void Stop_Open_Close()
    {
        open_close_ON = false;
        if (open_sound) open_sound.Stop();
        if (close_sound && !is_open) close_sound.Play();
    }

    private void OnMouseEnter()
    {
        if (gameObject.tag == "Door") interaction_image.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (gameObject.tag == "Door") interaction_image.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "Door")
        {
            Open_Close();
        }
    }
}
