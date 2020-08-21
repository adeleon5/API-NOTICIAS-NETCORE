using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class NoticiaService
    {
        private readonly NoticiasDBContext _noticiaDbContext;
        public NoticiaService(NoticiasDBContext noticiaDbContext)
        {
            _noticiaDbContext = noticiaDbContext;
        }

        public List<Noticia> Obtener()
        {
           var resultado = _noticiaDbContext.Noticia.Include(x=>x.Autor).ToList();
            return resultado;
        }

        public Boolean AgregarNoticia(Noticia _noticia)
        {
            try
            {
                _noticiaDbContext.Noticia.Add(_noticia);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public Boolean EditarNoticia(Noticia noticia)
        {
            try
            {
                var noticiabasedatos = _noticiaDbContext.Noticia.Where(x => x.NoticiaID == noticia.NoticiaID).FirstOrDefault();
                noticiabasedatos.Titulo = noticia.Titulo;
                noticiabasedatos.Descripcion = noticia.Descripcion;
                noticiabasedatos.Contenido = noticia.Contenido;
                noticiabasedatos.Fecha = noticia.Fecha;
                noticiabasedatos.AutorID = noticia.AutorID;

                _noticiaDbContext.SaveChanges();

                return true;

            }catch(Exception error)
            {
                return false;
            }
        }

        public Boolean EliminarNoticia(int NoticiaID)
        {
            try
            {
                var noticiabasedatos = _noticiaDbContext.Noticia.Where(x => x.NoticiaID == NoticiaID).FirstOrDefault();
                _noticiaDbContext.Remove(noticiabasedatos);
                _noticiaDbContext.SaveChanges();

                return true;

            }catch(Exception error)
            {
                return false;
            }
        }

        public List<Autor> ListadoAutores()
        {
            try
            {
                var autores = _noticiaDbContext.Autor.ToList();
                return autores;

            }
            catch (Exception error)
            {
                return new List<Autor>();
            }
        }
    }
}
