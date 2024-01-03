using Managers;
using System.Collections.Generic;

public static class Extension
{
    public static Dictionary<Tkey, Tvalue> ToDictionary<Tkey, Tvalue>(this List<Tvalue> datas) where Tvalue : IGameData<Tkey>
    {
        Dictionary<Tkey, Tvalue> dict = new Dictionary<Tkey, Tvalue>();
        foreach (Tvalue vaule in datas)
        {
            dict.Add(vaule.Key, vaule);
        }
        return dict;
    }
}