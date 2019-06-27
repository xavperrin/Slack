using ApiServerSlack.Models;

namespace ApiServerSlack.Tools
{
    public interface ILogger
    {
       string LoginGetToken(User idom);
    }
}