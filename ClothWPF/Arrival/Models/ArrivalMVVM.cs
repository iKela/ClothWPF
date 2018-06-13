using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ClothWPF.Arrival.Models
{
    public class ArrivalMVVM : INotifyPropertyChanged
    {
        private bool _numberVisibility = Properties.Settings.Default.DGArrivals_Number;
        private bool _dateVisibility = Properties.Settings.Default.DGArrivals_Date;
        private bool _purchaseTotalVisibility = Properties.Settings.Default.DGArrivals_PurchaseTotal;
        private bool _supplierVisibility = Properties.Settings.Default.DGArrivals_Supplier;
        private bool _receiverVisibility = Properties.Settings.Default.DGArrivals_Receiver;
        private bool _wholesaleVisibility = Properties.Settings.Default.DGArrivals_Wholesale;
        private bool _enterpriseVisibility = Properties.Settings.Default.DGArrivals_Enterprise;
        private bool _userVisibility = Properties.Settings.Default.DGArrivals_User;

        #region Gets & Sets
        public bool NumberVisibility
        {
            get { return _numberVisibility; }
            set
            {
                _numberVisibility = value;
                OnPropertyChanged(nameof(NumberVisibility));
            }
        }
        public bool DateVisibility
        {
            get { return _dateVisibility; }
            set
            {
                _dateVisibility = value;
                OnPropertyChanged(nameof(DateVisibility));
            }
        }
        public bool PurchaseVisibility
        {
            get { return _purchaseTotalVisibility; }
            set
            {
                _purchaseTotalVisibility = value;
                OnPropertyChanged(nameof(PurchaseVisibility));
            }
        }
        public bool SupplierVisibility
        {
            get { return _supplierVisibility; }
            set
            {
                _supplierVisibility = value;
                OnPropertyChanged(nameof(SupplierVisibility));
            }
        }
        public bool ReceiverVisibility
        {
            get { return _receiverVisibility; }
            set
            {
                _receiverVisibility = value;
                OnPropertyChanged(nameof(ReceiverVisibility));
            }
        }
        public bool WholesaleVisibility
        {
            get { return _wholesaleVisibility; }
            set
            {
                _wholesaleVisibility = value;
                OnPropertyChanged(nameof(WholesaleVisibility));
            }
        }
        public bool EnterpriseVisibility
        {
            get { return _enterpriseVisibility; }
            set
            {
                _enterpriseVisibility = value;
                OnPropertyChanged(nameof(EnterpriseVisibility));
            }
        }
        public bool UserVisibility
        {
            get { return _userVisibility; }
            set
            {
                _userVisibility = value;
                OnPropertyChanged(nameof(UserVisibility));
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
    }
}
