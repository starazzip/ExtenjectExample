using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UserOfMut : MonoBehaviour
{
    private IOperator _operator;
    [SerializeField] private Text _bigTitle;
    [SerializeField] private Text _title;
    [SerializeField] private Text _result;
    [SerializeField] private string _bigTitleStr;
    [SerializeField] private string _titleStr;
    [SerializeField] private int _multiplier;
    [SerializeField] private int _multiplier2;

    private Mut.Factory mutPool;
    [Inject]
    private void Constructor(Mut.Factory pool)
    {
        this.mutPool = pool;
    }
    private void Start()
    {
        _operator = this.mutPool.Create(10);
        this._bigTitle.text = _bigTitleStr + (_operator as Mut).CaculateCounter.ToString();
        this._title.text = _titleStr;
        this._result.text = this._operator.DoOprator(_multiplier, _multiplier2).ToString();
    }
}
