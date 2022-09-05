using MVCFacturas.ExternalConnections.GenericRepository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities.Specifications
{
    public class DetallesSpecifications: BaseSpecifications<Detalles>
    {
        public DetallesSpecifications(long idfactura)
            :base(f => idfactura >0 && f.IdFactura == idfactura)
        {
            Includes.Add(x => x.FacturasNavigation);
            Includes.Add(x => x.ProductoNavigation);
        }
    }
}
