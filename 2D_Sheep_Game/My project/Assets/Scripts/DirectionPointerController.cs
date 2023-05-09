using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointerController : MonoBehaviour
{
    public Transform target; // ������, � �������� ��������� ��������� �����������
    private Transform player; // ������ ������
    public float radius; // ���������� �� ������ �� ���������� �����������
    public float rotationSpeed; // �������� �������� ����������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // ��������� ��������� ������� ���������� �� �������� ���������� �� ������
        transform.position = player.position + Vector3.right * radius;
    }

    private void Update()
    {

        if (target == null || player == null) return;

        // ���������� ������� ����������� �� ������ � ����
        Vector2 directionToTarget = target.position - player.position;
        directionToTarget.Normalize();

        // ��������� �������� ������� ����������� ����������
        Vector2 directionToIndicator = transform.position - player.position;
        directionToIndicator.Normalize();

        // ���������� ���� ����� ������� ������������ ���������� � ������������ � ����
        float angleDiff = Vector2.SignedAngle(directionToIndicator, directionToTarget);

        // �������� ���������� ������ ������
        transform.RotateAround(player.position, Vector3.forward, angleDiff * rotationSpeed * Time.deltaTime);

        // ���������� ������� ����������, ����� �� �������� �� ������� � �������� ������
        Vector2 offset = transform.position - player.position;
        offset.Normalize();
        transform.position = (Vector2)player.position + offset * radius;

        // ���������� �������� ����������, ����� �������� �� ������ (���� ��� ��������� ����� ��������� ������ � ������ ���� ��������)
        float angle = Mathf.Atan2(transform.position.y - player.position.y, transform.position.x - player.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
