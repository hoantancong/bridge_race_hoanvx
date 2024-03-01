using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Bot botPrefab;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform[] characterPositions;
   
    void Start()
    {
        ColorType[] colorTypeList =GameUtils.GetRandomColorType(4); // new ColorType[4] { ColorType.purple, ColorType.orange , ColorType.yellow , ColorType.blue };
        //init player and bot
        Debug.Log(colorTypeList[0]);
        Player player = Instantiate(playerPrefab, characterPositions[0].position,Quaternion.identity,transform);
        player.ChangeColor(colorTypeList[0]);
        for (int i = 1; i < characterPositions.Length; i++)
        {
            Bot bot = Instantiate(botPrefab, characterPositions[i].position, Quaternion.identity,transform);
            bot.ChangeColor(colorTypeList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
