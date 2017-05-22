


public class Role : BaseModule
{
    private int level = 47;
    private int point = 20;
    private string name;
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            EventDispatcher.TriggerEvent("level");
        }
    }
    public int Point
    {
        get { return point; }
        set
        {
            point = value;
            EventDispatcher.TriggerEvent("point");
        }
    }
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            EventDispatcher.TriggerEvent("name");
        }
    }
}