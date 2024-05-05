using InventSys.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.AccesoDatos.Configuracion
{
    public class MdAlmacenConfig: IEntityTypeConfiguration<MdAlmacen>
    {
        public void Configure(EntityTypeBuilder<MdAlmacen> builder)
        {
            builder.ToTable("KAlmacenes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descrip).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Direccion).HasMaxLength(300);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}
