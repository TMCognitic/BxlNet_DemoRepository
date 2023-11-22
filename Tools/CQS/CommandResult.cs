using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.CQS
{
    public class CommandResult : ICommandResult
    {   
        public static ICommandResult Success()
        {
            return new CommandResult(true, null);
        }

        public static ICommandResult Failure(string errorMessage)
        {
            ArgumentNullException.ThrowIfNull(errorMessage);

            if(errorMessage.Trim().Length == 0)
                throw new ArgumentException("Le massage d'erreur ne peut pas être vide");

            return new CommandResult(false, errorMessage);
        }

        public bool IsSuccess { get; init; }
        public string? ErrorMessage { get; init; }

        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }

        private CommandResult(bool isSuccess, string? errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}
