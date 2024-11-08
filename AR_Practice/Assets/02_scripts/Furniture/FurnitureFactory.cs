using UnityEngine;

public class FurnitureFactory : MonoBehaviour
{
    private FurnitureSpecRepository repository;


    private void Awake()
    {
        
    }

    public FurnitureSpec CreateFurniture(string name, Vector3 position)
    {
        repository.IfurnitureDic.TryGetValue(name, out FurnitureSpec furniture);
        if(furniture != null)
        {
            Instantiate(furniture, position, furniture.furniturePrefeb.transform.rotation);
        }
        return furniture;
    }
}
