using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionAmbatillo
{
   public class Lectura
    {

        private int _id;
        private string _medidor;
        private decimal _lec_ant;
        private decimal _lec_act;
        private decimal _total;
        private string _categoria;
        private string _estado;
        private string _observacion;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Medidor
        {
            get
            {
                return _medidor;
            }

            set
            {
                _medidor = value;
            }
        }

        public decimal Lec_ant
        {
            get
            {
                return _lec_ant;
            }

            set
            {
                _lec_ant = value;
            }
        }

        public decimal Lec_act
        {
            get
            {
                return _lec_act;
            }

            set
            {
                _lec_act = value;
            }
        }

        public decimal Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        public string Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _observacion;
            }

            set
            {
                _observacion = value;
            }
        }
    }

   



}
