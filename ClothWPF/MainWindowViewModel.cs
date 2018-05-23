using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ClothWPF
{
    
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _nameVisibility;
        private bool _itemCodeVisibility;
        private bool _countVisibility;
        private bool _lenghtVisibility;
        private bool _retailVisibility;
        private bool _wholesaleVisibility;
        private bool _purchaseDolPrice;
        private bool _purchaseUahPrice;
        private bool _countryVisibility;


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