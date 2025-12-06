using System;
using System.Text;

namespace sistema_comercio
{
    public static class GeradorPix
    {
        
        private const string CHAVE_PIX = "+5599992012092";
        private const string NOME_COMERCIANTE = "COMERCIAL GALDINO"; 
        private const string CIDADE_COMERCIANTE = "CAXIAS-MA"; 

        public static string GerarCopiaCola(decimal valor)
        {
            string valorString = valor.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            // Montagem do Payload (Padrão EMV QRCPS)
            string payload =
                "000201" +
                "26" + (14 + CHAVE_PIX.Length + 4 + 4).ToString("00") + // Tamanho do campo 26
                    "0014BR.GOV.BCB.PIX" +
                    "01" + CHAVE_PIX.Length.ToString("00") + CHAVE_PIX +
                "52040000" + // Categoria do Comerciante
                "5303986" +  // Moeda (BRL)
                "54" + valorString.Length.ToString("00") + valorString +
                "5802BR" +   // País
                "59" + NOME_COMERCIANTE.Length.ToString("00") + NOME_COMERCIANTE +
                "60" + CIDADE_COMERCIANTE.Length.ToString("00") + CIDADE_COMERCIANTE +
                "6207" +     // Campo Adicional (TxID)
                    "0503***" +
                "6304";      // CRC16 (Calculado abaixo)

            string crc = CalcularCRC16(payload);
            return payload + crc;
        }

        private static string CalcularCRC16(string data)
        {
            int crc = 0xFFFF;
            int polynomial = 0x1021;
            byte[] bytes = Encoding.ASCII.GetBytes(data);

            foreach (byte b in bytes)
            {
                for (int i = 0; i < 8; i++)
                {
                    bool bit = ((b >> (7 - i) & 1) == 1);
                    bool c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit) crc ^= polynomial;
                }
            }
            return (crc & 0xFFFF).ToString("X4");
        }
    }
}