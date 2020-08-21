using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Models
{
    public class Noticia
    {
        public int NoticiaID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int AutorID { get; set; }
        public Autor Autor { get; set; }


        //explicación de mapeo cuando en la base de datos los campos
        //tienen otro nombre
        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Noticia> mapeoNoticia)
            {
                //mapeo de llave primaria
                mapeoNoticia.HasKey(x => x.NoticiaID);
                //mapeo de columnas de tabla
                mapeoNoticia.Property(x => x.Titulo).HasColumnName("Titulo");
                mapeoNoticia.Property(x => x.Descripcion).HasColumnName("Descripcion");
                //mapeo de tabla completa
                mapeoNoticia.ToTable("Noticia");
                //mapeo de llave foranea
                mapeoNoticia.HasOne(x => x.Autor);
            }
        }
    }
}
