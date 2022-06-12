using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FransfordSystem.Models
{
    public class DbInit
    {
 

        public static void Iniz(FransforDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Unidad.Any())
            {
                return;
            }
            else
            {
                var unidad = new Unidad[]
                {
                    new Unidad{nombreUnidad="pg/mL"},
                    new Unidad{nombreUnidad="mUI/mL"},
                    new Unidad{nombreUnidad="mg/dL"},
                    new Unidad{nombreUnidad="U/L"},
                    new Unidad{nombreUnidad="UI/L"},
                    new Unidad{nombreUnidad="%"},
                    new Unidad{nombreUnidad="gr/dL"},
                    new Unidad{nombreUnidad="X mm^3"},
                    new Unidad{nombreUnidad="mcg"},
                    new Unidad{nombreUnidad="mc^3"},
                    new Unidad{nombreUnidad="UG/DL"}
                };
                foreach (Unidad Un in unidad)
                {
                    context.Add(Un);
                }
                context.SaveChanges();
            }
            if (context.Categoria.Any())
            {
                return;
            }
            else
            {
                var categoria = new Categoria[]
                  {
                    new Categoria{nombreCategoria="Endocrinología"},
                    new Categoria{nombreCategoria="Inmunología"},
                    new Categoria{nombreCategoria="Química Sanguinea"},
                    new Categoria{nombreCategoria="Coprología"},
                    new Categoria{nombreCategoria="Bacteriología"},
                    new Categoria{nombreCategoria="Marcadores Tumorales"},
                    new Categoria{nombreCategoria="Hematología"},
                    new Categoria{nombreCategoria="Urología"}

                  };
                foreach (Categoria Ca in categoria)
                {
                    context.Add(Ca);
                }
                context.SaveChanges();
            }
            if (context.Cliente.Any())
            {
                return;
            }
            if (context.Roles.Any())
            {
                return;
            }
            else
            {
                var roles = new IdentityRole[]
                    {
                    new IdentityRole{Name="Administrador",NormalizedName="ADMINISTRADOR"},
                    new IdentityRole{Name="Trabajador",NormalizedName="TRABAJADOR"},
                    
                    };
                foreach (IdentityRole Ro in roles)
                {
                    context.Add(Ro);

                }
                context.SaveChanges();
            }


            if (context.Examen.Any())
            {
                return;
            }
            else
            {
                var examen = new Examen[]
                    {
                    new Examen{idCategoria=1,nombreExamen="ACTH",PrecioExamen=1, nombreMuestra="SANGRE"},
                    new Examen{idCategoria=1,nombreExamen="FSH",PrecioExamen=2,nombreMuestra="SANGRE"},
                    new Examen{idCategoria=2,nombreExamen="FTA/ABS",PrecioExamen=3,nombreMuestra="SANGRE"},
                    new Examen{idCategoria=3,nombreExamen="FULL",PrecioExamen=4,nombreMuestra="SANGRE"},
                    new Examen{idCategoria=3,nombreExamen="GAMMA",PrecioExamen=5,nombreMuestra="SANGRE"}
                    };
                foreach (Examen Ex in examen)
                {
                    context.Add(Ex);

                }
                context.SaveChanges();
            }
            if (context.Descripcion.Any())
            {
                return;
            }
            else
            {
                var descripcion = new Descripcion[]
                      {
                    new Descripcion{idExamen=1,descripcionExamen="Hormona Adrenocorticotropa",valorMinimo=7f,valorMaximo=9f,idUnidad=1},
                    new Descripcion{idExamen=2,descripcionExamen="Fase Folicular",valorMinimo=3f,valorMaximo=8f,idUnidad=2},
                    new Descripcion{idExamen=3,descripcionExamen="Ciclo Medio",valorMinimo=4f,valorMaximo=13f,idUnidad=2},
                    new Descripcion{idExamen=4,descripcionExamen="Fase Lutea Media",valorMinimo=1f,valorMaximo=12f,idUnidad=2},
                    new Descripcion{idExamen=5,descripcionExamen="Post-Menopausia",valorMinimo=12f,valorMaximo=14f,idUnidad=2},

                      };
                foreach (Descripcion Des in descripcion)
                {
                    context.Add(Des);

                }
                context.SaveChanges();

            }
        }
    }
}