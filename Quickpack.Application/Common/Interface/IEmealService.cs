using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Common.Interface
{
    public interface IEmealService
    {
        string EnviarCorreo(string destinatario, string asunto, string cuerpoHtml, bool esHtml = true);
    }
}
