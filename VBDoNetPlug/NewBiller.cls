VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "NewBiller"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Description = "This is BillEvent Interface Class, made by K3BOSPLUGINSWIZAED"
 Option Explicit
 Private Declare Function GetCurrentProcessId Lib "kernel32" () As Long

'���� BillEvent �ӿ�. ������е�����, �Դ�������¼�
Private WithEvents m_BillTransfer  As BillEvent
Attribute m_BillTransfer.VB_VarHelpID = -1


'----------------------�������������ڻ�ȡ�����ַ�����---------------------

'��ȡK3���Ӵ�
Public Function GetPropsString() As String
    Dim lProc As Long
    Dim spmMgr As Object

    lProc = GetCurrentProcessId
    Set spmMgr = CreateObject("PropsMgr.ShareProps")
    GetPropsString = spmMgr.GetProperty(lProc, "PropsString")
End Function

'������������
Public Function Row_NewRow(ByVal m_BillTransfer As BillEvent, ByVal nPage As Integer, ByVal nRow As Integer, ByVal cellName As String, ByVal value As String) As Boolean
    Row_NewRow = m_BillTransfer.InsertNewRowAndFill(nPage, nRow, cellName, value)
End Function

'��ȡ������
Public Function Row_GetCount(ByVal m_BillTransfer As BillEvent, ByVal entityIndex As Integer) As Integer
    '��������������ʱGridMaxDataRowNum�ķ���ֵΪ1��¼���һ�����ݺ�GridMaxDataRowNum��ֵҲΪ1
    '�����ж�GridMaxDataRowNum����1�ǣ��������һ���Ƿ��������
    '���û���������(������������������Ϊ��)���򷵻�������0
    Dim sKey As String
    Dim maxRow As Integer
    Dim maxDataRow As Integer
    Dim rowIndex As Integer
    
    sKey = m_BillTransfer.BillEntrys(entityIndex).KeyField
    maxRow = m_BillTransfer.BillEntrys(entityIndex).MaxRows
    
    For rowIndex = 1 To rowIndex
        If (m_BillTransfer.GetFieldValue(sKey, rowIndex) = "") Then
            Row_GetCount = rowIndex
        End If
    Next rowIndex
End Function

'��ȡ��Ԫ��ֵ
Public Function Cell_GetValue(ByVal m_BillTransfer As BillEvent, ByVal rowIndex As Integer, ByVal cellName As String) As String
    Cell_GetValue = m_BillTransfer.GetFieldValue(cellName, rowIndex)
End Function

'��ȡ����ͷֵ
Public Function Head_GetValue(ByVal m_BillTransfer As BillEvent, ByVal headName As String) As String
    Head_GetValue = m_BillTransfer.GetFieldValue(headName)
End Function