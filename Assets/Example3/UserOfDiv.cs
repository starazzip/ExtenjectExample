using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UserOfDiv : MonoBehaviour
{
    private IOperator _operator;
    [SerializeField] private Text _bigTitle;
    [SerializeField] private Text _title;
    [SerializeField] private Text _result;
    [SerializeField] private string _bigTitleStr;
    [SerializeField] private string _titleStr;
    [SerializeField] private int _dividend;
    [SerializeField] private int _divisor;

    [Inject]
    private void Constructor(IOperator op)
    {
        this._operator = op;
    }
    private void Start()
    {
        this._bigTitle.text = _bigTitleStr;
        this._title.text = _titleStr;
        this._result.text = this._operator.DoOprator(_dividend, _divisor).ToString();
    }
}
