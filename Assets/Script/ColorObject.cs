using UnityEngine;

public abstract class ColorObject : GameUnit
{

    [SerializeField] private ColorList colorList;
    [SerializeField] private Renderer renderer;

    public ColorType colorType;
    public void ChangeColor(ColorType type)
    {
        colorType = type;
        renderer.material = colorList.GetColorMat(colorType);

    }


    public override void OnInit()
    {

    }

    public override void OnRespawn()
    {

    }
}