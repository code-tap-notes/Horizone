using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Validators
{
    [AttributeUsage(AttributeTargets.Property)] 
    public class DateAttribute : ValidationAttribute
    {
        public int MinimumDate { get; set; }
        public int? maximumDate;
        public int MaximumDate
        {
            get { return (int)maximumDate; }
            set { maximumDate = value; }
        }

        public DateAttribute(int minimumDate, int maximumDate)
        {
            this.MinimumDate = minimumDate;
            this.MaximumDate = maximumDate;
        }
        public DateAttribute(int minimumDate)
        {
            this.MinimumDate = minimumDate;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime && value != null)
            {

                if (maximumDate == null)
                {
                    return DateTime.Now.AddDays(this.MinimumDate) <= (DateTime)value;
                }
                else
                {
                    return DateTime.Now.AddDays(this.MinimumDate) <= (DateTime)value
                        && ((DateTime)value).AddDays(-this.MaximumDate) <= DateTime.Now;
                }

            }
            return false; 
            throw new ArgumentException("Le type doit être de type DateTime");
        }

        public override string FormatErrorMessage(string name)
        {
            if (this.maximumDate == null)
            {
                return string.Format(this.ErrorMessage, name, this.MinimumDate.ToString());
            }
            else
            {
                return string.Format(this.ErrorMessage, name, this.MinimumDate.ToString(), this.MaximumDate.ToString());
            }
        }
    }
}