using UnityEngine;

public class PkayerMovement : MonoBehaviour
{
    public float speed = 20, attack_distance = 5;
    public AudioClip[] player_walk;
    public AudioClip player_attack, get_damage_sound;
    public float damage = 0.5f;
    public AudioSource audio, attack_source;
    private Rigidbody2D rb;
    


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayDamage()
    {
        if (!attack_source.isPlaying)
        {
            attack_source.clip = get_damage_sound;
            attack_source.Play();
        }
        
    }


    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mouse_position(); // Получаем позицию мыши на сцене

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition); // Проверяем, есть ли коллайдер на этой позиции

            if (hitCollider != null && hitCollider.CompareTag("Wolf") && Vector2.Distance(transform.position, hitCollider.transform.position) <= attack_distance) // Если есть коллайдер и он имеет тег "Wolf"
            {
                hitCollider.gameObject.GetComponent<WolfController>().GetDamage(damage); // Вызываем метод GetDamage
            }
        }
    }

    private Vector2 mouse_position()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            
            attack_source.clip = player_attack;
            attack_source.Play();
            
        }

       
        rb = GetComponent<Rigidbody2D>();
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(hor, ver);

        if(velocity.magnitude != 0)
        {
            PlayRandomSound();
            if (Input.GetKey(KeyCode.LeftShift))
            {
               
                rb.position += velocity * Time.deltaTime * speed * 3;
            }
            else
            {
                rb.position += velocity * speed * Time.deltaTime;
            }
            ;
        }
        else{
            audio.Stop();
        }
    }//Update

    private void PlayRandomSound()
    {
        if (!audio.isPlaying)
        {
            int rand = Random.Range(0, player_walk.Length);
            audio.clip = player_walk[rand];
            audio.Play();
        }
       
    }



}//void
