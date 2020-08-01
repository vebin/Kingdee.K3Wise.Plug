using System;
using System.Collections.Generic;
using System.Text;
using K3DoNetPlug.Server;


namespace K3DoNetPlug
{
    public class BaseServer
    {
        protected VBDoNetPlug.NewBiller newBiller = new VBDoNetPlug.NewBiller();

        protected DBUnit DBUnitInstance;

        protected Head Head;

        protected VBDoNetPlug.NewBiller NewBiller = new VBDoNetPlug.NewBiller();

        public virtual void BeforeSave(string sDsn,
                           KFO.Dictionary dctClassType,
                           KFO.Vector ClassTypeEntry,
                           KFO.Dictionary dctTableInfo,
                           KFO.Dictionary dctData,
                           KFO.Dictionary dctLink)
        {
            DBUnitInstance = new DBUnit(sDsn);
            this.Head = new Head(dctTableInfo, dctData);
            DoBeforeSave(sDsn, dctClassType, ClassTypeEntry, dctTableInfo, dctData,dctLink);
        }

        protected virtual void DoBeforeSave(string sDsn,
                           KFO.Dictionary dctClassType,
                           KFO.Vector ClassTypeEntry,
                           KFO.Dictionary dctTableInfo,
                           KFO.Dictionary dctData,
                           KFO.Dictionary dctLink)
        {

        }

        public virtual void AfterSave(string sDsn,
                          KFO.Dictionary dctClassType,
                          KFO.Vector vctClassTypeEntry,
                          KFO.Dictionary dctTableInfo,
                          KFO.Dictionary dctData,
                          KFO.Dictionary dctLink)
        {

            DBUnitInstance = new DBUnit(sDsn);
            this.Head = new Head(dctTableInfo, dctData);
            DoAfterSave(sDsn, dctClassType, vctClassTypeEntry, dctTableInfo, dctData, dctLink);
        }

        protected virtual void DoAfterSave(string sDsn,
                          KFO.Dictionary dctClassType,
                          KFO.Vector vctClassTypeEntry,
                          KFO.Dictionary dctTableInfo,
                          KFO.Dictionary dctData,
                          KFO.Dictionary dctLink)
        {
        }

        public virtual void BeforeDel(string sDsn,
                            long nClassID,
                            KFO.Dictionary dctClassType,
                            long nInterID)
        {
            DBUnitInstance = new DBUnit(sDsn);
            DoBeforeDel(sDsn, nClassID, dctClassType, nInterID);
        }

        protected virtual void DoBeforeDel(string sDsn, long nClassID, KFO.Dictionary dctClassType, long nInterID)
        {
        }

        public virtual void AfterDel(string sDsn,
						long nClassID,
						KFO.Dictionary dctClassType,
						long nInterID)
        {
            DBUnitInstance = new DBUnit(sDsn);
            DoAfterDel(sDsn, nClassID, dctClassType, nInterID);
        }

        protected virtual void DoAfterDel(string sDsn, long nClassID, KFO.Dictionary dctClassType, long nInterID)
        {
            
        }

        public virtual void BeforeMultiCheck(string sDsn,
                                long nClassID,
                                long nFBillID,
                                long nFPage,
                                long nFBillEntryID,
                                KFO.Dictionary dctBillCheckRecord)
        {
            DBUnitInstance = new DBUnit(sDsn);
            DoBeforeMultiCheck(sDsn, nClassID, nFBillID, nFPage, nFBillEntryID, dctBillCheckRecord);
        }

        protected virtual void DoBeforeMultiCheck(string sDsn, long nClassID, long nFBillID, long nFPage, long nFBillEntryID, KFO.Dictionary dctBillCheckRecord)
        {
        }

        public virtual void AfterMultiCheck(string sDsn,
                         long nClassID,
                         long nFBillID,
                         long nFPage,
                         long nFBillEntryID,
                         KFO.Dictionary dctBillCheckRecord)
        {
            DBUnitInstance = new DBUnit(sDsn);
            DoAfterMultiCheck(sDsn, nClassID, nFBillID, nFPage, nFBillEntryID, dctBillCheckRecord);
        }

        protected virtual void DoAfterMultiCheck(string sDsn, long nClassID, long nFBillID, long nFPage, long nFBillEntryID, KFO.Dictionary dctBillCheckRecord)
        {
        }

        //public void ShowMessage(string message)
        //{
        //    NewBiller.ShowMessageForServer(message);
        //}
    }
}
