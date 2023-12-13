using System.ComponentModel.DataAnnotations;

namespace BufaloCargo.Utils.Attributes
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "Debe Seleccionar un registro";
        public NotEmptyAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(int))
                {
                    switch (value)
                    {
                        case int guid:
                            return guid != 0;
                        default:
                            return true;
                    }
                }
                if (value.GetType() == typeof(Guid))
                {
                    switch (value)
                    {
                        case Guid guid:
                            return guid != Guid.Empty;
                        default:
                            return true;
                    }
                }
                if (value.GetType() == typeof(string))
                {
                    switch (value)
                    {
                        case string guid:
                            return Convert.ToInt32(guid) != 0;
                        default:
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
