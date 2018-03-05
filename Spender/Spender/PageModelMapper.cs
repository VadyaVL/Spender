using FreshMvvm;
using System;

namespace Spender
{
    public class PageModelMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            return pageModelType.AssemblyQualifiedName.Replace("ViewModel", "View");
        }
    }
}
