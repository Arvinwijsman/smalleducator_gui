using System.Collections.Generic;

/// <summary>
/// This class does something.
/// </summary>
public abstract class Component
{
    private int id;
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    private float timeStamp;
    public float TimeStamp
    {
        get { return timeStamp; }
        set { timeStamp = value; }
    }

    public string Name { get; set; }

    protected Component(int id, string name, float timeStap)
    {
        ID = id;
        Name = name;
        TimeStamp = timeStap;
    }

    public abstract void addComponent(Component component);
    public abstract void removeComponent(Component component);
    public abstract Component getComponent(int index);
    public abstract void swapComponent(int indexOldPosition, int indexNewPosition);
    public abstract IEnumerator<Component> getIterator();

    public abstract void start();
    public abstract void doAction();
}