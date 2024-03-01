
using System.Linq;
using System;
using UnityEngine;

public class GameUtils : MonoBehaviour
{
    public static ColorType[] GetRandomColorType(int count)
    {
        // Lấy tất cả giá trị từ ColorType enum
        var values = Enum.GetValues(typeof(ColorType));

        // Tạo một mảng mới cho các giá trị ngẫu nhiên
        ColorType[] randomValues = new ColorType[count];

        // Tạo đối tượng Random
        System.Random random = new System.Random();

        // Điền mảng với các giá trị ngẫu nhiên từ enum
        for (int i = 0; i < count; i++)
        {
            // Chọn ngẫu nhiên và tránh trùng lặp
            ColorType randomColor;
            do
            {
                randomColor = (ColorType)values.GetValue(random.Next(values.Length));
            }
            while (randomValues.Contains(randomColor)||randomColor==ColorType.white);

            randomValues[i] = randomColor;
        }

        return randomValues;
    }
}
