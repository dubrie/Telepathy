﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace EchoSvcLib
{
    using System.Runtime.Serialization;
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StatisticInfo", Namespace="http://schemas.datacontract.org/2004/07/EchoSvcLib")]
    public partial class StatisticInfo : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.DateTime EndTimeField;
        
        private System.DateTime StartTimeField;
        
        private int TaskIdField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndTime
        {
            get
            {
                return this.EndTimeField;
            }
            set
            {
                this.EndTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartTime
        {
            get
            {
                return this.StartTimeField;
            }
            set
            {
                this.StartTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TaskId
        {
            get
            {
                return this.TaskIdField;
            }
            set
            {
                this.TaskIdField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IEchoSvc")]
public interface IEchoSvc
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoSvc/Echo", ReplyAction="http://tempuri.org/IEchoSvc/EchoResponse")]
    EchoResponse Echo(EchoRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoSvc/Echo", ReplyAction="http://tempuri.org/IEchoSvc/EchoResponse")]
    System.Threading.Tasks.Task<EchoResponse> EchoAsync(EchoRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoSvc/EchoData", ReplyAction="http://tempuri.org/IEchoSvc/EchoDataResponse")]
    EchoDataResponse EchoData(EchoDataRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoSvc/EchoData", ReplyAction="http://tempuri.org/IEchoSvc/EchoDataResponse")]
    System.Threading.Tasks.Task<EchoDataResponse> EchoDataAsync(EchoDataRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoSvc/GenerateLoad", ReplyAction="http://tempuri.org/IEchoSvc/GenerateLoadResponse")]
    GenerateLoadResponse GenerateLoad(GenerateLoadRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoSvc/GenerateLoad", ReplyAction="http://tempuri.org/IEchoSvc/GenerateLoadResponse")]
    System.Threading.Tasks.Task<GenerateLoadResponse> GenerateLoadAsync(GenerateLoadRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://hpc.microsoft.com/GenericService/IGenericService/GenericOperation", ReplyAction="http://hpc.microsoft.com/GenericService/IGenericService/GenericOperationResponse")]
    GenericServiceResponse GenericOperation(GenericServiceRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://hpc.microsoft.com/GenericService/IGenericService/GenericOperation", ReplyAction="http://hpc.microsoft.com/GenericService/IGenericService/GenericOperationResponse")]
    System.Threading.Tasks.Task<GenericServiceResponse> GenericOperationAsync(GenericServiceRequest request);
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="Echo", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class EchoRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public string input;
    
    public EchoRequest()
    {
    }
    
    public EchoRequest(string input)
    {
        this.input = input;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="EchoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class EchoResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public string EchoResult;
    
    public EchoResponse()
    {
    }
    
    public EchoResponse(string EchoResult)
    {
        this.EchoResult = EchoResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="EchoData", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class EchoDataRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public string dataClientId;
    
    public EchoDataRequest()
    {
    }
    
    public EchoDataRequest(string dataClientId)
    {
        this.dataClientId = dataClientId;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="EchoDataResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class EchoDataResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int EchoDataResult;
    
    public EchoDataResponse()
    {
    }
    
    public EchoDataResponse(int EchoDataResult)
    {
        this.EchoDataResult = EchoDataResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="GenerateLoad", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class GenerateLoadRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public double runMilliSeconds;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public byte[] dummyData;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
    public string fileData;
    
    public GenerateLoadRequest()
    {
    }
    
    public GenerateLoadRequest(double runMilliSeconds, byte[] dummyData, string fileData)
    {
        this.runMilliSeconds = runMilliSeconds;
        this.dummyData = dummyData;
        this.fileData = fileData;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="GenerateLoadResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class GenerateLoadResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public EchoSvcLib.StatisticInfo GenerateLoadResult;
    
    public GenerateLoadResponse()
    {
    }
    
    public GenerateLoadResponse(EchoSvcLib.StatisticInfo GenerateLoadResult)
    {
        this.GenerateLoadResult = GenerateLoadResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="GenericOperation", WrapperNamespace="http://hpc.microsoft.com/GenericService", IsWrapped=true)]
public partial class GenericServiceRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://hpc.microsoft.com/GenericService", Order=0)]
    public string args;
    
    public GenericServiceRequest()
    {
    }
    
    public GenericServiceRequest(string args)
    {
        this.args = args;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="GenericOperationResponse", WrapperNamespace="http://hpc.microsoft.com/GenericService", IsWrapped=true)]
public partial class GenericServiceResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://hpc.microsoft.com/GenericService", Order=0)]
    public string GenericOperationResult;
    
    public GenericServiceResponse()
    {
    }
    
    public GenericServiceResponse(string GenericOperationResult)
    {
        this.GenericOperationResult = GenericOperationResult;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IEchoSvcChannel : IEchoSvc, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class EchoSvcClient : System.ServiceModel.ClientBase<IEchoSvc>, IEchoSvc
{
    
    public EchoSvcClient()
    {
    }
    
    public EchoSvcClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public EchoSvcClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public EchoSvcClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public EchoSvcClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public EchoResponse Echo(EchoRequest request)
    {
        return base.Channel.Echo(request);
    }
    
    public System.Threading.Tasks.Task<EchoResponse> EchoAsync(EchoRequest request)
    {
        return base.Channel.EchoAsync(request);
    }
    
    public EchoDataResponse EchoData(EchoDataRequest request)
    {
        return base.Channel.EchoData(request);
    }
    
    public System.Threading.Tasks.Task<EchoDataResponse> EchoDataAsync(EchoDataRequest request)
    {
        return base.Channel.EchoDataAsync(request);
    }
    
    public GenerateLoadResponse GenerateLoad(GenerateLoadRequest request)
    {
        return base.Channel.GenerateLoad(request);
    }
    
    public System.Threading.Tasks.Task<GenerateLoadResponse> GenerateLoadAsync(GenerateLoadRequest request)
    {
        return base.Channel.GenerateLoadAsync(request);
    }
    
    public GenericServiceResponse GenericOperation(GenericServiceRequest request)
    {
        return base.Channel.GenericOperation(request);
    }
    
    public System.Threading.Tasks.Task<GenericServiceResponse> GenericOperationAsync(GenericServiceRequest request)
    {
        return base.Channel.GenericOperationAsync(request);
    }
}
