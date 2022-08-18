
public class DivSingleton : IOperator
{
    private static DivSingleton _Instance;
    public static DivSingleton Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new DivSingleton();
            return _Instance;
        }
    }
    private DivSingleton() { }
    public int DoOprator(int a, int b)
    {
        if (b == 0)
            throw new System.Exception("div 0");
        return a / b;
    }
}
