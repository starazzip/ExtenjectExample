using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UserOfAdd : MonoBehaviour
{
    private OperatorUser operatorUser;
    [SerializeField] private Text _bigTitle;
    [SerializeField] private Text _title;
    [SerializeField] private Text _result;
    [SerializeField] private string _bigTitleStr;
    [SerializeField] private string _titleStr;
    [SerializeField] private int _summand;
    [SerializeField] private int _added;

    [Inject]
    private void Constructor(OperatorUser opUser)
    {
        this.operatorUser = opUser;
    }
    private void Start()
    {
        this._bigTitle.text = _bigTitleStr;
        this._title.text = _titleStr;
        this._result.text = this.operatorUser.GetResult(_summand, _added).ToString();
    }
}
