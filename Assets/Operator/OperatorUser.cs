
public class OperatorUser
{
    IOperator _operator;
    public OperatorUser(IOperator o)
    {
        this._operator = o;
    }

    public int GetResult(int a, int b)
    {
        return this._operator.DoOprator(a, b);
    }
}
