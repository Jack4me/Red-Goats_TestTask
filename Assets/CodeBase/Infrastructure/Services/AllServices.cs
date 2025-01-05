
namespace CodeBase.Infrastructure.Services {
    public class AllServices {
        private static AllServices _instance;
        public static AllServices Container => _instance ?? (_instance = new AllServices());

        public void RegisterService<TService>(TService implimentation) where TService : IService{
            ImplementationServiceHolder<TService>.ServiceInstance = implimentation;
        }
            
        
        public TService GetService<TService>() where TService : IService{
            return ImplementationServiceHolder<TService>.ServiceInstance;
        }
        
        private static class ImplementationServiceHolder<TService> where TService : IService {
            public static TService ServiceInstance;
        }
    }
}