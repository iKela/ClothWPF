using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ClothWPF
{
    
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _nameVisibility = Properties.Settings.Default.DGNameVisibility;
        private bool _itemCodeVisibility = Properties.Settings.Default.DGItemCodeVisibility;
        private bool _countVisibility = Properties.Settings.Default.DGCountVisibility;
        private bool _lenghtVisibility = Properties.Settings.Default.DGLenghtVisibility;
        private bool _retailVisibility = Properties.Settings.Default.DGRetailVisibility;
        private bool _wholesaleVisibility = Properties.Settings.Default.DGWholesaleVisibility;
        private bool _purchaseDolPrice = Properties.Settings.Default.DGPurchaseDolPrice;
        private bool _purchaseUahPrice = Properties.Settings.Default.DGPurchaseUahPrice;
        private bool _countryVisibility = Properties.Settings.Default.DGCountryVisibility;        

        //private bool _itemCode;
        #region Gets & Sets
        public bool NameVisibility
        {
            get { return _nameVisibility; }
            set
            {
                _nameVisibility = value;
                OnPropertyChanged(nameof(NameVisibility));
            }
        }
        public bool ItemCodeVisibility
        {
            get { return _itemCodeVisibility; }
            set
            {
                _itemCodeVisibility = value;
                OnPropertyChanged(nameof(ItemCodeVisibility));
            }
        }
        public bool CountVisibility
        {
            get { return _countVisibility; }
            set
            {
                _countVisibility = value;
                OnPropertyChanged(nameof(CountVisibility));
            }
        }
        public bool LenghtVisibility
        {
            get { return _lenghtVisibility; }
            set
            {
                _lenghtVisibility = value;
                OnPropertyChanged(nameof(LenghtVisibility));
            }
        }
        public bool RetailVisibility
        {
            get { return _retailVisibility; }
            set
            {
                _retailVisibility = value;
                OnPropertyChanged(nameof(RetailVisibility));
            }
        }
        public bool WholeSaleVisibility
        {
            get { return _wholesaleVisibility; }
            set
            {
                _wholesaleVisibility = value;
                OnPropertyChanged(nameof(WholeSaleVisibility));
            }
        }
        public bool PurchaseDolPrice
        {
            get { return _purchaseDolPrice; }
            set
            {
                _purchaseDolPrice = value;
                OnPropertyChanged(nameof(PurchaseDolPrice));
            }
        }
        public bool PurchaseUahPrice
        {
            get { return _purchaseUahPrice; }
            set
            {
                _purchaseUahPrice = value;
                OnPropertyChanged(nameof(PurchaseDolPrice));
            }
        }
        public bool CountryVisibility
        {
            get { return _countryVisibility; }
            set
            {
                _countryVisibility = value;
                OnPropertyChanged(nameof(CountryVisibility));
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