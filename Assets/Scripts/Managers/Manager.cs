using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager <T> where T : IManagedItem
{
    HashSet<T> managedItems;
    Queue<T> toRemoveQueue;
    Queue<T> toAddQueue;

    public virtual void InitializeManager()
    {
        managedItems = new HashSet<T>();
    }


    public void AddManagedItem(T toAdd)
    {
        toAddQueue.Enqueue(toAdd);
    }

    public void RemoveManagedItem(T toRemove)
    {
        toRemoveQueue.Enqueue(toRemove);
    }

    public void Update()
    {
        AddQueuedItemsToManager();
        RemoveQueuedItemsFromManager();
        foreach (IManagedItem imi in managedItems)
            imi.Update();
    }

    public void FixedUpdate()
    {
        AddQueuedItemsToManager();
        RemoveQueuedItemsFromManager();
        foreach (IManagedItem imi in managedItems)
            imi.FixedUpdate();
    }

    private void AddQueuedItemsToManager()
    {
        //Add items to manager
        while (toAddQueue.Count > 0)
        {
            var v = toAddQueue.Dequeue();
            if (!managedItems.Contains(v))
                managedItems.Add(v);
        }
    }

    private void RemoveQueuedItemsFromManager()
    {
        //Remove items from manager
        while (toRemoveQueue.Count > 0)
        {
            managedItems.Remove(toRemoveQueue.Dequeue());
        }
    }
}
