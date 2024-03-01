
using UnityEngine;

public enum ColorType  {
    white,red,orange,yellow,green,sky,blue,purple
}

[CreateAssetMenu(fileName ="ColorList",menuName ="ScriptableObject/ColorList",order =1)]
public class ColorList : ScriptableObject
{
   
    // Start is called before the first frame update
    public Material[] materialColorList;
    public Material GetColorMat(ColorType colorType)
    {
        return materialColorList[(int)colorType];
    }
}
