// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/NimaRequest.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ChariswallServices.Protos {
  public static partial class NimaRequest
  {
    static readonly string __ServiceName = "NimaRequest.NimaRequest";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.RequestInput> __Marshaller_NimaRequest_RequestInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.RequestInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.ResultOutputRequest> __Marshaller_NimaRequest_ResultOutputRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.ResultOutputRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.RequestDetailInput> __Marshaller_NimaRequest_RequestDetailInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.RequestDetailInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.GeneralInputRequest> __Marshaller_NimaRequest_GeneralInputRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.GeneralInputRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.NewRequests> __Marshaller_NimaRequest_NewRequests = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.NewRequests.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.CodeInput> __Marshaller_NimaRequest_CodeInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.CodeInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ChariswallServices.Protos.CheckOutput> __Marshaller_NimaRequest_CheckOutput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ChariswallServices.Protos.CheckOutput.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ChariswallServices.Protos.RequestInput, global::ChariswallServices.Protos.ResultOutputRequest> __Method_ProcessRequests = new grpc::Method<global::ChariswallServices.Protos.RequestInput, global::ChariswallServices.Protos.ResultOutputRequest>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ProcessRequests",
        __Marshaller_NimaRequest_RequestInput,
        __Marshaller_NimaRequest_ResultOutputRequest);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ChariswallServices.Protos.RequestDetailInput, global::ChariswallServices.Protos.ResultOutputRequest> __Method_ProcessRequestDetail = new grpc::Method<global::ChariswallServices.Protos.RequestDetailInput, global::ChariswallServices.Protos.ResultOutputRequest>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ProcessRequestDetail",
        __Marshaller_NimaRequest_RequestDetailInput,
        __Marshaller_NimaRequest_ResultOutputRequest);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ChariswallServices.Protos.GeneralInputRequest, global::ChariswallServices.Protos.NewRequests> __Method_GetNewRequests = new grpc::Method<global::ChariswallServices.Protos.GeneralInputRequest, global::ChariswallServices.Protos.NewRequests>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetNewRequests",
        __Marshaller_NimaRequest_GeneralInputRequest,
        __Marshaller_NimaRequest_NewRequests);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ChariswallServices.Protos.CodeInput, global::ChariswallServices.Protos.CheckOutput> __Method_CheckRequest = new grpc::Method<global::ChariswallServices.Protos.CodeInput, global::ChariswallServices.Protos.CheckOutput>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckRequest",
        __Marshaller_NimaRequest_CodeInput,
        __Marshaller_NimaRequest_CheckOutput);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ChariswallServices.Protos.NimaRequestReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of NimaRequest</summary>
    [grpc::BindServiceMethod(typeof(NimaRequest), "BindService")]
    public abstract partial class NimaRequestBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ChariswallServices.Protos.ResultOutputRequest> ProcessRequests(global::ChariswallServices.Protos.RequestInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ChariswallServices.Protos.ResultOutputRequest> ProcessRequestDetail(global::ChariswallServices.Protos.RequestDetailInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ChariswallServices.Protos.NewRequests> GetNewRequests(global::ChariswallServices.Protos.GeneralInputRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ChariswallServices.Protos.CheckOutput> CheckRequest(global::ChariswallServices.Protos.CodeInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(NimaRequestBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ProcessRequests, serviceImpl.ProcessRequests)
          .AddMethod(__Method_ProcessRequestDetail, serviceImpl.ProcessRequestDetail)
          .AddMethod(__Method_GetNewRequests, serviceImpl.GetNewRequests)
          .AddMethod(__Method_CheckRequest, serviceImpl.CheckRequest).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, NimaRequestBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ProcessRequests, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ChariswallServices.Protos.RequestInput, global::ChariswallServices.Protos.ResultOutputRequest>(serviceImpl.ProcessRequests));
      serviceBinder.AddMethod(__Method_ProcessRequestDetail, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ChariswallServices.Protos.RequestDetailInput, global::ChariswallServices.Protos.ResultOutputRequest>(serviceImpl.ProcessRequestDetail));
      serviceBinder.AddMethod(__Method_GetNewRequests, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ChariswallServices.Protos.GeneralInputRequest, global::ChariswallServices.Protos.NewRequests>(serviceImpl.GetNewRequests));
      serviceBinder.AddMethod(__Method_CheckRequest, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ChariswallServices.Protos.CodeInput, global::ChariswallServices.Protos.CheckOutput>(serviceImpl.CheckRequest));
    }

  }
}
#endregion
