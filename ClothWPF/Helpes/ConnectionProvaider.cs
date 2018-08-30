using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Helpes
{
    public class ConnectionProvider
    {

        public delegate void ConectedDelegate(EfContext eFContext);

        public event ConectedDelegate Conected;
        public ConnectionProvider()
        {

        }
        public Task ConnectRun()
        {
            return Task.Run(() =>
            {
                EfContext context = new EfContext();
                context.Configuration.AutoDetectChangesEnabled = false;
                var c = context.Products.Count();
                Conected?.Invoke(context);
            });
        }
    }
}
