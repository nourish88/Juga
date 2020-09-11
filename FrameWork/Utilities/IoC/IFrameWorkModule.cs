using Microsoft.Extensions.DependencyInjection;

namespace Framework.Utilities.IoC
{
    public interface IFrameWorkModule
  {
      void Load(IServiceCollection serviceCollection);
  }
}
