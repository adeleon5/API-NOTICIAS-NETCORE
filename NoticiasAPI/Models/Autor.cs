using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Models
{
    public class Autor
    {
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //explicación de mapeo cuando en la base de datos los campos
        //tienen otro nombre
        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Autor> mapeoAutor)
            {
                //mapeo de llave primaria
                mapeoAutor.HasKey(x => x.AutorID);
                //mapeo de columnas de tabla
                mapeoAutor.Property(x => x.Nombre).HasColumnName("Nombre");
                //mapeo de tabla completa
                mapeoAutor.ToTable("Autor");
            }
        }
    }
}
