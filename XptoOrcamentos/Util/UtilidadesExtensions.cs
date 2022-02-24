using System;

namespace XptoOrcamentos.Util
{
    public static class UtilidadesExtensions
    {
        public static string FormataCNPJ(this string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataCPF(this string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public static string SemFormatacao(this string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }
    }
}
