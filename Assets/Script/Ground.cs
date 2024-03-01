using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Drawing;
public class Ground : MonoBehaviour
{
    [SerializeField] Brick brickPrefab;
    [SerializeField] private Transform brickContainer;
    //private Transform[] initBrickPoints;
    //public List<Brick> bricks = new List<Brick>();
    // Start is called before the first frame update
    private void Awake()
    {

    }  
    public void OnInitColor(ColorType color)
    {
        if (GameManager.Instance.gameState == GameState.gameplay)
        {
            int len = (int)(brickContainer.childCount * 0.3f);
            CreateBricks(color, len);

            StartCoroutine(GenerateBrickLater(color));
        }
        //

        //
    }
    private void CreateBricks(ColorType color,int len)
    {

        for (int i = 0; i < len; i++)
        {
            AddBrick(color);
        }
    }
    IEnumerator GenerateBrickLater(ColorType color)
    {
        //while (GameManager.GameState==)
        for(int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(3f);
            if (GameManager.Instance.gameState == GameState.gameplay)
            {
                AddRandomBrick(color);
                AddRandomBrick(color);
                AddRandomBrick(color);
            }


        }


    }
    private void AddRandomBrick(ColorType color)
    {
   
        int rand = Random.Range(0, brickContainer.childCount);
        if (brickContainer.GetChild(rand).childCount == 0)
        {
            //blank
            //Brick brick = Instantiate(brickPrefab, brickContainer.GetChild(rand));
            Brick brick = ObjectPooler.Instance.SpawnFromPool("brick",brickContainer.GetChild(rand).position, Quaternion.identity);
            brick.transform.SetParent(brickContainer.GetChild(rand));
            brick.ChangeColor(color);
            //bricks.Add(brick);
        }
        else
        {
            //no blank replace color
            brickContainer.GetChild(rand).GetChild(0)?.GetComponent<Brick>()?.ChangeColor(color);
        }
    }
    private void AddBrick(ColorType color)
    {
        for (int i = 0; i < brickContainer.childCount; i++)
        {
            //BrickPoint p = brickContainer.GetChild(i).GetComponent<BrickPoint>();
            if (brickContainer.GetChild(i).childCount==0)
            {
                //Brick brick = Instantiate(brickPrefab, brickContainer.GetChild(i));
                Brick brick = ObjectPooler.Instance.SpawnFromPool("brick", brickContainer.GetChild(i).position, Quaternion.identity);
                brick.transform.SetParent(brickContainer.GetChild(i));
                brick.ChangeColor(color);
                //bricks.Add(brick);
                return;
            }
           
        }




    }
    internal void RemoveBrick(Brick brick)
    {
        //
        //bricks.Remove(brick);
        Destroy(brick.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
