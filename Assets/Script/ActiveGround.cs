using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class ActiveGround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform brickContainer;
    [SerializeField] private Transform finishPoint;
    private HashSet<ColorType> groundColorTypes = new HashSet<ColorType>();
    private void Awake()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //get color
        Character character = other.GetComponent<Character>();
        if(character!=null && groundColorTypes.Add(character.colorType))
        {

            GetComponentInParent<Ground>().OnInitColor(character.colorType);
            //pass the brick container to bot
            if (character is Bot)
            {
                Bot bot = other.GetComponent<Bot>();
                bot.SetBrickListParent(brickContainer);
                bot.ChangeState(BotState.search);
                if (finishPoint != null)
                {
                    bot.SetFinishPoint(finishPoint);
                }
            }
        }

    }

}
