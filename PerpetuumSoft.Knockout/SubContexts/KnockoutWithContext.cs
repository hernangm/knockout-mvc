using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
  public class KnockoutWithContext<TModel> : KnockoutCommonRegionContext<TModel>
  {
    public KnockoutWithContext(ViewContext viewContext, string expression, TModel model) : base(viewContext, expression)
    {
        this.model = model;
    }

    public override string Keyword
    {
      get
      {
        return "with";
      }
    }
  }
}