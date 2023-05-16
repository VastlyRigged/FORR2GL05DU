using System.Collections.Generic;
using UnityEngine;

public static class DeepChildExtensions
{
    /// <summary>
    /// Returns with Breadth-first search.
    /// </summary>
    /// <param name="aParent"></param>
    /// <param name="aName"></param>
    /// <returns></returns>
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        Queue<Transform> queue = new();
        queue.Enqueue(aParent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == aName)
                return c;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }
    public static List<Transform> GetAllDeepChildren(this Transform transform)
    {
        List<Transform> list = new();
        list.Add(transform);
        Queue<Transform> queue = new();
        queue.Enqueue(transform);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();

            foreach (Transform t in c)
            {
                queue.Enqueue(t);
                list.Add(t);

            }
        }

        if (list.Count > 0) { return list; }
        else { return null; }
    }
}