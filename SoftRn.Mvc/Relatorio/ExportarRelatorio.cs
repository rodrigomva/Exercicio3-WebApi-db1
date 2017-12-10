using System.Net;
using System.Net.Http;

namespace Exercicio3.Mvc.Relatorio
{
    /// <summary>
    /// Class responsavel por fazer a exportação dos relatórios gerados
    /// </summary>
    public abstract class  ExportarRelatorio
    {
        /// <summary>
        /// Método que retorna o relatório na URL
        /// <param name="report">Class do Report</param>
        /// </summary>
        public static HttpResponseMessage Simples(Microsoft.Reporting.WebForms.LocalReport report)
        {
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streams = null;
            Microsoft.Reporting.WebForms.Warning[] warnings = null;
            byte[] bytes = report.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streams, out warnings);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(bytes);
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);
            return result;
        }
    }
}