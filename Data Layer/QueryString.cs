using System;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for QueryString
/// </summary>
public class QueryString
{
    private string _fieldList;

    public string FieldList
    {
        get { return _fieldList; }
        set { _fieldList = value; }
    }

    
    private string _criteria;

    public string Criteria
    {
        get { return _criteria; }
        set { _criteria = value; }
    }
    private string _orderBy;

    public string OrderBy
    {
        get { return _orderBy; }
        set { _orderBy = value; }
    }

    public QueryString()
	{
        _fieldList = null;
        _criteria = null;
        _orderBy = null;
	}

}
