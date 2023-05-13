using UnityEngine;

public class PkayerMovement : MonoBehaviour
{
    public float speed = 20, rush = 3;
    public AudioClip[] player_walk;
    public AudioClip player_attack, get_damage_sound;
    public AudioSource audio, attack_source;
    private Rigidbody2D rb;
    [Header("Attack")]
    public float damage = 0.5f;
    public float attack_distance = 5;
    private float DelayTimer, delayTime = 0.5f;
    private float rushTimer, delayRushTime = 2;
    public float RushScaleCurr;
    private float RushScaleMax = 1f;
    public GameObject maskObjectRush, maskAttack;

    private void Start()
    {
        RushScaleCurr = RushScaleMax;
        DelayTimer = delayTime;
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


    private void UpdateImage()
    {
        RectTransform rectTransform = maskObjectRush.GetComponent<RectTransform>();
        float right_max = -130f, right_min = 90;

        float percentage = RushScaleCurr / RushScaleMax;

        // ��������� �������� ����� right_max � right_min, ������� ������������� �������� percentage
        float right_value = Mathf.Lerp(right_max, right_min, percentage);

        // ������������� ����� �������� ��� ������ ������� rectTransform
        rectTransform.offsetMax = new Vector2(right_value, rectTransform.offsetMax.y);
    }

    private void UpdateImageDelay()
    {
        RectTransform rectTransform = maskAttack.GetComponent<RectTransform>();
        float right_max = -21f, right_min = 28f;

        float percentage = DelayTimer / delayTime;

        // ��������� �������� ����� right_max � right_min, ������� ������������� �������� percentage
        float right_value = Mathf.Lerp(right_max, right_min, percentage);

        // ������������� ����� �������� ��� ������ ������� rectTransform
        rectTransform.offsetMax = new Vector2(-right_value, rectTransform.offsetMax.y);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mouse_position(); 


            int layerMask = ~(1 << LayerMask.NameToLayer("UI"));

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition, layerMask); 

            if (hitCollider != null && hitCollider.CompareTag("Wolf") && Vector2.Distance(transform.position, hitCollider.transform.position) <= attack_distance) 
            {
                hitCollider.gameObject.GetComponent<WolfController>().GetDamage(damage); 
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
        UpdateImage();
        UpdateImageDelay();
        if (Time.deltaTime == 0)
        {
            audio.volume = 0;
            attack_source.volume = 0;
        }
        else
        {
            audio.volume = 0.2f;
            attack_source.volume = 1f;
        }

        DelayTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && DelayTimer<=0)
        {
            Attack();
            
            attack_source.clip = player_attack;
            attack_source.Play();
            DelayTimer = delayTime;
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
                if (RushScaleCurr > 0)
                {
                    rb.position += velocity * Time.deltaTime * speed * rush;
                    RushScaleCurr -= Time.deltaTime;
                }
                else
                {
                    if (RushScaleCurr < RushScaleMax)
                    {
                        RushScaleCurr += Time.deltaTime;
                    }
                }                

            }
            else
            {
                rb.position += velocity * speed * Time.deltaTime;
                if (RushScaleCurr < RushScaleMax)
                {
                    RushScaleCurr += Time.deltaTime;
                }
            }
            ;
        }
        else{
            audio.Stop();
            rb.position += velocity * speed * Time.deltaTime;
            if (RushScaleCurr < RushScaleMax)
            {
                RushScaleCurr += Time.deltaTime;
            }
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
