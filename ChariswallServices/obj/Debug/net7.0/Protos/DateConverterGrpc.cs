// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/DateConverter.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace HelperServer {
  public static partial class DateConverter
  {
    static readonly string __ServiceName = "DateConverter.DateConverter";

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
    static readonly grpc::Marshaller<global::HelperServer.InputDateInt> __Marshaller_DateConverter_InputDateInt = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HelperServer.InputDateInt.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HelperServer.OutputDateTime> __Marshaller_DateConverter_OutputDateTime = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HelperServer.OutputDateTime.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HelperServer.InputG2P> __Marshaller_DateConverter_InputG2P = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HelperServer.InputG2P.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HelperServer.InputP2G> __Marshaller_DateConverter_InputP2G = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HelperServer.InputP2G.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HelperServer.InputBusinessDays> __Marshaller_DateConverter_InputBusinessDays = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HelperServer.InputBusinessDays.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HelperServer.InputDateInt, global::HelperServer.OutputDateTime> __Method_IntToDate = new grpc::Method<global::HelperServer.InputDateInt, global::HelperServer.OutputDateTime>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IntToDate",
        __Marshaller_DateConverter_InputDateInt,
        __Marshaller_DateConverter_OutputDateTime);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HelperServer.InputG2P, global::HelperServer.OutputDateTime> __Method_GregorianToPersian = new grpc::Method<global::HelperServer.InputG2P, global::HelperServer.OutputDateTime>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GregorianToPersian",
        __Marshaller_DateConverter_InputG2P,
        __Marshaller_DateConverter_OutputDateTime);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HelperServer.InputP2G, global::HelperServer.OutputDateTime> __Method_PersianToGregorian = new grpc::Method<global::HelperServer.InputP2G, global::HelperServer.OutputDateTime>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PersianToGregorian",
        __Marshaller_DateConverter_InputP2G,
        __Marshaller_DateConverter_OutputDateTime);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HelperServer.InputBusinessDays, global::HelperServer.OutputDateTime> __Method_AddBusinessDays = new grpc::Method<global::HelperServer.InputBusinessDays, global::HelperServer.OutputDateTime>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddBusinessDays",
        __Marshaller_DateConverter_InputBusinessDays,
        __Marshaller_DateConverter_OutputDateTime);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::HelperServer.DateConverterReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for DateConverter</summary>
    public partial class DateConverterClient : grpc::ClientBase<DateConverterClient>
    {
      /// <summary>Creates a new client for DateConverter</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public DateConverterClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for DateConverter that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public DateConverterClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected DateConverterClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected DateConverterClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime IntToDate(global::HelperServer.InputDateInt request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IntToDate(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime IntToDate(global::HelperServer.InputDateInt request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IntToDate, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> IntToDateAsync(global::HelperServer.InputDateInt request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IntToDateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> IntToDateAsync(global::HelperServer.InputDateInt request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IntToDate, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime GregorianToPersian(global::HelperServer.InputG2P request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GregorianToPersian(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime GregorianToPersian(global::HelperServer.InputG2P request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GregorianToPersian, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> GregorianToPersianAsync(global::HelperServer.InputG2P request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GregorianToPersianAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> GregorianToPersianAsync(global::HelperServer.InputG2P request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GregorianToPersian, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime PersianToGregorian(global::HelperServer.InputP2G request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PersianToGregorian(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime PersianToGregorian(global::HelperServer.InputP2G request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_PersianToGregorian, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> PersianToGregorianAsync(global::HelperServer.InputP2G request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PersianToGregorianAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> PersianToGregorianAsync(global::HelperServer.InputP2G request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_PersianToGregorian, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime AddBusinessDays(global::HelperServer.InputBusinessDays request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddBusinessDays(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HelperServer.OutputDateTime AddBusinessDays(global::HelperServer.InputBusinessDays request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddBusinessDays, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> AddBusinessDaysAsync(global::HelperServer.InputBusinessDays request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddBusinessDaysAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HelperServer.OutputDateTime> AddBusinessDaysAsync(global::HelperServer.InputBusinessDays request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddBusinessDays, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override DateConverterClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new DateConverterClient(configuration);
      }
    }

  }
}
#endregion
