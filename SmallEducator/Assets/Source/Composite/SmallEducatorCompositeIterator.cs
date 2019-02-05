using System.Collections;
using System.Collections.Generic;

public class SmallEducatorCompositeIterator : IEnumerator<Component>
{
    private List<Component> componentList;
    private Component currentComponent;
    private int currentIndex = -1;

    public SmallEducatorCompositeIterator(List<Component> componentList)
    {
        this.componentList = componentList;
        currentIndex = 0;
        MoveNext();
    }

    public Component Current
    {
        get
        {
            return currentComponent;
        }
    }

    object IEnumerator.Current
    {
        get
        {
            return currentComponent;
        }
    }

    public void Dispose()
    {
        componentList = null;
        currentComponent = null;
    }

    public bool MoveNext()
    {
        bool movedToNext = false;
        if (currentIndex < componentList.Count)
        {
            movedToNext = true;
            currentComponent = componentList[currentIndex];
            currentIndex++;
        }
        return movedToNext;
    }

    public void Reset()
    {
        currentIndex = 0;
        currentComponent = componentList[currentIndex];
    }
}