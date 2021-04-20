namespace DIO.Bank.Classes
{
    public class LogHistory
    {
        private int NumLog { get; set;}

        private TipoLog TipoLog { get; set; }

        private string Nome { get; set; }

        private double Valor { get; set; }

        private string Descricao { get; set; }

        public LogHistory(int numLog, TipoLog tipoLog, string nome, double valor, string descricao)
        {
            this.NumLog = numLog;
            this.TipoLog = tipoLog;
            this.Nome = nome;
            this.Valor = valor;
            this.Descricao = descricao;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "NumLog: " + this.NumLog + " | ";
            retorno += "TipoLog: " + this.TipoLog + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Valor: " + this.Valor + " | ";
            retorno += "Descrição: " + this.Descricao;
            return retorno;
        }
    }
}