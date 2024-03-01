using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] private Brick brickPrefab;
    [SerializeField] private LayerMask stairLayer;

    [SerializeField] protected Transform characterTf;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform brickContainer;
    private string currentAnimation = Constants.ANIM_IDLE;


    public override void OnInit()
    {
        ClearBrick();
    }
    public void AddBrick()
    {
        //Brick brick = Instantiate(brickPrefab, brickContainer);
        Brick brick = ObjectPooler.Instance.SpawnFromPool("brick", Vector3.zero, Quaternion.identity);
        brick.transform.SetParent(brickContainer);
        brick.ChangeColor(colorType);
        brick.TF.localPosition = Vector3.up * 0.25f * brickContainer.childCount;
    }
    public int GetBrickNumber()
    {
        return brickContainer.childCount;
    }
    private void RemoveBrick()
    {
        if (brickContainer.childCount > 0)
        {
            GameObject removedBrick = brickContainer.GetChild(brickContainer.childCount - 1).gameObject;
            removedBrick.transform.parent = null;
            removedBrick.SetActive(false);
            //Destroy(removedBrick);
        }
    }
    public void ClearBrick()
    {
        foreach(Transform child in brickContainer)
        {
            child.transform.position = Vector3.zero;
            child.gameObject.SetActive(false);
            child.parent = null;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("brick")){
            Brick brick = other.GetComponent<Brick>();
            if (brick.colorType == colorType)
            {
                brick.OnRemove();
                AddBrick();
            }

        }
    }
    public void ChangeAnimationState(string animationName)
    {
        if (currentAnimation != animationName && animator!=null)
        {
            animator.ResetTrigger(currentAnimation);
            currentAnimation = animationName;
            animator.SetTrigger(currentAnimation);
        }
    }
    //check can move
    public bool CanMove(Vector3 nextPosition)
    {
        //create ray here
        RaycastHit hit;
        //increase Y to ray
        nextPosition.y += 1;
        Debug.DrawRay(nextPosition, Vector3.down, Color.red, 5f, false);
        if (Physics.Raycast(nextPosition, Vector3.down,out hit,2f,stairLayer))
        {
            Step step = hit.collider.GetComponent<Step>();
            ///check brick
            if (step.colorType != colorType && brickContainer.childCount > 0)
            {
                step.ChangeColor(colorType);
                //remove character brick
                RemoveBrick();

            }
            if (step.colorType != colorType && brickContainer.childCount == 0&&TF.forward.z>0)
            {
             
                return false;
            }
            return true;
        }
        return true;
    }
}
