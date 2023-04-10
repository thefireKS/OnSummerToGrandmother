using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/TeaData")]
public class TeaData : ScriptableObject
{
    public TeaType type;
    public List<string> ingredients;

    public enum TeaType
    {
        none,
        black,
        green
    }
    

    public static bool operator ==(TeaData data1, TeaData data2)
    {
        if (data1.type != data2.type)
            return false;
        if (data1.ingredients.Count != data2.ingredients.Count)
            return false;
        
        data1.ingredients.Sort();
        data2.ingredients.Sort();

        return data1.ingredients.SequenceEqual(data2.ingredients);
    }

    public static bool operator !=(TeaData data1, TeaData data2)
    {
        return !(data1 == data2);
    }
}
