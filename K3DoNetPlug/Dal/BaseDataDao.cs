using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K3DoNetPlug;
using K3DoNetPlug.Model;

namespace K3DoNetPlug.Dal
{
    /// <summary>
    /// k3基础资料数据访问层
    /// </summary>
    public class BaseDataDao
    {
        DapperDbManager dbManager = new DapperDbManager();

        public List<BaseDataModel> GetListByName(ItemTypeEnum itemType, string name)
        {
            string sqlString = @"SELECT ti.FName,ti.FNumber,FItemId
FROM t_item ti
WHERE ti.FItemClassID=@FItemClassID AND ti.FName=@FName";

            return this.dbManager.Query<BaseDataModel>(sqlString, new { FItemClassID = itemType, FName = name }).ToList();
        }

        public bool IsExistFNumber(ItemTypeEnum itemType,string fnumber)
        {
            string sqlString = @"SELECT fnumber,FName
FROM t_Item t
WHERE t.FItemClassID=itemType AND FNumber=@fnumber";
            return this.dbManager.Query(sqlString, new { itemType = itemType, fnumber = fnumber }).Any();
        }

        public bool IsExistFName(ItemTypeEnum itemType,string fname)
        {
            string sqlString = @"SELECT fnumber,FName
FROM t_Item t
WHERE t.FItemClassID=@itemType AND FName=@fname";
            return this.dbManager.Query(sqlString, new { itemType = itemType, fname = fname }).Any();
        }

        /// <summary>
        /// 新增客户基础资料
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="baseData"></param>
        public void AddCuster(BaseDataMoreModel baseData)
        {
            #region sql
            string sqlString = @"--DECLARE    @FName VARCHAR(255),
--    @FNumber  VARCHAR(255),
--    @FShortNumber VARCHAR(255),
--    @FFullNumber VARCHAR(255)
--SET @FName='测试FName'
--SET @FNumber='测试FNumber'
--SET @FShortNumber='测试FShortNumber'
--SET @FFullNumber='测试FFullNumber'

DECLARE @itemId int

INSERT INTO t_Item
  (
    FItemClassID,
    FParentID,
    FLevel,
    FName,
    FNumber,
    FShortNumber,
    FFullNumber,
    FDetail,
    UUID,
    FDeleted
  )
VALUES
  (
    1,
    0,
    1,
    @FName,
    @FNumber,
    @FShortNumber,
    @FFullNumber,
    1,
    NEWID(),
    0
  )

select @itemId=fitemid FROM t_item WHERE FNumber=@FNumber

INSERT INTO t_Organization
  (
    FHelpCode,
    FShortName,
    FAddress,
    FStatus,
    FRegionID,
    FTrade,
    FContact,
    FPhone,
    FMobilePhone,
    FFax,
    FPostalCode,
    FEmail,
    FBank,
    FAccount,
    FTaxNum,
    FIsCreditMgr,
    FSaleMode,
    FValueAddRate,
    FProvinceID,
    FCityID,
    FCountry,
    FHomePage,
    Fcorperate,
    FCarryingAOS,
    FTypeID,
    FSaleID,
    FStockIDKeep,
    FCoSupplierID,
    FCyID,
    FSetID,
    FCIQNumber,
    FARAccountID,
    FPreAcctID,
    FOtherARAcctID,
    FPayTaxAcctID,
    FAPAccountID,
    FPreAPAcctID,
    FOtherAPAcctID,
    FfavorPolicy,
    Fdepartment,
    Femployee,
    FlastTradeAmount,
    FlastRPAmount,
    FmaxDealAmount,
    FminForeReceiveRate,
    FminReserverate,
    FdebtLevel,
    FPayCondition,
    FNameEN,
    FAddrEn,
    FCIQCode,
    FRegion,
    FManageType,
    FShortNumber,
    FNumber,
    FName,
    FParentID,
    FItemID
  )
VALUES
  (
    NULL,
    NULL,
    NULL,
    1072,
    0,
    0,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    0,
    1057,
    '17',
    0,
    0,
    NULL,
    NULL,
    NULL,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    NULL,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    NULL,
    0,
    0,
    '0',
    '0',
    '0',
    '1',
    '1',
    0,
    0,
    NULL,
    NULL,
    NULL,
    0,
    0,
    @FShortNumber,
    @FNumber,
    @FName,
    0,
    @itemId
  )

 
IF NOT EXISTS(
       SELECT *
       FROM   Access_t_Organization
       WHERE  FItemID = @itemId
   )
    INSERT INTO Access_t_Organization
      (
        FItemID,
        FParentIDX,
        FDataAccessView,
        FDataAccessEdit,
        FDataAccessDelete
      )
    VALUES
      (
        @itemId,
        0,
        CONVERT(VARBINARY(7200), REPLICATE(CHAR(0), 7200)),
        CONVERT(VARBINARY(7200), REPLICATE(CHAR(0), 7200)),
        CONVERT(VARBINARY(7200), REPLICATE(CHAR(0), 7200))
      )
ELSE
    UPDATE Access_t_Organization
    SET    FParentIDX            = 0,
           FDataAccessView       = CONVERT(VARBINARY(7200), REPLICATE(CHAR(0), 7200)),
           FDataAccessEdit       = CONVERT(VARBINARY(7200), REPLICATE(CHAR(0), 7200)),
           FDataAccessDelete     = CONVERT(VARBINARY(7200), REPLICATE(CHAR(0), 7200))
    WHERE  FItemID               = @itemId
 ";
            #endregion

            this.dbManager.Execute(sqlString, baseData);
        }

