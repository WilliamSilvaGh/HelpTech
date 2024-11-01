using Foundation;
using UIKit;
using CoreGraphics;

namespace HelpTech
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Subscribing to keyboard notifications
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardWillShow);
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardWillHide);

            return base.FinishedLaunching(application, launchOptions);
        }

        void OnKeyboardWillShow(NSNotification notification)
        {
            var keyboardFrame = UIKeyboard.FrameEndFromNotification(notification);
            AdjustLayoutForKeyboard(keyboardFrame.Height);
        }

        void OnKeyboardWillHide(NSNotification notification)
        {
            AdjustLayoutForKeyboard(0);
        }

        void AdjustLayoutForKeyboard(nfloat keyboardHeight)
        {
            var mainView = UIApplication.SharedApplication.KeyWindow.RootViewController.View;
            if (mainView != null)
            {
                UIView.Animate(0.3, () => 
                {
                    var insets = mainView.SafeAreaInsets;
                    mainView.Frame = new CGRect(mainView.Frame.X, mainView.Frame.Y, mainView.Frame.Width, UIScreen.MainScreen.Bounds.Height - keyboardHeight - insets.Bottom);
                });
            }
        }
    }
}
