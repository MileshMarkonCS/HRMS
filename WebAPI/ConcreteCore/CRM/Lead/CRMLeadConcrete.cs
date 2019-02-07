using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using ModelCore.CRM.Lead;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.CRM.Lead
{
    public class CRMLeadConcrete : ICRMLead
    {
        private readonly DatabaseContext _Context;

        public CRMLeadConcrete(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<SQLResult> Create(CRMLeadEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spCRMLeadInsert
                    @pi_LeadDate
                    , @pi_mLeadUserId
                    , @pi_mEnquirySourceId
                    , @pi_mTitleId
                    , @pi_FirstName
                    , @pi_MiddleName
                    , @pi_LastName
                    , @pi_MobileNo1
                    , @pi_MobileNo2
                    , @pi_PhoneNo1
                    , @pi_PhoneNo2
                    , @pi_Email
                    , @pi_WebSite
                    , @pi_SkypeID
                    , @pi_LinkedID
                    , @pi_TwitterID
                    , @pi_ContactAddress
                    , @pi_mCountryId
                    , @pi_mStateId
                    , @pi_mCityId
                    , @pi_PINZIPCode
                    , @pi_CompanyName
                    , @pi_mIndustryId
                    , @pi_mSegmentId
                    , @pi_PINo
                    , @pi_PIDate
                    , @pi_mBrandId
                    , @pi_mModelId
                    , @pi_Quantity
                    , @pi_mTransactionCurrencyId
                    , @pi_TransactionCurrencyRate
                    , @pi_TraansactionTotalAmount
                    , @pi_mAlternateTransactionCurrencyId
                    , @pi_AlternateTransactionCurrencyRate
                    , @pi_AlternateTransactionTotalAmount
                    , @pi_mBaseCurrencyId
                    , @pi_BaseCurrencyRate
                    , @pi_BaseTotalAmount
                    , @pi_mAlternateBaseCurrencyId
                    , @pi_AlternateBaseCurrencyRate
                    , @pi_AlternateBaseTotalAmount
                    , @pi_mForeignCurrencyId
                    , @pi_ForeignCurrencyRate
                    , @pi_ForeignTotalAmount
                    , @pi_mAlternateForeignCurrencyId
                    , @pi_AlternateForeignCurrencyRate
                    , @pi_AlternateForeignTotalAmount
                    , @pi_mPaymentModeId
                    , @pi_LastContact
                    , @pi_mNextActionId
                    , @pi_NextActionDescription
                    , @pi_NextContact
                    , @pi_mEnquiryStatusId
                    , @pi_Remarks
                    , @pi_CHANo
                    , @pi_mDutyTaxId
                    , @pi_DeliveryDate
                    , @pi_mRatingId
                    , @pi_Description
                    , @pi_mFileId
                    , @pi_mApprovalStatusId
                    , @pi_mCompanyId
                    , @pi_mBranchId
                    , @pi_mFinancialYearId
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_LeadDate", pModel.LeadDate) ,
                     new SqlParameter("@pi_mLeadUserId", pModel.LeadUserId) ,
                     new SqlParameter("@pi_mEnquirySourceId", pModel.EnquirySourceId) ,
                     new SqlParameter("@pi_mTitleId", pModel.TitleId) ,
                     new SqlParameter("@pi_FirstName", pModel.FirstName) ,
                     new SqlParameter("@pi_MiddleName", pModel.MiddleName) ,
                     new SqlParameter("@pi_LastName", pModel.LastName) ,
                     new SqlParameter("@pi_MobileNo1", pModel.MobileNo1) ,
                     new SqlParameter("@pi_MobileNo2", pModel.MobileNo2) ,
                     new SqlParameter("@pi_PhoneNo1", pModel.PhoneNo1) ,
                     new SqlParameter("@pi_PhoneNo2", pModel.PhoneNo2) ,
                     new SqlParameter("@pi_Email", pModel.Email) ,
                     new SqlParameter("@pi_WebSite", pModel.WebSite) ,
                     new SqlParameter("@pi_SkypeID", pModel.SkypeID) ,
                     new SqlParameter("@pi_LinkedID", pModel.LinkedID) ,
                     new SqlParameter("@pi_TwitterID", pModel.TwitterID) ,
                     new SqlParameter("@pi_ContactAddress", pModel.ContactAddress) ,
                     new SqlParameter("@pi_mCountryId", pModel.CountryId) ,
                     new SqlParameter("@pi_mStateId", pModel.StateId) ,
                     new SqlParameter("@pi_mCityId", pModel.CityId) ,
                     new SqlParameter("@pi_PINZIPCode", pModel.PINZIPCode) ,
                     new SqlParameter("@pi_CompanyName", pModel.CompanyName) ,
                     new SqlParameter("@pi_mIndustryId", pModel.IndustryId) ,
                     new SqlParameter("@pi_mSegmentId", pModel.SegmentId) ,
                     new SqlParameter("@pi_PINo", pModel.PINo) ,
                     new SqlParameter("@pi_PIDate", pModel.PIDate) ,
                     new SqlParameter("@pi_mBrandId", pModel.BrandId) ,
                     new SqlParameter("@pi_mModelId", pModel.ModelId) ,
                     new SqlParameter("@pi_Quantity", pModel.Quantity) ,
                     new SqlParameter("@pi_mTransactionCurrencyId", pModel.TransactionCurrencyId) ,
                     new SqlParameter("@pi_TransactionCurrencyRate", pModel.TransactionCurrencyRate) ,
                     new SqlParameter("@pi_TransactionTotalAmount", pModel.TransactionTotalAmount) ,
                     new SqlParameter("@pi_mAlternateTransactionCurrencyId", pModel.AlternateTransactionCurrencyId) ,
                     new SqlParameter("@pi_AlternateTransactionCurrencyRate", pModel.AlternateTransactionCurrencyRate) ,
                     new SqlParameter("@pi_AlternateTransactionTotalAmount", pModel.AlternateTransactionTotalAmount) ,
                     new SqlParameter("@pi_mBaseCurrencyId", pModel.BaseCurrencyId) ,
                     new SqlParameter("@pi_BaseCurrencyRate", pModel.BaseCurrencyRate) ,
                     new SqlParameter("@pi_BaseTotalAmount", pModel.BaseTotalAmount) ,
                     new SqlParameter("@pi_mAlternateBaseCurrencyId", pModel.AlternateBaseCurrencyId) ,
                     new SqlParameter("@pi_AlternateBaseCurrencyRate", pModel.AlternateBaseCurrencyRate) ,
                     new SqlParameter("@pi_AlternateBaseTotalAmount", pModel.AlternateBaseTotalAmount) ,
                     new SqlParameter("@pi_mForeignCurrencyId", pModel.ForeignCurrencyId) ,
                     new SqlParameter("@pi_ForeignCurrencyRate", pModel.ForeignCurrencyRate) ,
                     new SqlParameter("@pi_ForeignTotalAmount", pModel.ForeignTotalAmount) ,
                     new SqlParameter("@pi_mAlternateForeignCurrencyId", pModel.AlternateForeignCurrencyId) ,
                     new SqlParameter("@pi_AlternateForeignCurrencyRate", pModel.AlternateForeignCurrencyRate) ,
                     new SqlParameter("@pi_AlternateForeignTotalAmount", pModel.AlternateForeignTotalAmount) ,
                     new SqlParameter("@pi_mPaymentModeId", pModel.PaymentModeId) ,
                     new SqlParameter("@pi_LastContact", pModel.LastContact) ,
                     new SqlParameter("@pi_mNextActionId", pModel.NextActionId) ,
                     new SqlParameter("@pi_NextActionDescription", pModel.NextActionDescription) ,
                     new SqlParameter("@pi_NextContact", pModel.NextContact) ,
                     new SqlParameter("@pi_mEnquiryStatusId", pModel.EnquiryStatusId) ,
                     new SqlParameter("@pi_Remarks", pModel.Remarks) ,
                     new SqlParameter("@pi_CHANo", pModel.CHANo) ,
                     new SqlParameter("@pi_mDutyTaxId", pModel.DutyTaxId) ,
                     new SqlParameter("@pi_DeliveryDate", pModel.DeliveryDate) ,
                     new SqlParameter("@pi_mRatingId", pModel.RatingId) ,
                     new SqlParameter("@pi_Description", pModel.Description) ,
                     new SqlParameter("@pi_mFileId", pModel.FileId) ,
                     new SqlParameter("@pi_mApprovalStatusId", pModel.AuditColumns.ApprovalStatusId) ,
                     new SqlParameter("@pi_mCompanyId", pModel.AuditColumns.CompanyId) ,
                     new SqlParameter("@pi_mBranchId", pModel.AuditColumns.BranchId) ,
                     new SqlParameter("@pi_mFinancialYearId", pModel.AuditColumns.FinancialYearId) ,
                     new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                     new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                     new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                     new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                     new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
                if (result.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                }
                else
                {
                    _Context.Database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _Context.Database.RollbackTransaction();
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }

        public Task<SQLResult> Delete(CRMLeadEntry pModel)
        {
            throw new NotImplementedException();
        }

        public async Task<SQLResult> Edit(CRMLeadEntry pModel)
        {
            SQLResult result = new SQLResult();
            _Context.Database.BeginTransaction();
            try
            {
                string csql = @" EXEC spCRMLeadUpdate
                    @pi_CRMLeadId
                    , @pi_LeadDate
                    , @pi_mLeadUserId
                    , @pi_mEnquirySourceId
                    , @pi_mTitleId
                    , @pi_FirstName
                    , @pi_MiddleName
                    , @pi_LastName
                    , @pi_MobileNo1
                    , @pi_MobileNo2
                    , @pi_PhoneNo1
                    , @pi_PhoneNo2
                    , @pi_Email
                    , @pi_WebSite
                    , @pi_SkypeID
                    , @pi_LinkedID
                    , @pi_TwitterID
                    , @pi_ContactAddress
                    , @pi_mCountryId
                    , @pi_mStateId
                    , @pi_mCityId
                    , @pi_PINZIPCode
                    , @pi_CompanyName
                    , @pi_mIndustryId
                    , @pi_mSegmentId
                    , @pi_PINo
                    , @pi_PIDate
                    , @pi_mBrandId
                    , @pi_mModelId
                    , @pi_Quantity
                    , @pi_mTransactionCurrencyId
                    , @pi_TransactionCurrencyRate
                    , @pi_TransactionTotalAmount
                    , @pi_mAlternateTransactionCurrencyId
                    , @pi_AlternateTransactionCurrencyRate
                    , @pi_AlternateTransactionTotalAmount
                    , @pi_mBaseCurrencyId
                    , @pi_BaseCurrencyRate
                    , @pi_BaseTotalAmount
                    , @pi_mAlternateBaseCurrencyId
                    , @pi_AlternateBaseCurrencyRate
                    , @pi_AlternateBaseTotalAmount
                    , @pi_mForeignCurrencyId
                    , @pi_ForeignCurrencyRate
                    , @pi_ForeignTotalAmount
                    , @pi_mAlternateForeignCurrencyId
                    , @pi_AlternateForeignCurrencyRate
                    , @pi_AlternateForeignTotalAmount
                    , @pi_mPaymentModeId
                    , @pi_LastContact
                    , @pi_mNextActionId
                    , @pi_NextActionDescription
                    , @pi_NextContact
                    , @pi_mEnquiryStatusId
                    , @pi_Remarks
                    , @pi_CHANo
                    , @pi_mDutyTaxId
                    , @pi_DeliveryDate
                    , @pi_mRatingId
                    , @pi_Description
                    , @pi_mFileId
                    , @pi_mApprovalStatusId
                    , @pi_UserId
                    , @pi_HostName
                    , @pi_IPAddress
                    , @pi_DeviceType
                    , @pi_MACAddress";
                List<SqlParameter> sqlparam = new List<SqlParameter>() {
                     new SqlParameter("@pi_CRMLeadId", pModel.CRMLeadId) ,
                     new SqlParameter("@pi_LeadDate", pModel.LeadDate) ,
                     new SqlParameter("@pi_mLeadUserId", pModel.LeadUserId) ,
                     new SqlParameter("@pi_mEnquirySourceId", pModel.EnquirySourceId) ,
                     new SqlParameter("@pi_mTitleId", pModel.TitleId) ,
                     new SqlParameter("@pi_FirstName", pModel.FirstName) ,
                     new SqlParameter("@pi_MiddleName", pModel.MiddleName) ,
                     new SqlParameter("@pi_LastName", pModel.LastName) ,
                     new SqlParameter("@pi_MobileNo1", pModel.MobileNo1) ,
                     new SqlParameter("@pi_MobileNo2", pModel.MobileNo2) ,
                     new SqlParameter("@pi_PhoneNo1", pModel.PhoneNo1) ,
                     new SqlParameter("@pi_PhoneNo2", pModel.PhoneNo2) ,
                     new SqlParameter("@pi_Email", pModel.Email) ,
                     new SqlParameter("@pi_WebSite", pModel.WebSite) ,
                     new SqlParameter("@pi_SkypeID", pModel.SkypeID) ,
                     new SqlParameter("@pi_LinkedID", pModel.LinkedID) ,
                     new SqlParameter("@pi_TwitterID", pModel.TwitterID) ,
                     new SqlParameter("@pi_ContactAddress", pModel.ContactAddress) ,
                     new SqlParameter("@pi_mCountryId", pModel.CountryId) ,
                     new SqlParameter("@pi_mStateId", pModel.StateId) ,
                     new SqlParameter("@pi_mCityId", pModel.CityId) ,
                     new SqlParameter("@pi_PINZIPCode", pModel.PINZIPCode) ,
                     new SqlParameter("@pi_CompanyName", pModel.CompanyName) ,
                     new SqlParameter("@pi_mIndustryId", pModel.IndustryId) ,
                     new SqlParameter("@pi_mSegmentId", pModel.SegmentId) ,
                     new SqlParameter("@pi_PINo", pModel.PINo) ,
                     new SqlParameter("@pi_PIDate", pModel.PIDate) ,
                     new SqlParameter("@pi_mBrandId", pModel.BrandId) ,
                     new SqlParameter("@pi_mModelId", pModel.ModelId) ,
                     new SqlParameter("@pi_Quantity", pModel.Quantity) ,
                     new SqlParameter("@pi_mTransactionCurrencyId", pModel.TransactionCurrencyId) ,
                     new SqlParameter("@pi_TransactionCurrencyRate", pModel.TransactionCurrencyRate) ,
                     new SqlParameter("@pi_TransactionTotalAmount", pModel.TransactionTotalAmount) ,
                     new SqlParameter("@pi_mAlternateTransactionCurrencyId", pModel.AlternateTransactionCurrencyId) ,
                     new SqlParameter("@pi_AlternateTransactionCurrencyRate", pModel.AlternateTransactionCurrencyRate) ,
                     new SqlParameter("@pi_AlternateTransactionTotalAmount", pModel.AlternateTransactionTotalAmount) ,
                     new SqlParameter("@pi_mBaseCurrencyId", pModel.BaseCurrencyId) ,
                     new SqlParameter("@pi_BaseCurrencyRate", pModel.BaseCurrencyRate) ,
                     new SqlParameter("@pi_BaseTotalAmount", pModel.BaseTotalAmount) ,
                     new SqlParameter("@pi_mAlternateBaseCurrencyId", pModel.AlternateBaseCurrencyId) ,
                     new SqlParameter("@pi_AlternateBaseCurrencyRate", pModel.AlternateBaseCurrencyRate) ,
                     new SqlParameter("@pi_AlternateBaseTotalAmount", pModel.AlternateBaseTotalAmount) ,
                     new SqlParameter("@pi_mForeignCurrencyId", pModel.ForeignCurrencyId) ,
                     new SqlParameter("@pi_ForeignCurrencyRate", pModel.ForeignCurrencyRate) ,
                     new SqlParameter("@pi_ForeignTotalAmount", pModel.ForeignTotalAmount) ,
                     new SqlParameter("@pi_mAlternateForeignCurrencyId", pModel.AlternateForeignCurrencyId) ,
                     new SqlParameter("@pi_AlternateForeignCurrencyRate", pModel.AlternateForeignCurrencyRate) ,
                     new SqlParameter("@pi_AlternateForeignTotalAmount", pModel.AlternateForeignTotalAmount) ,
                     new SqlParameter("@pi_mPaymentModeId", pModel.PaymentModeId) ,
                     new SqlParameter("@pi_LastContact", pModel.LastContact) ,
                     new SqlParameter("@pi_mNextActionId", pModel.NextActionId) ,
                     new SqlParameter("@pi_NextActionDescription", pModel.NextActionDescription) ,
                     new SqlParameter("@pi_NextContact", pModel.NextContact) ,
                     new SqlParameter("@pi_mEnquiryStatusId", pModel.EnquiryStatusId) ,
                     new SqlParameter("@pi_Remarks", pModel.Remarks) ,
                     new SqlParameter("@pi_CHANo", pModel.CHANo) ,
                     new SqlParameter("@pi_mDutyTaxId", pModel.DutyTaxId) ,
                     new SqlParameter("@pi_DeliveryDate", pModel.DeliveryDate) ,
                     new SqlParameter("@pi_mRatingId", pModel.RatingId) ,
                     new SqlParameter("@pi_Description", pModel.Description) ,
                     new SqlParameter("@pi_mFileId", pModel.FileId) ,
                     new SqlParameter("@pi_mApprovalStatusId", pModel.AuditColumns.ApprovalStatusId) ,
                     new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
                     new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
                     new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
                     new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
                     new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
                    };
                result = await _Context.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();
                if (result.ErrorNo != 0)
                {
                    _Context.Database.RollbackTransaction();
                }
                else
                {
                    _Context.Database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _Context.Database.RollbackTransaction();
                result.ErrorNo = 9999999999;
                result.ErrorMessage = ex.Message.ToString();
                result.SQLErrorNumber = ex.HResult;
                result.SQLErrorMessage = ex.Source.ToString();
            }
            return result;
        }

        public Task<List<CRMLeadIndex>> GetIndex()
        {
            throw new NotImplementedException();
        }
    }
}
