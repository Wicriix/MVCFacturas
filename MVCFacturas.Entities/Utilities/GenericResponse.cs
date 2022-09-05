using System;

namespace MVCFacturas.GenericResponseNameSpace
{
    public class GenericResponse
    {
        public bool OperationSucess { get; set;} 
        public object ObjectResponse { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime OperationDate { get; set; }


        public GenericResponse()
        {
            OperationSucess = true;
            SuccessMessage = string.Empty;
            ErrorMessage = string.Empty;   
            OperationDate = DateTime.Now;
        }
    }
}
