//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using DedDom.Annotations;

namespace DedDom
{
    using System;
    using System.Collections.Generic;
    
    public partial class visit:INotifyPropertyChanged
    {
        private bool? is_present;
        public int id_visit { get; set; }
        public int Id_student { get; set; }
        public int Id_visit_log { get; set; }

        public Nullable<bool> isPresent
        {
            get => is_present;
            set
            {
                is_present = value;
                OnPropertyChanged();
            }
        }

        public virtual student student { get; set; }
        public virtual visit_log visit_log { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
