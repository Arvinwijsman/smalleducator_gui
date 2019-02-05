using System.Collections.Generic;

public class SmallEducatorComposite : Component
{
    private List<Component> componentList = new List<Component>();

    public SmallEducatorComposite(int id, string name, float timeStap) : base(id, name, timeStap)
    {
    }

    public override void addComponent(Component component)
    {
        componentList.Add(component);
    }

    public override Component getComponent(int index)
    {
        return componentList[index];
    }

    public override void removeComponent(Component component)
    {
        componentList.Remove(component);
    }

    public override void swapComponent(int indexOldPosition, int indexNewPosition)
    {
        Component temp = componentList[indexNewPosition];
        componentList[indexNewPosition] = componentList[indexOldPosition];
        componentList[indexNewPosition] = temp;
    }

    public override IEnumerator<Component> getIterator()
    {
        return new SmallEducatorCompositeIterator(componentList);
    }

    public override void doAction()
    {
        throw new System.NotImplementedException();
    }

    public override void start()
    {
        throw new System.NotImplementedException();
    }
}