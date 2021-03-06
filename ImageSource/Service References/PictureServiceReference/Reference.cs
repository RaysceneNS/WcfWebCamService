﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageSource.PictureServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PictureServiceReference.IPictureService")]
    public interface IPictureService {
        
        // CODEGEN: Generating message contract since the wrapper name (FileUploadMessage) of message FileUploadMessage does not match the default value (UploadImage)
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPictureService/UploadImage")]
        void UploadImage(ImageSource.PictureServiceReference.FileUploadMessage request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IPictureService/UploadImage")]
        System.IAsyncResult BeginUploadImage(ImageSource.PictureServiceReference.FileUploadMessage request, System.AsyncCallback callback, object asyncState);
        
        void EndUploadImage(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPictureService/DownloadImage", ReplyAction="http://tempuri.org/IPictureService/DownloadImageResponse")]
        byte[] DownloadImage(string key);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IPictureService/DownloadImage", ReplyAction="http://tempuri.org/IPictureService/DownloadImageResponse")]
        System.IAsyncResult BeginDownloadImage(string key, System.AsyncCallback callback, object asyncState);
        
        byte[] EndDownloadImage(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileUploadMessage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FileUploadMessage {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string Key;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public byte[] FileBytes;
        
        public FileUploadMessage() {
        }
        
        public FileUploadMessage(string Key, byte[] FileBytes) {
            this.Key = Key;
            this.FileBytes = FileBytes;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPictureServiceChannel : ImageSource.PictureServiceReference.IPictureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DownloadImageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DownloadImageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public byte[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PictureServiceClient : System.ServiceModel.ClientBase<ImageSource.PictureServiceReference.IPictureService>, ImageSource.PictureServiceReference.IPictureService {
        
        private BeginOperationDelegate onBeginUploadImageDelegate;
        
        private EndOperationDelegate onEndUploadImageDelegate;
        
        private System.Threading.SendOrPostCallback onUploadImageCompletedDelegate;
        
        private BeginOperationDelegate onBeginDownloadImageDelegate;
        
        private EndOperationDelegate onEndDownloadImageDelegate;
        
        private System.Threading.SendOrPostCallback onDownloadImageCompletedDelegate;
        
        public PictureServiceClient() {
        }
        
        public PictureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PictureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PictureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PictureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> UploadImageCompleted;
        
        public event System.EventHandler<DownloadImageCompletedEventArgs> DownloadImageCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void ImageSource.PictureServiceReference.IPictureService.UploadImage(ImageSource.PictureServiceReference.FileUploadMessage request) {
            base.Channel.UploadImage(request);
        }
        
        public void UploadImage(string Key, byte[] FileBytes) {
            ImageSource.PictureServiceReference.FileUploadMessage inValue = new ImageSource.PictureServiceReference.FileUploadMessage();
            inValue.Key = Key;
            inValue.FileBytes = FileBytes;
            ((ImageSource.PictureServiceReference.IPictureService)(this)).UploadImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ImageSource.PictureServiceReference.IPictureService.BeginUploadImage(ImageSource.PictureServiceReference.FileUploadMessage request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUploadImage(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUploadImage(string Key, byte[] FileBytes, System.AsyncCallback callback, object asyncState) {
            ImageSource.PictureServiceReference.FileUploadMessage inValue = new ImageSource.PictureServiceReference.FileUploadMessage();
            inValue.Key = Key;
            inValue.FileBytes = FileBytes;
            return ((ImageSource.PictureServiceReference.IPictureService)(this)).BeginUploadImage(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndUploadImage(System.IAsyncResult result) {
            base.Channel.EndUploadImage(result);
        }
        
        private System.IAsyncResult OnBeginUploadImage(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string Key = ((string)(inValues[0]));
            byte[] FileBytes = ((byte[])(inValues[1]));
            return this.BeginUploadImage(Key, FileBytes, callback, asyncState);
        }
        
        private object[] OnEndUploadImage(System.IAsyncResult result) {
            this.EndUploadImage(result);
            return null;
        }
        
        private void OnUploadImageCompleted(object state) {
            if ((this.UploadImageCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UploadImageCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UploadImageAsync(string Key, byte[] FileBytes) {
            this.UploadImageAsync(Key, FileBytes, null);
        }
        
        public void UploadImageAsync(string Key, byte[] FileBytes, object userState) {
            if ((this.onBeginUploadImageDelegate == null)) {
                this.onBeginUploadImageDelegate = new BeginOperationDelegate(this.OnBeginUploadImage);
            }
            if ((this.onEndUploadImageDelegate == null)) {
                this.onEndUploadImageDelegate = new EndOperationDelegate(this.OnEndUploadImage);
            }
            if ((this.onUploadImageCompletedDelegate == null)) {
                this.onUploadImageCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUploadImageCompleted);
            }
            base.InvokeAsync(this.onBeginUploadImageDelegate, new object[] {
                        Key,
                        FileBytes}, this.onEndUploadImageDelegate, this.onUploadImageCompletedDelegate, userState);
        }
        
        public byte[] DownloadImage(string key) {
            return base.Channel.DownloadImage(key);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDownloadImage(string key, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDownloadImage(key, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public byte[] EndDownloadImage(System.IAsyncResult result) {
            return base.Channel.EndDownloadImage(result);
        }
        
        private System.IAsyncResult OnBeginDownloadImage(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string key = ((string)(inValues[0]));
            return this.BeginDownloadImage(key, callback, asyncState);
        }
        
        private object[] OnEndDownloadImage(System.IAsyncResult result) {
            byte[] retVal = this.EndDownloadImage(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDownloadImageCompleted(object state) {
            if ((this.DownloadImageCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DownloadImageCompleted(this, new DownloadImageCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DownloadImageAsync(string key) {
            this.DownloadImageAsync(key, null);
        }
        
        public void DownloadImageAsync(string key, object userState) {
            if ((this.onBeginDownloadImageDelegate == null)) {
                this.onBeginDownloadImageDelegate = new BeginOperationDelegate(this.OnBeginDownloadImage);
            }
            if ((this.onEndDownloadImageDelegate == null)) {
                this.onEndDownloadImageDelegate = new EndOperationDelegate(this.OnEndDownloadImage);
            }
            if ((this.onDownloadImageCompletedDelegate == null)) {
                this.onDownloadImageCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDownloadImageCompleted);
            }
            base.InvokeAsync(this.onBeginDownloadImageDelegate, new object[] {
                        key}, this.onEndDownloadImageDelegate, this.onDownloadImageCompletedDelegate, userState);
        }
    }
}
