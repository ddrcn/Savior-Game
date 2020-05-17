using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Движение персонажа
/// </summary>
public class Move : MonoBehaviour
{

    public float speedMove; //Скорость персонажа

    private float gravityForce; //Гравитация
    private Vector3 moveVector; //Направление движения
    public Image runButton; //ссылка на кнопку ходбы
    public bool pressed; //нажата ли кнопка ходьбы
    public float jumpPower; //сила прыжка
    public bool inTeleporting; //находится ли персонаж в состоянии телепортирования
    private CharacterController ch_controller; // ссылка на контроллер персонажа
    private Animator animator; //ссылка на аниматор

    /// <summary>
    /// Инициализаци переменных
    /// </summary>
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        pressed = false;
    }

    /// <summary>
    /// Отслеживание состояний персонажа каждый кадр
    /// </summary>
    void Update()
    {
        if(!inTeleporting)
            CharacterMove();
        GameGravity();
    }

    /// <summary>
    /// Передвижение персонажа по направлению камеры
    /// </summary>
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        //Перемещение
        if (pressed)
        {
            moveVector.x = Camera.main.transform.forward.x * speedMove;
            moveVector.z = Camera.main.transform.forward.z * speedMove;
        }

        if (moveVector.x!=0 || moveVector.z != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            transform.LookAt(moveVector + transform.position);
        }

        moveVector.y = gravityForce;


        // передвижение по направлению
        ch_controller.Move(moveVector * Time.deltaTime);
    }

    /// <summary>
    /// Гравитация для персонажа
    /// </summary>
    private void GameGravity()
    {
        if (!ch_controller.isGrounded)
            gravityForce -= 20f * Time.deltaTime;
        else
        {
            gravityForce = -1f;
            //animator.SetBool("Jump", false);
        }

    }

    /// <summary>
    /// Прыжок персонажа
    /// </summary>
    public void Jumping()
    {
        if (ch_controller.isGrounded && !animator.GetBool("Jump"))
        {
            gravityForce = jumpPower;
        }
    }
}
