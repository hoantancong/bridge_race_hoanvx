using UnityEngine;

public class Player : Character
{
    private JoystickController joystick;
    [SerializeField] private float speed = 5;

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.gameplay) return;
        //moving character
        if (joystick == null)
        {
            joystick = FindAnyObjectByType<JoystickController>();
            if (joystick == null) return;
        }
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            Vector3 nextPos = characterTf.forward*.5f+characterTf.position + direction * speed * Time.deltaTime;
            if (CanMove(nextPos))
            {
                TF.Translate(direction * speed * Time.deltaTime, Space.World);
                //toward face ahead
                TF.forward = direction;
                ChangeAnimationState(Constants.ANIM_RUN);
            }

        }
        else
        {
            //idle
            ChangeAnimationState(Constants.ANIM_IDLE);

        }

    }

}
