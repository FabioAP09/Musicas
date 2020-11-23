using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio.Musicas.Generica.Entity
{
    public abstract class RadioEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public RadioEntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfiguararChaveEstrangeira();
        }

        protected abstract void ConfiguararChaveEstrangeira();
       
        protected abstract void ConfigurarChavePrimaria();
        

        protected abstract void ConfigurarCamposTabela();
        

        protected abstract void ConfigurarNomeTabela();
        
    }
}
