using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Library
{
    public class Messages
    {
        public static string ContactSoftwareSupport()
        {
            return "Contact your software support!";
        }
        public static string ContactITSupport()
        {
            return "Contact your Hardware / Networking support!";
        }
        public static string Blank(string pFieldName)
        {
            return pFieldName + " cannot be blank!";
        }
        public static string BlankNone(string pFieldName)
        {
            return pFieldName + " cannot be blank or none!";
        }

        public static string BlankWithLineNo(string pFieldName, Int64 pLineNo)
        {
            return pFieldName + " cannot be blank at line number [" + pLineNo.ToString() + "] !";
        }
        public static string Invalid(string pFieldName)
        {
            return "Invalid " + pFieldName + "!";
        }
        public static string AlreadyExist(string pFieldName)
        {
            return pFieldName + " already exist!";
        }
        public static string NotExist(string pFieldName)
        {
            return pFieldName + " not exist!";
        }

        public static string AtLeastOneValidRecordRequiredTo(string pSuffix)
        {
            return "At least one valid record required for " + pSuffix + "!";
        }

        public static string AtLeastOneValidRecordRequiredFor(string pSuffix)
        {
            return "At least one valid record required for " + pSuffix + "!";
        }

        public static string CannotBeGreaterThen(string pFieldName, string pValue)
        {
            return pFieldName + " cannot be greater then " + pValue;
        }

        public static string NothingTo(string pSuffix)
        {
            return "Nothing to " + pSuffix + "!";
        }
        public static string NotMatching(string pPrefix, string pSuffix)
        {
            return pPrefix + " not matching with " + pSuffix + "!";
        }
        public static string ShowErrorMessage(string pMessage)
        {
            return pMessage;
        }
        public static string AuditColumnFailed()
        {
            return "Audit fields validation failed! Please login again and try again!";
        }


        public static void GetErrorListFromModelState
                                              (ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;
            foreach (var item in query.ToList())
            {
                modelState.AddModelError("", item.ToString());
            }
        }
    }
}
