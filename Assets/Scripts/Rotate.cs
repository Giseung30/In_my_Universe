using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Variable")]
    public float RotateSpeed; //카메라 회전속도
    void Update()
    {
        transform.Rotate(0f, 0f, RotateSpeed * Time.deltaTime); //Z축 방향으로 회전
    }
}