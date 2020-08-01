VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "OldBiller"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Description = "This is Industry Bill Interface Class, made by K3BOSPLUGINSWIZAED"
'
''定义插件对象接口. 必须具有的声明, 以此来获得事件
'Private WithEvents m_BillTransfer   As k3BillTransfer.Bill
'
'Public Sub Show(ByVal oBillTransfer As Object)
'
'    '接口实现
'    '注意: 此方法必须存在, 请勿修改
'    Set m_BillTransfer = oBillTransfer
'
'End Sub
'
'Private Sub Class_Terminate()
'
'    '释放接口对象
'    '注意: 此方法必须存在, 请勿修改
'    Set m_BillTransfer = Nothing
'
'End Sub

'-----------------------单据头-------------------------------

'单据头代码
Public Function Head_GetNumber(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal headIndex As Integer) As String
    Head_GetNumber = Head_GetHeadOjbect(m_BillTransfer, headIndex).Number
End Function

'单据头Name值
Public Function Head_GetName(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal headIndex As Integer) As String
    Head_GetName = Head_GetHeadOjbect(m_BillTransfer, headIndex).Name
End Function

'单据头InterID
Public Function Head_GetInterID(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal headIndex As Integer) As String
    Head_GetInterID = Head_GetHeadOjbect(m_BillTransfer, headIndex).InterID
End Function

'获取单据头索引号
Public Function Head_GetIndex(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal headName As String) As Integer
    Dim headIndex As Integer
    Dim headCtls As Variant
    Dim maxHeadIndex As Integer
    headCtls = m_BillTransfer.HeadCtl
    maxHeadIndex = Head_GetMaxIndex(m_BillTransfer)
    For headIndex = 0 To maxHeadIndex
        If (UCase(headCtls(headIndex).FieldName) = UCase(headName)) Then
            Head_GetIndex = headIndex
            Exit Function
        End If
    Next headIndex
    Head_GetIndex = -1
End Function

'获取单据头名
Public Function Head_GetFieldName(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal headIndex As Integer) As String
    Head_GetFieldName = Head_GetHeadOjbect(m_BillTransfer, headIndex).FieldName
End Function

'最大行数
Public Function Head_GetMaxIndex(ByVal m_BillTransfer As k3BillTransfer.Bill) As Integer
    Dim headCtls As Variant
    headCtls = m_BillTransfer.HeadCtl
    Head_GetMaxIndex = UBound(headCtls)
End Function

'获取单据头对像
Public Function Head_GetHeadOjbect(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal headIndex As Integer) As Variant
    Dim headCtls As Variant
    headCtls = m_BillTransfer.HeadCtl
    Head_GetHeadOjbect = headCtls(headIndex)
End Function

'获取单据头对像
Public Function Grid_SetAction(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal rowIndex As Integer, ByVal columnIndex As Integer) As Variant
    With m_BillTransfer.Grid
     .col = columnIndex
     .Row = rowIndex
     .SetActiveCell .col, .Row
    End With
End Function
'-----------------------end单据头end---------------------------------


'-------------------------------------------------------------------------------------------------------------------------------------------------


'-----------------------单据体---------------------------------------

'---------单据行信息---------
'获取单元格数据行数
Public Function Row_GetCount(ByVal m_BillTransfer As k3BillTransfer.Bill)
    'Dim cellIndex As Integer
    'Dim cellMaxIndex As Integer
    'Dim rowsCount As Integer
    
    'cellMaxIndex = Column_GetCount(m_BillTransfer)
    '遍历m_BillTransfer.EntryCtl
    'For cellIndex = 1 To cellMaxIndex
        '判断是否有数据
        'If (UBound(m_BillTransfer.EntryCtl(cellIndex).DName) <> -1) Then
            'Row_GetCount = UBound(m_BillTransfer.EntryCtl(cellIndex).DName) - 1
            'Exit Function
        'End If
    'Next cellIndex
    'Row_GetCount = 0
    Row_GetCount = m_BillTransfer.Grid.Row
End Function

'---------单据信息---------
'获取单据模板Id
Public Function GetTemplateName(ByVal m_BillTransfer As k3BillTransfer.Bill)
    GetTemplateName = m_BillTransfer.HeadCtl(0).BillTemplateId
End Function

'增加新行
Sub Row_NewRow(ByVal m_BillTransfer As k3BillTransfer.Bill)
    Dim rowIndex As Integer
    rowIndex = m_BillTransfer.Grid.Row
    m_BillTransfer.BillForm.InsertRow
    m_BillTransfer.Grid.Row = rowIndex
End Sub

'获取行是否需新增数据行
Public Function Row_GetIsNeedNewRow(ByVal m_BillTransfer As k3BillTransfer.Bill) As Boolean
    If (m_BillTransfer.Grid.Row = -1) Then
        Row_GetIsNeedNewRow = False
    Else
        Row_GetIsNeedNewRow = True
    End If
End Function

'--------单据列信息---------
'获取数据列数
Public Function Column_GetCount(ByVal m_BillTransfer As k3BillTransfer.Bill)
    Column_GetCount = UBound(m_BillTransfer.EntryCtl)
End Function

'获取数据列名
Public Function Column_GetName(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal columnIndex As Integer) As String
    Column_GetName = m_BillTransfer.EntryCtl(columnIndex).FieldName
End Function

'获取列是否为查找类型
Public Function Column_GetIsLookUp(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal columnIndex As Integer) As Boolean
    If (m_BillTransfer.EntryCtl(columnIndex).LookUpCls = 4) Then
        Column_GetIsLookUp = True
    Else
        Column_GetIsLookUp = False
    End If
End Function

'--------单元格信息----------
'获取单元格InterID值
Public Function Cell_GetInterID(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal rowIndex, ByVal cellIndex) As String
    If (UBound(m_BillTransfer.EntryCtl(cellIndex).DInterID) >= rowIndex) Then
        Cell_GetInterID = m_BillTransfer.EntryCtl(cellIndex).DInterID(rowIndex)
    Else
        Cell_GetInterID = ""
    End If
End Function


'获取单元格Number
Public Function Cell_GetNumber(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal rowIndex, ByVal cellIndex) As String
    If (UBound(m_BillTransfer.EntryCtl(cellIndex).DInterID) >= rowIndex) Then
        Cell_GetNumber = m_BillTransfer.EntryCtl(cellIndex).DNumber(rowIndex)
    Else
        Cell_GetNumber = ""
    End If
End Function

'获取单元格Name值,即text值
Public Function Cell_GetName(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal rowIndex, ByVal cellIndex) As String
    If (UBound(m_BillTransfer.EntryCtl(cellIndex).DInterID) >= rowIndex) Then
        Cell_GetName = m_BillTransfer.EntryCtl(cellIndex).DName(rowIndex)
    Else
        Cell_GetName = ""
    End If
End Function

Public Sub GridSetText(ByVal m_BillTransfer As k3BillTransfer.Bill, ByVal rowIndex, ByVal cellIndex, ByVal val As String)
    m_BillTransfer.Grid.SetText cellIndex, rowIndex, val
End Sub

'-----------------------end单据体end---------------------------------

