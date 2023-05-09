using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointerController : MonoBehaviour
{
    public Transform target; // ќбъект, к которому указывает индикатор направлени€
    private Transform player; // ќбъект игрока
    public float radius; // –ассто€ние от игрока до индикатора направлени€
    public float rotationSpeed; // —корость вращени€ индикатора

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // ”становка начальной позиции индикатора на заданное рассто€ние от игрока
        transform.position = player.position + Vector3.right * radius;
    }

    private void Update()
    {

        if (target == null || player == null) return;

        // ¬ычисление вектора направлени€ от игрока к цели
        Vector2 directionToTarget = target.position - player.position;
        directionToTarget.Normalize();

        // ѕолучение текущего вектора направлени€ индикатора
        Vector2 directionToIndicator = transform.position - player.position;
        directionToIndicator.Normalize();

        // ¬ычисление угла между текущим направлением индикатора и направлением к цели
        float angleDiff = Vector2.SignedAngle(directionToIndicator, directionToTarget);

        // ¬ращение индикатора вокруг игрока
        transform.RotateAround(player.position, Vector3.forward, angleDiff * rotationSpeed * Time.deltaTime);

        // ќбновление позиции индикатора, чтобы он следовал за игроком и сохран€л радиус
        Vector2 offset = transform.position - player.position;
        offset.Normalize();
        transform.position = (Vector2)player.position + offset * radius;

        // ќбновление поворота индикатора, чтобы смотреть на игрока (если ваш индикатор имеет отдельный спрайт и должен быть повернут)
        float angle = Mathf.Atan2(transform.position.y - player.position.y, transform.position.x - player.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
