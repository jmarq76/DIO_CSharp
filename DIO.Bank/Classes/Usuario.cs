using System;

namespace DIO.Bank.Classes
{
    public class Usuario
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public Usuario(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool CadastarUsuario()
        {
            if (this.Username.Length > 7 && this.Password.Length > 7)
            {
                char[] ch = this.Password.ToCharArray();

                bool checkUpper = false;
                bool checkLower = false;
                bool checkSpec  = false;
                bool checkNumb  = false;
                bool checkWhite = false;

                foreach (var character in ch)
                {
                    if (char.IsSymbol(character) || char.IsPunctuation(character))
                    {
                        checkSpec = true;

                    } else if (char.IsUpper(character))
                    {
                        checkUpper = true;

                    } else if (char.IsLower(character))
                    {
                        checkLower = true;

                    } else if (char.IsNumber(character))
                    {
                        checkNumb = true;

                    } else if (char.IsWhiteSpace(character))
                    {
                        Console.WriteLine("Espaço em branco não aceite");
                        checkWhite = true;
                        break;
                    }
                }

                if (checkUpper && checkLower && checkSpec && checkNumb && !checkWhite)
                {
                    Console.WriteLine();
                    Console.WriteLine("Usuário criado com sucesso!");
                    return true;
                }

                Console.WriteLine("Usuário não criado. Regra para criação de senha não cumprida");
                return false;
                
                
            }

            if (this.Username.Length < 8)
            {
                Console.WriteLine("Usuario tem menos de 8 caracteres");
            } else if (this.Password.Length < 8)
            {
                Console.WriteLine("Senha tem menos de 8 caracteres");
            } else
            {
                Console.WriteLine("Usuario e Senha têm menos de 8 caracteres");
            }
            return false;
            
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += this.Username + " | ";
            retorno += this.Password;
            return retorno;
        }

        public bool Equals(Usuario usuarioConferir)
        {
            if (this.Username.ToString().Equals(usuarioConferir.Username) && this.Password.ToString().Equals(usuarioConferir.Password))
            {
                return true;
            }

            return false;
        }
    }
}