using System;
using Boolean = System.Boolean;
using String = System.String;
using List = Android.Runtime.JavaList;
using Map = Android.Runtime.JavaDictionary;
using Android.OS;

namespace Com.Android.Vending.Billing
{
    public interface IInAppBillingService : global::Android.OS.IInterface
    {
        int IsBillingSupported(int apiVersion, String packageName, String type);
        global::Android.OS.Bundle GetSkuDetails(int apiVersion, String packageName, String type, global::Android.OS.Bundle skusBundle);
        global::Android.OS.Bundle GetBuyIntent(int apiVersion, String packageName, String sku, String type, String developerPayload);
        global::Android.OS.Bundle GetPurchases(int apiVersion, String packageName, String type, String continuationToken);
        int ConsumePurchase(int apiVersion, String packageName, String purchaseToken);
    }

    public abstract class IInAppBillingServiceStub : global::Android.OS.Binder, global::Android.OS.IInterface, Com.Android.Vending.Billing.IInAppBillingService
    {
        const string descriptor = "com.android.vending.billing.IInAppBillingService";
        public IInAppBillingServiceStub()
        {
            this.AttachInterface(this, descriptor);
        }

        public static Com.Android.Vending.Billing.IInAppBillingService AsInterface(global::Android.OS.IBinder obj)
        {
            if (obj == null)
                return null;
            var iin = (global::Android.OS.IInterface)obj.QueryLocalInterface(descriptor);
            if (iin != null && iin is Com.Android.Vending.Billing.IInAppBillingService)
                return (Com.Android.Vending.Billing.IInAppBillingService)iin;
            return new Proxy(obj);
        }

        public global::Android.OS.IBinder AsBinder()
        {
            return this;
        }

        protected override bool OnTransact(int code, global::Android.OS.Parcel data, global::Android.OS.Parcel reply, int flags)
        {
            switch (code)
            {
                case global::Android.OS.BinderConsts.InterfaceTransaction:
                    reply.WriteString(descriptor);
                    return true;

                case TransactionIsBillingSupported:
                    {
                        data.EnforceInterface(descriptor);
                        int arg0 = default(int);
                        arg0 = data.ReadInt();
                        String arg1 = default(String);
                        arg1 = data.ReadString();
                        String arg2 = default(String);
                        arg2 = data.ReadString();
                        var result = this.IsBillingSupported(arg0, arg1, arg2);
                        reply.WriteInt(result);
                        data.WriteInt(arg0);
                        data.WriteString(arg1);
                        data.WriteString(arg2);
                        return true;
                    }

                case TransactionGetSkuDetails:
                    {
                        data.EnforceInterface(descriptor);
                        int arg0 = default(int);
                        arg0 = data.ReadInt();
                        String arg1 = default(String);
                        arg1 = data.ReadString();
                        String arg2 = default(String);
                        arg2 = data.ReadString();
                        global::Android.OS.Bundle arg3 = default(global::Android.OS.Bundle);
                        //arg3 = global::Android.OS.BundleStub.AsInterface(data.ReadStrongBinder());
                        var result = this.GetSkuDetails(arg0, arg1, arg2, arg3);
                        if (result != null) { reply.WriteInt(1); result.WriteToParcel(reply, global::Android.OS.ParcelableWriteFlags.ReturnValue); } else reply.WriteInt(0);
                        data.WriteInt(arg0);
                        data.WriteString(arg1);
                        data.WriteString(arg2);
                        return true;
                    }

                case TransactionGetBuyIntent:
                    {
                        data.EnforceInterface(descriptor);
                        int arg0 = default(int);
                        arg0 = data.ReadInt();
                        String arg1 = default(String);
                        arg1 = data.ReadString();
                        String arg2 = default(String);
                        arg2 = data.ReadString();
                        String arg3 = default(String);
                        arg3 = data.ReadString();
                        String arg4 = default(String);
                        arg4 = data.ReadString();
                        var result = this.GetBuyIntent(arg0, arg1, arg2, arg3, arg4);
                        if (result != null) { reply.WriteInt(1); result.WriteToParcel(reply, global::Android.OS.ParcelableWriteFlags.ReturnValue); } else reply.WriteInt(0);
                        data.WriteInt(arg0);
                        data.WriteString(arg1);
                        data.WriteString(arg2);
                        data.WriteString(arg3);
                        data.WriteString(arg4);
                        return true;
                    }

                case TransactionGetPurchases:
                    {
                        data.EnforceInterface(descriptor);
                        int arg0 = default(int);
                        arg0 = data.ReadInt();
                        String arg1 = default(String);
                        arg1 = data.ReadString();
                        String arg2 = default(String);
                        arg2 = data.ReadString();
                        String arg3 = default(String);
                        arg3 = data.ReadString();
                        var result = this.GetPurchases(arg0, arg1, arg2, arg3);
                        if (result != null) { reply.WriteInt(1); result.WriteToParcel(reply, global::Android.OS.ParcelableWriteFlags.ReturnValue); } else reply.WriteInt(0);
                        data.WriteInt(arg0);
                        data.WriteString(arg1);
                        data.WriteString(arg2);
                        data.WriteString(arg3);
                        return true;
                    }

                case TransactionConsumePurchase:
                    {
                        data.EnforceInterface(descriptor);
                        int arg0 = default(int);
                        arg0 = data.ReadInt();
                        String arg1 = default(String);
                        arg1 = data.ReadString();
                        String arg2 = default(String);
                        arg2 = data.ReadString();
                        var result = this.ConsumePurchase(arg0, arg1, arg2);
                        reply.WriteInt(result);
                        data.WriteInt(arg0);
                        data.WriteString(arg1);
                        data.WriteString(arg2);
                        return true;
                    }

            }
            return base.OnTransact(code, data, reply, flags);
        }

