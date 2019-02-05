using System.Collections.Generic;

public class SmallEducatorLeaf : Component
{
    private SmallEducator program;
    private ILeafBehaviour behaviour;
    private bool started;

    public SmallEducatorLeaf(int id, string name, float minute, float second, SmallEducator program, ILeafBehaviour behaviour) :
        base(id, name, (minute * 60) + second)
    {
        this.behaviour = behaviour;
        this.program = program;
        started = false;
    }

    public override void start()
    {
        behaviour.start();
        started = true;
    }

    public override void doAction()
    {
        if (started && !behaviour.update())
        {
            behaviour.cleanUp();
            program.removeComponent(this);
        }
    }

    public override void addComponent(Component component)
    {
        throw new System.NotImplementedException();
    }

    public override Component getComponent(int index)
    {
        throw new System.NotImplementedException();
    }

    public override void removeComponent(Component component)
    {
        throw new System.NotImplementedException();
    }

    public override void swapComponent(int indexOldPosition, int indexNewPosition)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator<Component> getIterator()
    {
        throw new System.NotImplementedException();
    }
}