using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.Notifications
{
    public class DomainException : Exception
    {
        public DomainException(string mensagem) : base(mensagem) { }

        public DomainException(string mensagem, Exception exception) : base(mensagem, exception) { }
    }

    public class EmptyFileException : Exception
    {
        public EmptyFileException(string mensagem) : base(mensagem) { }

        public EmptyFileException(string mensagem, Exception exception) : base(mensagem, exception) { }
    }

    public class ValidacaoException : DomainException
    {
        public ValidacaoException(string mensagem) : base(mensagem) { }
    }

    public class ManuseioException : DomainException
    {
        public ManuseioException(string mensagem) : base(mensagem) { }
    }

    public class CaptchaExeption : DomainException
    {
        public CaptchaExeption(string mensagem) : base(mensagem) { }
    }

    public class CvvException : DomainException
    {
        public CvvException(string mensagem) : base(mensagem) { }
    }

    public class BloqueioCartaoException : CvvException
    {
        public BloqueioCartaoException(string mensagem) : base(mensagem) { }
    }

    public class VerificarSenhaCadastroCartaoException : DomainException
    {
        public VerificarSenhaCadastroCartaoException(string mensagem) : base(mensagem) { }
    }

}