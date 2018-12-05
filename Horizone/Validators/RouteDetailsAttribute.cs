using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Validators
{
    [AttributeUsage(AttributeTargets.Property)] 
    public class RouteDetailsAttribute : ValidationAttribute
    {
        public int MinimumAge { get; set; }
        public int? maximumAge;
        public int MaximumAge
        {
            get { return (int)maximumAge; }
            set { maximumAge = value; }
        }

        public RouteDetailsAttribute(int minimumAge)
        {
            this.MinimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime && value != null)
            {

                if (maximumAge == null)
                {
                    return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value;
                }
                else
                {
                    return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value
                        && ((DateTime)value).AddYears(this.MaximumAge) >= DateTime.Now;
                }

            }
            return false; 
            throw new ArgumentException("Le type doit être de type DateTime");
        }

        public override string FormatErrorMessage(string name)
        {
            if (this.maximumAge == null)
            {
                return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString());
            }
            else
            {
                return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString(), this.MaximumAge.ToString());
            }
        }
    }
}