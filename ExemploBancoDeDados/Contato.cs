using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploBancoDeDados
{
    public class Contato
    {
        public string Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Fone { get; }

        public Contato(string nome, string email, string fone)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            Fone = fone;
        }

        public Contato(string id, string nome, string email, string fone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Fone = fone;
        }

    }
}
