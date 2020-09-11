using System.Linq;
using Framework.Utilities.Results;

namespace Framework.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            return logics.FirstOrDefault(result => !result.Success);// hata yoksa null hata var sa IREsult dön
        }
    }
}