        public class Proxy : Java.Lang.Object, Com.Android.Vending.Billing.IInAppBillingService
        {
            global::Android.OS.IBinder remote;

            public Proxy(global::Android.OS.IBinder remote)
            {
                this.remote = remote;
            }

            public global::Android.OS.IBinder AsBinder()
            {
                return remote;
            }

            public string GetInterfaceDescriptor()
            {
                return descriptor;
            }

            public int IsBillingSupported(int apiVersion, String packageName, String type)
            {
                global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain();

                global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain();
                int __result = default(int);

                try
                {
                    __data.WriteInterfaceToken(descriptor);
                    __data.WriteInt(apiVersion);
                    __data.WriteString(packageName);
                    __data.WriteString(type);
                    remote.Transact(IInAppBillingServiceStub.TransactionIsBillingSupported, __data, __reply, 0);
                    __reply.ReadException();
                    __result = __reply.ReadInt();

                }
                finally
                {
                    __reply.Recycle();
                    __data.Recycle();
                }
                return __result;

            }


            public global::Android.OS.Bundle GetSkuDetails(int apiVersion, String packageName, String type, global::Android.OS.Bundle skusBundle)
            {
                global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain();

                global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain();
                global::Android.OS.Bundle __result = default(global::Android.OS.Bundle);

                try
                {
                    __data.WriteInterfaceToken(descriptor);
                    __data.WriteInt(apiVersion);
                    __data.WriteString(packageName);
                    __data.WriteString(type);
                    if (skusBundle != null) { __data.WriteInt(1); skusBundle.WriteToParcel(__data, global::Android.OS.ParcelableWriteFlags.None); } else __data.WriteInt(0);
                    remote.Transact(IInAppBillingServiceStub.TransactionGetSkuDetails, __data, __reply, 0);
                    __reply.ReadException();
                    //__result = global::Android.OS.BundleStub.AsInterface(__reply.ReadStrongBinder());

                }
                finally
                {
                    __reply.Recycle();
                    __data.Recycle();
                }
                return __result;

            }


            public global::Android.OS.Bundle GetBuyIntent(int apiVersion, String packageName, String sku, String type, String developerPayload)
            {
                global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain();

                global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain();
                global::Android.OS.Bundle __result = default(global::Android.OS.Bundle);

                try
                {
                    __data.WriteInterfaceToken(descriptor);
                    __data.WriteInt(apiVersion);
                    __data.WriteString(packageName);
                    __data.WriteString(sku);
                    __data.WriteString(type);
                    __data.WriteString(developerPayload);
                    remote.Transact(IInAppBillingServiceStub.TransactionGetBuyIntent, __data, __reply, 0);
                    __reply.ReadException();
                    //__result = global::Android.OS.BundleStub.AsInterface(__reply.ReadStrongBinder());

                }
                finally
                {
                    __reply.Recycle();
                    __data.Recycle();
                }
                return __result;

            }


            public global::Android.OS.Bundle GetPurchases(int apiVersion, String packageName, String type, String continuationToken)
            {
                global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain();

                global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain();
                global::Android.OS.Bundle __result = default(global::Android.OS.Bundle);

                try
                {
                    __data.WriteInterfaceToken(descriptor);
                    __data.WriteInt(apiVersion);
                    __data.WriteString(packageName);
                    __data.WriteString(type);
                    __data.WriteString(continuationToken);
                    remote.Transact(IInAppBillingServiceStub.TransactionGetPurchases, __data, __reply, 0);
                    __reply.ReadException();
                    //__result = global::Android.OS.BundleStub.AsInterface(__reply.ReadStrongBinder());

                }
                finally
                {
                    __reply.Recycle();
                    __data.Recycle();
                }
                return __result;

            }


            public int ConsumePurchase(int apiVersion, String packageName, String purchaseToken)
            {
                global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain();

                global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain();
                int __result = default(int);

                try
                {
                    __data.WriteInterfaceToken(descriptor);
                    __data.WriteInt(apiVersion);
                    __data.WriteString(packageName);
                    __data.WriteString(purchaseToken);
                    remote.Transact(IInAppBillingServiceStub.TransactionConsumePurchase, __data, __reply, 0);
                    __reply.ReadException();
                    __result = __reply.ReadInt();

                }
                finally
                {
                    __reply.Recycle();
                    __data.Recycle();
                }
                return __result;

            }


        }

        internal const int TransactionIsBillingSupported = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 0;

        internal const int TransactionGetSkuDetails = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 1;

        internal const int TransactionGetBuyIntent = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 2;

        internal const int TransactionGetPurchases = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 3;

        internal const int TransactionConsumePurchase = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 4;

        public abstract int IsBillingSupported(int apiVersion, String packageName, String type);

        public abstract global::Android.OS.Bundle GetSkuDetails(int apiVersion, String packageName, String type, global::Android.OS.Bundle skusBundle);

        public abstract global::Android.OS.Bundle GetBuyIntent(int apiVersion, String packageName, String sku, String type, String developerPayload);

        public abstract global::Android.OS.Bundle GetPurchases(int apiVersion, String packageName, String type, String continuationToken);

        public abstract int ConsumePurchase(int apiVersion, String packageName, String purchaseToken);

    }
}