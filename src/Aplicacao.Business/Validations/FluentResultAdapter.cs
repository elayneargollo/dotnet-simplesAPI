using Aplicacao.Core.Exceptions.BusinessException;
using FluentValidation.Results;

namespace Aplicacao.Business.Validations
{
    public static class FluentResultAdapter
    {
        public static void VerificaErros(ValidationResult result)
        {
            if (result.Errors != null)
            {
                throw new BusinessException(result.Errors[0].ErrorMessage);
            }
        }
    }
}

