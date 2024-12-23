using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Resource> _resources = new List<Resource>();
    
    public IReadOnlyList<Resource> Resources => _resources;
    
    public void AddResource(Resource resource) {
        _resources.Add(resource);

        Debug.Log($"Добавлен ресурс: {resource.Config.Name}. Количество: {resource.Amount}");
    }

    public void ShowInventory() {
        foreach (var resource in _resources) {
            Debug.Log($"{resource.Config.Name}: {resource.Amount}");
        }
    }
}
