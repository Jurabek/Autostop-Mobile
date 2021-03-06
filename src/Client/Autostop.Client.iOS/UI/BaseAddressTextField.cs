﻿using Autostop.Client.Core.Enums;
using CoreGraphics;
using UIKit;

namespace Autostop.Client.iOS.UI
{
    public abstract class BaseAddressTextField : UITextField
    {
        private readonly UIView _leftImageView;
        private readonly UIActivityIndicatorView _loadingActivatyIndacator;

        private bool _loading;


        protected BaseAddressTextField()
        {
            _loadingActivatyIndacator = GetLocationsLoadActivityIndacator();
            _leftImageView = GetLocationsTextFieldLeftImageView();
            LeftViewMode = UITextFieldViewMode.Always;
            //LeftView = _leftImageView;
            BackgroundColor = UIColor.White;
            BorderStyle = UITextBorderStyle.None;
            Font = UIFont.SystemFontOfSize(14, UIFontWeight.Regular);
            TextAlignment = UITextAlignment.Center;
        }

        public virtual bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                if (_loading)
                {
                    _loadingActivatyIndacator.StartAnimating();
                    LeftView = _loadingActivatyIndacator;
                }
                else
                {
                    _loadingActivatyIndacator.StopAnimating();
                    //LeftView = _leftImageView;
                }
            }
        }

        public virtual AddressMode Mode { get; set; }

        protected abstract string LeftImageSource { get; }


        private UIActivityIndicatorView GetLocationsLoadActivityIndacator()
        {
            var activityIndicator =
                new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray) {ContentMode = UIViewContentMode.Center};
            var size = activityIndicator.Frame.Size;
            activityIndicator.Frame = new CGRect(0, 0, size.Width + 15, size.Height);
            return activityIndicator;
        }

        private UIView GetLocationsTextFieldLeftImageView()
        {
            var padding = 15;
            var size = 15;
            var icon = UIImage.FromFile(LeftImageSource);
            var outerView = new UIView(new CGRect(0, 0, size + padding, size));
            var iconView = new UIImageView(new CGRect(padding, 0, size, size))
            {
                Image = icon
            };

            outerView.AddSubview(iconView);
            return outerView;
        }
    }
}