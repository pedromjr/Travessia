using DataCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BusinessClass
    {
        public BusinessClass()
        {
        }

        public BusinessClass(GTContext context)
        {
            _context = context;
        }

        private GTContext _context;

        public GTContext Context
        {
            get
            {
                if (_context == null)
                    _context = new GTContext();
                return _context;
            }
        }

        public List<BusinessError> Errors = new List<BusinessError>();

        public bool HasErrors
        {
            get { return (Errors.Count > 0); }
        }

        public void AddError(string message)
        {
            Errors.Add(new BusinessError() { Message = message });
        }

        public void AddError(string message, Exception ex)
        {
            Errors.Add(new BusinessError() { Message = message, ThrownException = ex });
        }

        public void AddError(string key, string message)
        {
            Errors.Add(new BusinessError() { Key = key, Message = message });
        }

        public void AddError(string key, string message, Exception ex)
        {
            Errors.Add(new BusinessError() { Key = key, Message = message, ThrownException = ex });
        }

        public string GetFullErrorMsgs(string lineBreakString)
        {
            string msgs = string.Empty;
            foreach(BusinessError error in Errors)
            {
                msgs += lineBreakString + error.Message;

                if (error.ThrownException != null)
                    msgs += ". StackTrace: " + error.ThrownException.StackTrace;
            }

            if (msgs.Length >= lineBreakString.Length)
                msgs = msgs.Remove(0, lineBreakString.Length);

            return msgs;
        }

        public string GetFriendlyErrorMsgs(string lineBreakString)
        {
            string msgs = string.Empty;
            foreach(BusinessError error in Errors)
            {
                msgs += lineBreakString + error.Message;
                if (error.ThrownException != null)
                    msgs += " ExceptionMessage: " + error.ThrownException.Message;
            }

            msgs.Replace("\r\n", lineBreakString);

            if (msgs.Length >= lineBreakString.Length)
                msgs = msgs.Remove(0, lineBreakString.Length);

            return msgs;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