        public void AddEmp(BaseDataMoreModel baseData)
        {
            #region sql
            string sqlString = @"--DECLARE    @FName VARCHAR(255),
--    @FNumber  VARCHAR(255),
--    @FShortNumber VARCHAR(255),
--    @FFullNumber VARCHAR(255)
--SET @FName='测试FName'
--SET @FNumber='测试FNumber'
--SET @FShortNumber='测试FShortNumber'
--SET @FFullNumber='测试FFullNumber'

DECLARE @itemId INT

INSERT INTO t_Item
  (
    FItemClassID,
    FParentID,
    FLevel,
    FName,
    FNumber,
    FShortNumber,
    FFullNumber,
    FDetail,
    UUID,
    FDeleted
  )
VALUES
  (
    3,
    0,
    1,
    @FName,
    @FNumber,
    @FShortNumber,
    @FFullNumber,
    1,
    NEWID(),
    0
  )
  
select @itemId=fitemid FROM t_item WHERE FNumber=@FNumber

INSERT INTO t_Emp
  (
    FEmpGroup,
    FDepartmentID,
    FGender,
    FDegree,
    FPhone,
    FMobilePhone,
    FID,
    FDuty,
    FAccountName,
    FPersonalBank,
    FBankAccount,
    FProvinceID,
    FCityID,
    FAddress,
    FEmail,
    FNote,
    FIsCreditMgr,
    FProfessionalGroup,
    FJobTypeID,
    FAllotPercent,
    FOperationGroup,
    FOtherARAcctID,
    FPreARAcctID,
    FOtherAPAcctID,
    FPreAPAcctID,
    FAllotWeight,
    JiShuDengJi,
    ZhuDian,
    FShortNumber,
    FNumber,
    FName,
    FParentID,
    FItemID
  )
VALUES
  (
    0,
    0,
    1068,
    0,
    NULL,
    NULL,
    NULL,
    0,
    NULL,
    NULL,
    NULL,
    0,
    0,
    NULL,
    NULL,
    NULL,
    0,
    0,
    0,
    '0',
    0,
    0,
    0,
    0,
    0,
    '0',
    NULL,
    NULL,
    @FShortNumber,
    @FNumber,
    @FName,
    0,
    @itemId
  )
    
DELETE 
FROM   Access_t_Emp
WHERE  FItemID = @itemId

INSERT INTO Access_t_Emp
  (
    FItemID,
    FParentIDX,
    FDataAccessView,
    FDataAccessEdit,
    FDataAccessDelete
  )
VALUES
  (
    @itemId,
    0,
    CONVERT(VARBINARY(7200), REPLICATE(CHAR(255), 100)),
    CONVERT(VARBINARY(7200), REPLICATE(CHAR(255), 100)),
    CONVERT(VARBINARY(7200), REPLICATE(CHAR(255), 100))
  )";
#endregion
            this.dbManager.Execute(sqlString, baseData);
        }
    }
}
