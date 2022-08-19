using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UserOfSub : MonoBehaviour
{
    private IOperator _operator;
    private Text _BigTitle;
    private Text _title;
    private Text _result;
    private string _titleStr;
    private string _BigTileStr;
    private int _minuend;
    private int _subtraction;
    [Inject]
    private void Constructor(IOperator op,
        [Inject(Id = "title")] Text title,
        [Inject(Id = "result")] Text result,
        [Inject(Id = "BigTitle")] Text BigTitle,
        [Inject(Id = "titleStr")] string titleStr,
        [Inject(Id = "BigTitleStr")] string BigTitleStr,
        [Inject(Id = "minuend")] int minuend,
        [Inject(Id = "subtraction")] int subtraction)
    {
        this._operator = op;
        this._title = title;
        this._result = result;
        this._titleStr = titleStr;
        this._BigTitle = BigTitle;
        this._BigTileStr = BigTitleStr;
        this._minuend = minuend;
        this._subtraction = subtraction;
    }

    private void Start()
    {
        this._title.text = this._titleStr;
        this._BigTitle.text = this._BigTileStr;
        this._result.text = _operator.DoOprator(this._minuend, this._subtraction).ToString();
    }
}
