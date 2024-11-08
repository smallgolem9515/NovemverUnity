using UnityEngine;
using System.Collections.Generic;

public class FurnitureSpecRepository : MonoBehaviour
{
    [SerializeField] private List<FurnitureSpec> _furnitureSpecs;
    public IDictionary<string, FurnitureSpec> IfurnitureDic => _furnitureDic;
    private Dictionary<string, FurnitureSpec> _furnitureDic;

    private void Awake()
    {
        foreach(var spec in _furnitureSpecs)
        {
            _furnitureDic.Add(spec.name, spec);
        }
    }
    public FurnitureSpec GetSpec(string name)
    {
        return _furnitureDic[name];
    }
}
