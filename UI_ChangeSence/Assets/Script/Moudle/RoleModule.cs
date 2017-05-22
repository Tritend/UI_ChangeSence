
public class RoleModule : BaseModule
{
    private string name = "风浅";
    private  int level = 1;

    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            EventDispatcher.TriggerEvent("level");
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
