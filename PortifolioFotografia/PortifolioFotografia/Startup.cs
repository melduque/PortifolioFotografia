using PortifolioFotografia.Config;

namespace PortifolioFotografia {
    public class Startup {
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.Configure<ConfigDB>( opcoes => {
                opcoes.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                opcoes.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddControllersWithViews();
        }
    }
}
