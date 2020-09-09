using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Utilities.IoC
{
  public interface IFrameWorkModule
  {
      void Load(IServiceCollection serviceCollection);
  }
}
