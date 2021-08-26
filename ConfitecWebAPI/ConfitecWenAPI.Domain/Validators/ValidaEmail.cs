using System.Text.RegularExpressions;

namespace ConfitecWenAPI.Domain.Validators
{
    public static class ValidaEmail
    {
        public static bool Valido(string email) =>
            new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$").IsMatch(email);
    }
}
