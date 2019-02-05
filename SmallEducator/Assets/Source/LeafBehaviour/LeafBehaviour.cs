using LeafManupulator;
using System.Collections.Generic;

public abstract class LeafBehaviour : ILeafBehaviour
{
    protected static int FADE_IN = 0;
    protected static int FADE_OUT = 1;
    protected static int FLY_IN = 2;
    protected static int FLY_OUT = 3;

    protected List<LeafManipulator> leafManipulators;
    protected bool manipulatorsDone = false;

    public abstract void cleanUp();

    public abstract void start();

    public abstract bool update();
}
