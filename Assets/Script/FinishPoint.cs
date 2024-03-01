using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            //finish
            character.ClearBrick();
            character.ChangeAnimationState(Constants.ANIM_VICTORY);
            //
            ObjectPooler.Instance.DespawnBrickPool();
            //
            if (character is Player)
            {
                GameManager.Instance.WinGame();
            }
            else
            {
                GameManager.Instance.LoseGame();
            }
        }
    }
}
